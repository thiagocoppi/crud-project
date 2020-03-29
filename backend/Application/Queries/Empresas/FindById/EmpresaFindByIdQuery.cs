using MediatR;
using System;

namespace Application.Queries.Empresas.FindById
{
    public sealed class EmpresaFindByIdQuery : IRequest<EmpresaFindByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}