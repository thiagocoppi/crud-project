using FluentValidation;
using Languages;

namespace Application.Commands.Empresas.Create
{
    public sealed class CreateEmpresaCommandValidator : AbstractValidator<CreateEmpresaCommand>
    {
        public CreateEmpresaCommandValidator()
        {
            RuleFor(r => r.CNPJ)
                .NotNull().WithMessage(Mensagens.EmpresaCnpjObrigatorio)
                .NotEmpty().WithMessage(Mensagens.EmpresaCnpjObrigatorio);

            RuleFor(r => r.NomeFantasia)
                .NotNull().WithMessage(Mensagens.EmpresaNomeObrigatorio)
                .NotEmpty().WithMessage(Mensagens.EmpresaNomeObrigatorio);

            RuleFor(r => r.UF)
                .NotNull().WithMessage(Mensagens.EmpresaUFObrigatorio);
        }
    }
}