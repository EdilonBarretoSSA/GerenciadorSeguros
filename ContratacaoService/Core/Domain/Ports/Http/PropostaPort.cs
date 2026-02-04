using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Http
{
    public interface IPropostaPort
    {
        Task<Seguro> ObterPropostaAsync(string propostaId);
        Task<Seguro> ObterStatusPropostaAsync(string propostaId);
    }
}
