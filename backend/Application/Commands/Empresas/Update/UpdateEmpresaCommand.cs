using Canonico.Enderecos;
using MediatR;
using System;

namespace Application.Commands.Empresas.Update
{
    public sealed class UpdateEmpresaCommand : IRequest<UpdateEmpresaCommandResult>
    {
        public string Id { get; set; }
        public string UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}