using Canonico.Enderecos;
using System;

namespace Application.Commands.Empresas.Update
{
    public sealed class UpdateEmpresaCommandResult
    {
        public Guid Id { get; set; }
        public EnumUF UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}