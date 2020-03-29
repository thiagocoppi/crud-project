using Application.Queries.Empresas.Models;
using Domain.Base;
using Domain.Empresas;
using Languages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Empresas.FindById
{
    public sealed class EmpresaFindByIdQueryHandler : IRequestHandler<EmpresaFindByIdQuery, EmpresaFindByIdQueryResult>
    {
        private readonly IEmpresaQueryStore _empresaQueryStore;
        private readonly INotificationContext _notificationContext;

        public EmpresaFindByIdQueryHandler(IEmpresaQueryStore empresaQueryStore, INotificationContext notificationContext)
        {
            _empresaQueryStore = empresaQueryStore;
            _notificationContext = notificationContext;
        }

        public async Task<EmpresaFindByIdQueryResult> Handle(EmpresaFindByIdQuery request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaQueryStore.ObterEmpresaPeloId(request.Id);

            if (empresa is null)
            {
                _notificationContext.AddNotification(new Notification(Mensagens.EmpresaNaoEncontradaTitulo, Mensagens.EmpresaNaoEncontradaTexto));
                return null;
            }

            return new EmpresaFindByIdQueryResult()
            {
                Empresa = new EmpresaResult()
                {
                    Id = empresa.Id,
                    CNPJ = empresa.CNPJ,
                    NomeFantasia = empresa.NomeFantasia,
                    UF = empresa.UF.ToString()
                }
            };
        }
    }
}