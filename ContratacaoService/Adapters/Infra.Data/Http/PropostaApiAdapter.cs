using Domain.ApiRoutes;
using Domain.Entitys;
using Domain.Ports.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infra.Data.Context
{
    public class PropostaApiAdapter : IPropostaPort
    {
        private readonly HttpClient _httpClient;

        public PropostaApiAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Seguro> ObterPropostaAsync(string propostaId)
        {
            var response = await _httpClient
                .GetAsync(PropostaRoutes.Listar + $"{propostaId}");

            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var retorno = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(retorno))
                return null;

            return JsonSerializer.Deserialize<List<Seguro>>(retorno, options).FirstOrDefault();
        }

        public async Task<Seguro> ObterStatusPropostaAsync(string propostaId)
        {
            var response = await _httpClient
                .GetAsync(PropostaRoutes.Listar + $"{propostaId}");

            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var retorno = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(retorno))
                return null;

            return JsonSerializer.Deserialize<List<Seguro>>(retorno, options).FirstOrDefault();
        }
    }
}
