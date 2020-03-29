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

        public async Task<List<Fornecedor>> FiltrarFornecedores(string filtro, DateTime dataCadastro)
        {
            var fornecedoresQuery = _crudContext.Fornecedore.Include(r => r.Empresa).AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var isNomeFilter = filtro.Any(x => char.IsLetter(x));

                if (isNomeFilter)
                {
                    fornecedoresQuery = fornecedoresQuery.Where(r => r.Nome.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    fornecedoresQuery = fornecedoresQuery.Where(r => r.IdentificadorReceitaFederal.Contains(filtro));
                }
            }

            if (dataCadastro != DateTime.MinValue)
            {
                fornecedoresQuery = fornecedoresQuery.Where(r => r.DataCadastro.Date.Equals(dataCadastro.Date));
            }

            var fornecedoresFiltrados = await fornecedoresQuery.ToListAsync();

            return fornecedoresFiltrados;
        }

        public async Task<Fornecedor> FiltrarFornecedorPeloId(Guid id)
        {
            return await _crudContext.Fornecedore.AsQueryable().Include(r => r.Empresa).Where(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}