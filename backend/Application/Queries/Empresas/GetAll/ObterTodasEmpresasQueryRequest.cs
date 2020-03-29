using MediatR;

namespace Application.Queries.Empresas.GetAll
{
    public sealed class ObterTodasEmpresasQueryRequest : IRequest<ObterTodasEmpresasQueryResult>
    {
    }
}