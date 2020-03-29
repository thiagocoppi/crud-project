using Domain.Fornecedores;
using System;
using System.Threading.Tasks;

namespace Infraestrutura.Stores.CommandStores
{
    public sealed class FornecedorCommandStore : IFornecedorCommandStore
    {
        private readonly ICrudContext _crudContext;

        public FornecedorCommandStore(ICrudContext crudContext)
        {
            _crudContext = crudContext;
        }

        public async Task<Fornecedor> Atualizar(Fornecedor fornecedor)
        {
            var fornecedorPreAtualizacao = await _crudContext.Fornecedore.FindAsync(fornecedor.Id);

            fornecedorPreAtualizacao.DadosPessoais = fornecedor.DadosPessoais;
            fornecedorPreAtualizacao.DataCadastro = fornecedor.DataCadastro;
            fornecedorPreAtualizacao.Empresa = fornecedor.Empresa;
            fornecedorPreAtualizacao.IdentificadorReceitaFederal = fornecedor.IdentificadorReceitaFederal;
            fornecedorPreAtualizacao.Nome = fornecedor.Nome;

            _ = _crudContext.Fornecedore.Update(fornecedorPreAtualizacao);
            await _crudContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> Cadastrar(Fornecedor fornecedor)
        {
            _ = await _crudContext.Fornecedore.AddAsync(fornecedor);
            await _crudContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> Remover(Guid id)
        {
            var fornecedor = await _crudContext.Fornecedore.FindAsync(id);

            if (fornecedor is null)
            {
                return false;
            }

            _crudContext.Fornecedore.Remove(fornecedor);
            await _crudContext.SaveChangesAsync();
            
            return true;
        }
    }
}