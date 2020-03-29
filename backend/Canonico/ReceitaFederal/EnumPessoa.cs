using System.ComponentModel.DataAnnotations;

namespace Canonico.ReceitaFederal
{
    public enum EnumPessoa
    {
        [Display(Name = "Pessoa Física")]
        PF,

        [Display(Name = "Pessoa Jurídica")]
        PJ
    }
}