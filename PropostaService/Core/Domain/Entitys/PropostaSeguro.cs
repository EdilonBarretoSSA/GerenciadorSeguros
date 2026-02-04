using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class PropostaSeguro
    {
        [JsonIgnore]
        public int Id { get; private set; }
        public string NumeroProposta { get; set; }
        public string DescricaoSeguro { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataInícioVigencia{ get; set; }
        public DateTime DataFimVigencia { get; set; }
        public EStatusProposta Status { get; set; }
        public decimal ValorPremio { get; set; }
        public decimal ValorParcela { get; set; }
        public int QtdeParcelas { get; set; }
        public Cliente Cliente { get; set; }

        [JsonIgnore]
        public int IdCliente { get; set; }
    }
}
