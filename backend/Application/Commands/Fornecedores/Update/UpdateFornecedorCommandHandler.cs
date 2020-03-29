using Application.Commands.Fornecedores.Create.Models;
using Domain.Base;
using Domain.Empresas;
using Domain.Fornecedores;
using Languages;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Fornecedores.Update
{
    public sealed class UpdateFornecedorCommandHandler : IRequestHandler<UpdateFornecedorCommand, UpdateFornecedorCommandResult>
    {
        private readonly IEmpresaQueryStore _empresaQueryStore;
        private readonly IFornecedorService _fornecedorService;
        private readonly INotificationContext _notificationContext;

        public UpdateFornecedorCommandHandler(IEmpresaQueryStore empresaQueryStore, IFornecedorService fornecedorService, INotificationContext notificationContext)
        {
            _empresaQueryStore = empresaQueryStore;
            _fornecedorService = fornecedorService;
            _notificationContext = notificationContext;
        }

        public async Task<UpdateFornecedorCommandResult> Handle(UpdateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaQueryStore.ObterEmpresaPeloId(Guid.Parse(request.EmpresaId));

            if (empresa is null || empresa.Id == Guid.Empty)
            {
                _notificationContext.AddNotification(new Notification(Mensagens.EmpresaNaoEncontradaTitulo, Mensagens.EmpresaNaoEncontradaTexto));
                return null;
            }

            var fornecedorAtualizado = await _fornecedorService.Atualizar(new Fornecedor(empresa, request.Nome, request.DataCadastro,
                request.DadosPessoais, request.IdentificadorReceitaFederal)
            { 
                Id = Guid.Parse(request.Id)
            });

            return new UpdateFornecedorCommandResult()
            {
                Empresa = new EmpresaResult()
                {
                    NomeFantasia = fornecedorAtualizado.Empresa.NomeFantasia,
                    CNPJ = fornecedorAtualizado.Empresa.CNPJ,
                    UF = fornecedorAtualizado.Empresa.UF
                },
                DadosPessoais = fornecedorAtualizado.DadosPessoais,
                DataCadastro = fornecedorAtualizado.DataCadastro,
                IdentificadorReceitaFederal = fornecedorAtualizado.IdentificadorReceitaFederal,
                Nome = fornecedorAtualizado.Nome
            };
        }
    }
}