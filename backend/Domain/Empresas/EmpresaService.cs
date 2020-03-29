using System.Threading.Tasks;

namespace Domain.Empresas
{
    public sealed class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaCommandStore _empresaCommandStore;

        public EmpresaService(IEmpresaCommandStore empresaCommandStore)
        {
            _empresaCommandStore = empresaCommandStore;
        }

        public async Task<Empresa> AtualizarAsync(Empresa empresa)
        {
            _ = await _empresaCommandStore.AtualizarEmpresa(empresa);

            return empresa;
        }

        public async Task<Empresa> CadastrarAsync(Empresa empresa)
        {
            _ = await _empresaCommandStore.Cadastrar(empresa);
            return empresa;
        }
    }
}