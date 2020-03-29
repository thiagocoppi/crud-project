using Application.Queries.Empresas.Models;
using Application.Queries.Fornecedores.Models;
using Canonico.ReceitaFederal;
using Domain.Base;
using Domain.Fornecedores;
using Languages;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Fornecedores.FiltrarFornecedorPorId
{
    public sealed class FiltrarFornecedorPorIdQueryHandler : IRequestHandler<FiltrarFornecedorPorIdQuery, FiltrarFornecedorPorIdQueryResponse>
    {
        private IFornecedorQueryStore _fornecedorQueryStore;
        private INotificationContext _notificationContext;

        public FiltrarFornecedorPorIdQueryHandler(IFornecedorQueryStore fornecedorQueryStore, INotificationContext notificationContext)
        {
            _fornecedorQueryStore = fornecedorQueryStore;
            _notificationContext = notificationContext;
        }

        public async Task<FiltrarFornecedorPorIdQueryResponse> Handle(FiltrarFornecedorPorIdQuery request, CancellationToken cancellationToken)
        {
            var fornecedor = await _fornecedorQueryStore.FiltrarFornecedorPeloId(Guid.Parse(request.Id));

            if (fornecedor is null)
            {
                _notificationContext.AddNotification(new Notification(Mensagens.FornecedorNaoEncontraoTitulo, Mensagens.FornecedorNaoEncontradoTexto));
                return null;
            }

            return new FiltrarFornecedorPorIdQueryResponse()
            {
                Fornecedor = new FornecedoresResponse()
                {
                    Id = fornecedor.Id,
                    IdentificadorReceitaFederal = fornecedor.IdentificadorReceitaFederal,
                    Nome = fornecedor.Nome,
                    Empresa = new EmpresaResult()
                    {
                        Id = fornecedor.Empresa.Id,
                        CNPJ = fornecedor.Empresa.CNPJ,
                        NomeFantasia = fornecedor.Empresa.NomeFantasia,
                        UF = fornecedor.Empresa.UF.ToString()
                    },
                    DadosPessoais = fornecedor.DadosPessoais,
                    DataCadastro = fornecedor.DataCadastro
                }
            };
        }
    }
}