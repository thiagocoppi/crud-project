using Domain.Base;
using System.Threading.Tasks;

namespace Domain.Fornecedores
{
    public interface IFornecedorService : IDomainService
    {
        Task<Fornecedor> Cadastrar(Fornecedor fornecedor);

        Task<Fornecedor> Atualizar(Fornecedor fornecedor);
    }
}