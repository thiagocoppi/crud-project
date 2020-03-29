using Domain.Base;
using Domain.Fornecedores;
using Languages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Fornecedores.Delete
{
    public sealed class DeleteFornecedorCommandHandler : IRequestHandler<DeleteFornecedorCommand>
    {
        private IFornecedorCommandStore _fornecedorCommandStore;
        private readonly INotificationContext _notificationContext;

        public DeleteFornecedorCommandHandler(IFornecedorCommandStore fornecedorCommandStore, INotificationContext notificationContext)
        {
            _fornecedorCommandStore = fornecedorCommandStore;
            _notificationContext = notificationContext;
        }

        public async Task<Unit> Handle(DeleteFornecedorCommand request, CancellationToken cancellationToken)
        {
            var removido = await _fornecedorCommandStore.Remover(request.Id);

            //Caso não encontre o registro para realizar a exclusão adiciona uma notificação para exibir a mensagem de erro.
            if (!removido)
            {
                _notificationContext.AddNotification(Mensagens.ErroAoExcluirTitulo, string.Format(Mensagens.ErroAoExcluirTexto, request.Id.ToString()));
            }

            return Unit.Value;
        }
    }
}