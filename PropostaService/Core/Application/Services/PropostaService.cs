using Domain.Entitys;
using Domain.Ports.Repository;
using Domain.Ports.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PropostaService : IPropostaService
    {
        private IPropostaSeguroRepository _propostaSeguroRepository;

        public PropostaService(IPropostaSeguroRepository propostaSeguroRepository)
        {
            _propostaSeguroRepository = propostaSeguroRepository;
        }

        public async Task SalvarAsync(PropostaSeguro propostaSeguro) 
        {
            await _propostaSeguroRepository.SalvarAsync(propostaSeguro);
        }

        public async Task AtualizarAsync(PropostaSeguro propostaUpdate) 
        {
            await _propostaSeguroRepository.AtualizarAsync(propostaUpdate);

        }

        public async Task<IEnumerable<PropostaSeguro>> ObterAsync(PropostaSeguro propostaFilter) 
        {
            return await _propostaSeguroRepository.ObterAsync(propostaFilter);
        }
    }
}
