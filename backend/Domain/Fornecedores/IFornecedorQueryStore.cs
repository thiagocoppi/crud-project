using Domain.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Fornecedores
{
    public interface IFornecedorQueryStore : IStore
    {
        Task<List<Fornecedor>> FiltrarFornecedores(string filtro, DateTime dataCadastro);

        Task<Fornecedor> FiltrarFornecedorPeloId(Guid id);
    }
}