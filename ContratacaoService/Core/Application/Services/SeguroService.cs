using Domain.Ports.Http;
using Domain.Ports.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SeguroService : ISeguroService
    {
        private readonly IPropostaPort propostaHttp;
        public SeguroService(IPropostaPort _propostaHttp) 
        {
            propostaHttp = _propostaHttp;
        }

        public async Task Contratar(string numeroProposta)
        {
            var contratacao = await propostaHttp.ObterPropostaAsync(numeroProposta);
        } 

        public async Task ObterStatus(string numeroProposta)
        {
            var contratacao = await propostaHttp.ObterPropostaAsync(numeroProposta);
        }
    }
}
