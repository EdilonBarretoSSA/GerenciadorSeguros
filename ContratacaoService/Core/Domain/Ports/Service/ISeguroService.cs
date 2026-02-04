using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Service
{
    public interface ISeguroService
    {
        Task Contratar(string numeroProposta);

        Task ObterStatus(string numeroProposta);
    }
}
