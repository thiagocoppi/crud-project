using Domain.Empresas;
using Domain.Fornecedores;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public interface ICrudContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Fornecedor> Fornecedore { get; set; }

        Task<int> SaveChangesAsync();
    }
}