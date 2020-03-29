using Domain.Fornecedores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.Stores.QueryStores
{
    public sealed class FornecedorQueryStore : IFornecedorQueryStore
    {
        private readonly ICrudContext _crudContext;

        public FornecedorQueryStore(ICrudContext crudContext)
        {
            _crudContext = crudContext;
        }

        public Task<List<Fornecedor>> FiltrarFornecedores(string filtro, DateTime dataCadastro)
        {
            var fornecedoresQuery = _crudContext.Fornecedore.AsQueryable().Include(r => r.Empresa);

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                fornecedoresQuery
                    .Where(r => r.Nome.ToUpper().Contains(filtro.ToUpper()))
                    .Where(r => r.IdentificadorReceitaFederal.Contains(filtro));
            }

            if (dataCadastro != DateTime.MinValue)
            {
                fornecedoresQuery.Where(r => r.DataCadastro.Equals(dataCadastro));
            }

            return Task.FromResult(fornecedoresQuery.ToList());
        }

        public async Task<Fornecedor> FiltrarFornecedorPeloId(Guid id)
        {
            return await _crudContext.Fornecedore.AsQueryable().Include(r => r.Empresa).Where(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}