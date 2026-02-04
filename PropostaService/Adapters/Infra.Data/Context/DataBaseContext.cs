using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<PropostaSeguro> PropostasSeguros { get; set; } = null!;
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropostaSeguro>(b =>
            {
                b.ToTable("PropostasSeguro");
                b.HasKey(p => p.Id);
                b.Property(p => p.NumeroProposta).HasMaxLength(100);
                b.Property(p => p.DataCriacao).IsRequired();
                b.Property(p => p.DataInícioVigencia).IsRequired();
                b.Property(p => p.DataFimVigencia).IsRequired();
                b.Property(p => p.DescricaoSeguro).IsRequired();
                b.Property(p => p.Status).IsRequired().HasConversion<int>().IsRequired();
                b.Property(p => p.ValorParcela).IsRequired().HasColumnType("decimal(18,2)");
                b.Property(p => p.ValorPremio).IsRequired().HasColumnType("decimal(18,2)");
                b.Property(p => p.QtdeParcelas).IsRequired();
            });

            modelBuilder.Entity<Cliente>(b =>
            {
                b.ToTable("Clientes");
                b.HasKey(c => c.Id);
                b.Property(c => c.Nome).IsRequired().HasMaxLength(200);
                b.Property(c => c.CPF).IsRequired().HasMaxLength(11);
                b.Property(c => c.RG).IsRequired().HasMaxLength(50);
                b.Property(c => c.OrgaoExpedicao).IsRequired().HasMaxLength(20);
                b.Property(c => c.Sexo).IsRequired().HasMaxLength(20);
                b.Property(c => c.EstadoCivil).IsRequired().HasMaxLength(30);

                b.HasOne(p => p.Endereco)
                    .WithOne(d => d.Cliente)
                    .HasForeignKey<Endereco>(d => d.IdCliente);

                b.HasMany(p => p.PropostasSeguro)
                   .WithOne(d => d.Cliente)
                   .HasForeignKey(p => p.IdCliente)
                   .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Endereco>(b =>
            {
                b.ToTable("Enderecos");
                b.HasKey(e => e.Id);
                b.Property(e => e.CEP).IsRequired().HasMaxLength(8);
                b.Property(e => e.Logradouro).IsRequired().HasMaxLength(300);
                b.Property(e => e.Bairro).IsRequired().HasMaxLength(200);
                b.Property(e => e.Cidade).IsRequired().HasMaxLength(200);
                b.Property(e => e.Numero).IsRequired().HasMaxLength(10);
                b.Property(e => e.UF).IsRequired().HasMaxLength(2);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
