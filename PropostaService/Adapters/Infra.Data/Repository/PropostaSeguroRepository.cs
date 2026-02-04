using Domain.Entitys;
using Domain.Ports.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class PropostaSeguroRepository : IPropostaSeguroRepository
    {
        private readonly DataBaseContext _context;

        public PropostaSeguroRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SalvarAsync(PropostaSeguro propostaSeguro)
        {
            await _context.PropostasSeguros.AddAsync(propostaSeguro);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(PropostaSeguro propostaSeguro)
        {
            var propostaAtualizar = await _context.PropostasSeguros
                .FirstOrDefaultAsync(p => p.NumeroProposta == propostaSeguro.NumeroProposta);

            if (propostaAtualizar == null)
                throw new Exception("Proposta não encontrada.");

            propostaAtualizar.Status = propostaSeguro.Status;

            _context.PropostasSeguros.Update(propostaAtualizar);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PropostaSeguro>> ObterAsync(PropostaSeguro filtro)
        {
            return await _context.PropostasSeguros
                .AsNoTracking()
                .Where(c =>
                    (string.IsNullOrEmpty(filtro.Cliente.CPF) || c.Cliente.CPF == filtro.Cliente.CPF) &&
                    (string.IsNullOrEmpty(filtro.Cliente.Nome) || c.Cliente.Nome != null && c.Cliente.Nome.Contains(filtro.Cliente.Nome)) &&
                    (string.IsNullOrEmpty(filtro.Cliente.RG) || c.Cliente.RG == filtro.Cliente.RG))
                .ToListAsync();
        }
    }
}
