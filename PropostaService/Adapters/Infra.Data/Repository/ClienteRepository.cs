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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataBaseContext _context;

        public ClienteRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SalvarAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
