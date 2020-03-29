using Application.Queries.Empresas.Models;
using Canonico.ReceitaFederal;
using System;

namespace Application.Queries.Fornecedores.Models
{
    public sealed class FornecedoresResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string IdentificadorReceitaFederal { get; set; }
        public EmpresaResult Empresa { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}