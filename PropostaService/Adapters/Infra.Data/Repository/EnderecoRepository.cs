using Domain.Entitys;
using Domain.Ports.Repository;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {

        private readonly DataBaseContext _context;

        public EnderecoRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SalvarAsync(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

    }

}

