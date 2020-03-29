using Canonico.Enderecos;
using Domain.Empresas;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Empresas.Update
{
    public sealed class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, UpdateEmpresaCommandResult>
    {
        private readonly IEmpresaService _empresaService;

        public UpdateEmpresaCommandHandler(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        public async Task<UpdateEmpresaCommandResult> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresaAtualizada = await _empresaService.AtualizarAsync(new Empresa((EnumUF)Enum.Parse(typeof(EnumUF), request.UF),
                request.NomeFantasia, request.CNPJ)
            { Id = Guid.Parse(request.Id) });

            return new UpdateEmpresaCommandResult()
            {
                Id = empresaAtualizada.Id,
                CNPJ = empresaAtualizada.CNPJ,
                NomeFantasia = empresaAtualizada.NomeFantasia,
                UF = empresaAtualizada.UF
            };
        }
    }
}