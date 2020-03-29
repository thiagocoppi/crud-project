using MediatR;
using System;

namespace Application.Queries.Fornecedores
{
    public sealed class FiltrarFornecedoresQueryRequest : IRequest<FiltrarFornecedoresQueryResponse>
    {
        public string Filtro { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}