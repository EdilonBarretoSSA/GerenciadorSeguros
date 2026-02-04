using Domain.Entitys;
using Domain.Enums;
using Domain.Ports.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace PropostaAPI.Controllers
{
    public class PropostaController : Controller
    {
        public IPropostaService propostaService;

        public PropostaController(IPropostaService _propostaService) 
        {
            propostaService = _propostaService;
        }

        [HttpPost("Criar")]
        [EndpointDescription("Método responsável pela criação das propostas de seguro")]
        public async Task Post([FromBody] PropostaSeguro propostaSeguro)
        {
            await propostaService.SalvarAsync(propostaSeguro);
        }

        [HttpGet("Listar")]
        [EndpointDescription("Método responsável por listar as propostas de seguro")]
        public async Task<IEnumerable<PropostaSeguro>> Get(string numeroProposta, string cpf, string nome, string rg)
        {
            var propostaFilter = new PropostaSeguro()
            {
                NumeroProposta = numeroProposta,
                Cliente = new Cliente() { CPF = cpf, Nome = nome, RG = rg }
            };

            var retortno  = await propostaService.ObterAsync(propostaFilter);

            return retortno;
        }

        [HttpGet("AlterarStatus")]
        [EndpointDescription("Método responsável por alterar os status das propostas de seguro")]        
        public async Task Put(string numeroProposta, string status)
        {
            var propostaUpdate = new PropostaSeguro()
            {
                NumeroProposta = numeroProposta,
                Status = Enum.Parse<EStatusProposta>(status)
            };

            await propostaService.AtualizarAsync(propostaUpdate);
        }
    }
}
