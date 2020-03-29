using Application.Queries.Empresas.Models;
using Domain.Empresas;
using MediatR;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Empresas.GetAll
{
    public sealed class ObterTodasEmpresasQueryHandler : IRequestHandler<ObterTodasEmpresasQueryRequest, ObterTodasEmpresasQueryResult>
    {
        private readonly IEmpresaQueryStore _empresaQueryStore;

        public ObterTodasEmpresasQueryHandler(IEmpresaQueryStore empresaQueryStore)
        {
            _empresaQueryStore = empresaQueryStore;
        }

        public async Task<ObterTodasEmpresasQueryResult> Handle(ObterTodasEmpresasQueryRequest request, CancellationToken cancellationToken)
        {
            var empresas = await _empresaQueryStore.ObterEmpresas();
            var empresasResult = new List<EmpresaResult>();
            empresas.ForEach(r =>
            {
                empresasResult.Add(new EmpresaResult()
                {
                    Id = r.Id,
                    CNPJ = r.CNPJ,
                    NomeFantasia = r.NomeFantasia,
                    UF = r.UF.ToString()
                });
            });

            return new ObterTodasEmpresasQueryResult() { Empresas = empresasResult };
        }
    }
}