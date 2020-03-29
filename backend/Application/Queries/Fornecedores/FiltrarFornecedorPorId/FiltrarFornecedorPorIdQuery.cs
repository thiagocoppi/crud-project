using MediatR;

namespace Application.Queries.Fornecedores.FiltrarFornecedorPorId
{
    public sealed class FiltrarFornecedorPorIdQuery : IRequest<FiltrarFornecedorPorIdQueryResponse>
    {
        public string Id { get; set; }
    }
}