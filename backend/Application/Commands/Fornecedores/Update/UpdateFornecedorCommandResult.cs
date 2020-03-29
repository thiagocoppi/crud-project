using Application.Commands.Fornecedores.Create.Models;
using Canonico.ReceitaFederal;
using System;

namespace Application.Commands.Fornecedores.Update
{
    public sealed class UpdateFornecedorCommandResult
    {
        public EmpresaResult Empresa { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public string IdentificadorReceitaFederal { get; set; }
    }
}