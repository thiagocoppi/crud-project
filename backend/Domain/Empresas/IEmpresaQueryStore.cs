using Domain.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Empresas
{
    public interface IEmpresaQueryStore : IStore
    {
        Task<Empresa> ObterEmpresaPeloId(Guid Id);

        Task<List<Empresa>> ObterEmpresas();
    }
}