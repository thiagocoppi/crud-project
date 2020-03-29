using Canonico.ReceitaFederal;
using Domain.Base;
using Domain.Empresas;
using System;

namespace Domain.Fornecedores
{
    public class Fornecedor : BaseEntity
    {
        public Empresa Empresa { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public string IdentificadorReceitaFederal { get; set; }

        public Fornecedor(Empresa empresa, string nome, DateTime dataCadastro, DadosPessoais dadosPessoais, string identificadorReceitaFederal)
        {
            Empresa = empresa;
            Nome = nome;
            DataCadastro = dataCadastro;
            DadosPessoais = dadosPessoais;
            IdentificadorReceitaFederal = identificadorReceitaFederal;
        }

        protected Fornecedor()
        {
        }
    }
}