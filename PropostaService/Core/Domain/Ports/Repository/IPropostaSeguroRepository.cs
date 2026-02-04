using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Repository
{
    public interface IPropostaSeguroRepository
    {
        Task SalvarAsync(PropostaSeguro propostaSeguro);

        Task AtualizarAsync(PropostaSeguro propostaSeguro);

        Task<IEnumerable<PropostaSeguro>> ObterAsync(PropostaSeguro filtro);
    }
}
