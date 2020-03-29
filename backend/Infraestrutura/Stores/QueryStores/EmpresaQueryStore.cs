using Domain.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.Stores.QueryStores
{
    public sealed class EmpresaQueryStore : IEmpresaQueryStore
    {
        private readonly ICrudContext _crudContext;

        public EmpresaQueryStore(ICrudContext crudContext)
        {
            _crudContext = crudContext;
        }

        public async Task<Empresa> ObterEmpresaPeloId(Guid Id)
        {
            var empresa = await _crudContext.Empresa.FindAsync(Id);
            return empresa;
        }

        public Task<List<Empresa>> ObterEmpresas()
        {
            return Task.FromResult(_crudContext.Empresa.AsQueryable().ToList());
        }
    }
}