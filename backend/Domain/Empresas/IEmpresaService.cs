using Domain.Base;
using System.Threading.Tasks;

namespace Domain.Empresas
{
    public interface IEmpresaService : IDomainService
    {
        Task<Empresa> CadastrarAsync(Empresa empresa);

        Task<Empresa> AtualizarAsync(Empresa empresa);
    }
}