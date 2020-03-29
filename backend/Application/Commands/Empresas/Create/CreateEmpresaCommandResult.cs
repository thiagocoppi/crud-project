using Canonico.Enderecos;

namespace Application.Commands.Empresas.Create
{
    public class CreateEmpresaCommandResult
    {
        public EnumUF UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}