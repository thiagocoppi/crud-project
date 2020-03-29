using Application.Commands.Fornecedores.Create.Models;
using Canonico.ReceitaFederal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Fornecedores.Create
{
    public sealed class CreateFornecedorCommandResult
    {
        public EmpresaResult Empresa { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
    }
}
