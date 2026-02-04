using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Endereco
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        [JsonIgnore]
        public int IdCliente { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
