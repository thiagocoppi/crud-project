using MediatR;
using System;

namespace Application.Commands.Fornecedores.Delete
{
    public sealed class DeleteFornecedorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}