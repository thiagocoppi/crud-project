using Canonico.Enderecos;
using Domain.Fornecedores;
using System;
using System.Collections.Generic;

namespace Domain.Empresas
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public EnumUF UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        public ICollection<Fornecedor> Fornecedores { get; set; }

        public Empresa(EnumUF uF, string nomeFantasia, string cNPJ)
        {
            UF = uF;
            NomeFantasia = nomeFantasia;
            CNPJ = cNPJ;
        }

        protected Empresa()
        {
        }
    }
}