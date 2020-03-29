using Domain.Base;
using System;
using System.Threading.Tasks;

namespace Domain.Fornecedores
{
    public interface IFornecedorCommandStore : IStore
    {
        Task<Fornecedor> Cadastrar(Fornecedor fornecedor);

        Task<Fornecedor> Atualizar(Fornecedor fornecedor);

        Task<bool> Remover(Guid id);
    }
}