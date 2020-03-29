using Canonico.ReceitaFederal;
using FluentValidation;
using Languages;
using System;

namespace Application.Commands.Fornecedores.Create
{
    public class CreateFornecedorCommandValidator : AbstractValidator<CreateFornecedorCommand>
    {
        public CreateFornecedorCommandValidator()
        {
            RuleFor(r => r.EmpresaId).Custom((r, context) =>
            {
                if (r == null || r == string.Empty)
                {
                    context.AddFailure(Mensagens.FornecedorInformarEmpresaID);
                }
            });

            RuleFor(r => r.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.IdentificadorReceitaFederal).Custom((r, context) =>
            {
                if (!r.IsValid())
                {
                    context.AddFailure(Mensagens.FornecedorCPFCNPJInvalido);
                }
            });

            When(r => r.DadosPessoais != null, () =>
            {
                RuleFor(r => r.IdentificadorReceitaFederal).Must((r, s) =>
                    ValidarCPFDataNascimento(r.IdentificadorReceitaFederal, r))
                    .WithMessage(Mensagens.FornecedorPFInformarDataNascRG);
            });
        }

        private bool ValidarCPFDataNascimento(string cpfcnpj, CreateFornecedorCommand command)
        {
            if (cpfcnpj.IsCnpj())
            {
                return true;
            }

            if (cpfcnpj.IsCPF() && (command.DadosPessoais.DataNascimento == DateTime.MinValue || string.IsNullOrWhiteSpace(command.DadosPessoais.Identificador)))
            {
                return false;
            }

            return true;
        }
    }
}