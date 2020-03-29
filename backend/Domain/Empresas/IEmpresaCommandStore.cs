using Domain.Base;
using System.Threading.Tasks;

namespace Domain.Empresas
{
    public interface IEmpresaCommandStore : IStore
    {
        Task<Empresa> Cadastrar(Empresa empresa);

        Task<Empresa> AtualizarEmpresa(Empresa empresa);
    }
}