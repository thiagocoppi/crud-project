using Domain.Empresas;
using Domain.Fornecedores;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public sealed class CrudContext : DbContext, ICrudContext
    {
        public CrudContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Fornecedor> Fornecedore { get; set; }

        public Task<int> SaveChangesAsync()
        {
            base.SaveChanges();

            return Task.FromResult(0);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as configurações por convenções.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudContext).Assembly);
        }
    }
}