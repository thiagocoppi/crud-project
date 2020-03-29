using Canonico.ReceitaFederal;
using MediatR;
using System;

namespace Application.Commands.Fornecedores.Update
{
    public sealed class UpdateFornecedorCommand : IRequest<UpdateFornecedorCommandResult>
    {
        public string Id { get; set; }
        public string EmpresaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public string IdentificadorReceitaFederal { get; set; }
    }
}