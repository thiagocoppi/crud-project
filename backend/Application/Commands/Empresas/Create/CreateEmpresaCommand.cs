using Canonico.Enderecos;
using MediatR;

namespace Application.Commands.Empresas.Create
{
    public class CreateEmpresaCommand : IRequest<CreateEmpresaCommandResult>
    {
        public string UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}