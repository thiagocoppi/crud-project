using Canonico.Enderecos;
using Domain.Empresas;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Empresas.Create
{
    public sealed class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, CreateEmpresaCommandResult>
    {
        private readonly IEmpresaService _empresaService;

        public CreateEmpresaCommandHandler(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        public async Task<CreateEmpresaCommandResult> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var enumeradorUf = (EnumUF)Enum.Parse(typeof(EnumUF), request.UF);
            var empresa = await _empresaService.CadastrarAsync(new Empresa(enumeradorUf, request.NomeFantasia, request.CNPJ));

            return new CreateEmpresaCommandResult() 
            { 
                CNPJ = empresa.CNPJ,
                NomeFantasia = empresa.NomeFantasia,
                UF = empresa.UF
            };
        }
    }
}