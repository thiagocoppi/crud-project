using Application.Queries.Fornecedores.Models;
using System.Collections.Generic;

namespace Application.Queries.Fornecedores
{
    public sealed class FiltrarFornecedoresQueryResponse
    {
        public List<FornecedoresResponse> Fornecedores { get; set; }

        public FiltrarFornecedoresQueryResponse()
        {
            Fornecedores = new List<FornecedoresResponse>();
        }
    }
}