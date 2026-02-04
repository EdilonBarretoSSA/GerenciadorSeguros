using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Cliente
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public DateTime DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public Endereco Endereco { get; set; }

        [JsonIgnore]
        public List<PropostaSeguro> PropostasSeguro { get; set; }
    }
}
