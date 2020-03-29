using Canonico.Enderecos;

namespace Application.Commands.Fornecedores.Create.Models
{
    public sealed class EmpresaResult
    {
        public string NomeFantasia { get; set; }
        public EnumUF UF { get; set; }
        public string CNPJ { get; set; }
    }
}