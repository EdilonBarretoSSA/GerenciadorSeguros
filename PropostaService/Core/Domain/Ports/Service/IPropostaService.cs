using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Service
{
    public interface IPropostaService
    {
        Task SalvarAsync(PropostaSeguro propostaSeguro);

        Task AtualizarAsync(PropostaSeguro propostaUpdate);

        Task<IEnumerable<PropostaSeguro>> ObterAsync(PropostaSeguro filtro);
    }
}
