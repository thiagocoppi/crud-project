using Canonico.Enderecos;
using Canonico.ReceitaFederal;
using Domain.Base;
using Domain.Empresas;
using Languages;
using System.Threading.Tasks;

namespace Domain.Fornecedores
{
    public sealed class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorCommandStore _fornecedorCommandStore;
        private readonly IEmpresaQueryStore _empresaQueryStore;
        private readonly INotificationContext _notificationContext;

        public FornecedorService(IFornecedorCommandStore fornecedorCommandStore, IEmpresaQueryStore empresaQueryStore, INotificationContext notificationContext)
        {
            _fornecedorCommandStore = fornecedorCommandStore;
            _empresaQueryStore = empresaQueryStore;
            _notificationContext = notificationContext;
        }

        public async Task<Fornecedor> Atualizar(Fornecedor fornecedor)
        {
            var podeRealizarCadastro = PodeCadastrarNessaEmpresa(fornecedor);

            if (!podeRealizarCadastro)
            {
                return fornecedor;
            }

            _ = await _fornecedorCommandStore.Atualizar(fornecedor);
            return fornecedor;
        }

        public async Task<Fornecedor> Cadastrar(Fornecedor fornecedor)
        {
            var podeRealizarCadastro = PodeCadastrarNessaEmpresa(fornecedor);

            if (!podeRealizarCadastro)
            {
                return fornecedor;
            }

            _ = await _fornecedorCommandStore.Cadastrar(fornecedor);
            return fornecedor;
        }

        private bool PodeCadastrarNessaEmpresa(Fornecedor fornecedor)
        {
            if (fornecedor.IdentificadorReceitaFederal.IsCPF() && fornecedor.Empresa.UF == EnumUF.PR && fornecedor.DadosPessoais.Idade < 18)
            {
                _notificationContext.AddNotification(new Notification(Mensagens.FornecedorMenorIdadePRTitulo, Mensagens.FornecedorMenorIdadePRTexto));
                return false;
            }

            return true;
        }
    }
}