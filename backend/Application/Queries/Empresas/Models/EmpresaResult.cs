using Canonico.Enderecos;
using System;

namespace Application.Queries.Empresas.Models
{
    public sealed class EmpresaResult
    {
        public Guid Id { get; set; }
        public string NomeFantasia { get; set; }
        public string UF { get; set; }
        public string CNPJ { get; set; }
    }
}