using Canonico.ReceitaFederal;
using MediatR;
using System;

namespace Application.Commands.Fornecedores.Create
{
    public sealed class CreateFornecedorCommand : IRequest<CreateFornecedorCommandResult>
    {
        public string EmpresaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public string IdentificadorReceitaFederal { get; set; }

    }
}