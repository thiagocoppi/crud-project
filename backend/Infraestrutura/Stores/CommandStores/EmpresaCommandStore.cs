using Domain.Empresas;
using System.Threading.Tasks;

namespace Infraestrutura.Stores.CommandStores
{
    public sealed class EmpresaCommandStore : IEmpresaCommandStore
    {
        private readonly ICrudContext _crudContext;

        public EmpresaCommandStore(ICrudContext crudContext)
        {
            _crudContext = crudContext;
        }

        public async Task<Empresa> AtualizarEmpresa(Empresa empresa)
        {
            var empresaPreAtualizacao = await _crudContext.Empresa.FindAsync(empresa.Id);

            empresaPreAtualizacao.CNPJ = empresa.CNPJ;
            empresaPreAtualizacao.NomeFantasia = empresa.NomeFantasia;
            empresaPreAtualizacao.UF = empresa.UF;

            _crudContext.Empresa.Update(empresaPreAtualizacao);
            _ = _crudContext.SaveChangesAsync();

            return empresaPreAtualizacao;
        }

        public async Task<Empresa> Cadastrar(Empresa empresa)
        {
            _crudContext.Empresa.Add(empresa);
            _ = await _crudContext.SaveChangesAsync();
            return empresa;
        }
    }
}