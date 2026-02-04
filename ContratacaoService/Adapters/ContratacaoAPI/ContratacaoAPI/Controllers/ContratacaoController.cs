using Domain.Ports.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContratacaoAPI.Controllers
{
    public class ContratacaoController : Controller
    {
        private readonly ISeguroService seguroService;
        public ContratacaoController(ISeguroService _seguroService) 
        {
            seguroService = _seguroService;
        }

        [HttpPost("Contratar")]
        public void Post(string numeroProposta)
        {
            seguroService.Contratar(numeroProposta);
        } 

        [HttpGet("ObterStatusProposta")]
        public void Get(string numeroProposta)
        {
            seguroService.ObterStatus(numeroProposta);
        }
    }
}
