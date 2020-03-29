using Application.Queries.Empresas.Models;
using Application.Queries.Fornecedores.Models;
using Domain.Fornecedores;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Fornecedores.FiltrarFornecedores
{
    public sealed class FiltrarFornecedoresQueryHandler : IRequestHandler<FiltrarFornecedoresQueryRequest, FiltrarFornecedoresQueryResponse>
    {
        private readonly IFornecedorQueryStore _fornecedorQueryStore;

        public FiltrarFornecedoresQueryHandler(IFornecedorQueryStore fornecedorQueryStore)
        {
            _fornecedorQueryStore = fornecedorQueryStore;
        }

        public async Task<FiltrarFornecedoresQueryResponse> Handle(FiltrarFornecedoresQueryRequest request, CancellationToken cancellationToken)
        {
            var fornecedores = await _fornecedorQueryStore.FiltrarFornecedores(request.Filtro, request.DataCadastro);
            var listaFornecedoresResponse = new List<FornecedoresResponse>();

            fornecedores.ForEach(r =>
            {
                listaFornecedoresResponse.Add(new FornecedoresResponse()
                {
                    Id = r.Id,
                    IdentificadorReceitaFederal = r.IdentificadorReceitaFederal,
                    Nome = r.Nome,
                    Empresa = new EmpresaResult()
                    {
                        Id = r.Empresa.Id,
                        CNPJ = r.Empresa.CNPJ,
                        NomeFantasia = r.Empresa.NomeFantasia,
                        UF = r.Empresa.UF.ToString()
                    },
                    DataCadastro = r.DataCadastro
                });
            });

            return new FiltrarFornecedoresQueryResponse() { Fornecedores = listaFornecedoresResponse };
        }
    }
}