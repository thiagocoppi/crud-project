using Application.Commands.Fornecedores.Create.Models;
using Domain.Empresas;
using Domain.Fornecedores;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Fornecedores.Create
{
    public sealed class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, CreateFornecedorCommandResult>
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IEmpresaQueryStore _empresaQueryStore;

        public CreateFornecedorCommandHandler(IFornecedorService fornecedorService, IEmpresaQueryStore empresaQueryStore)
        {
            _fornecedorService = fornecedorService;
            _empresaQueryStore = empresaQueryStore;
        }

        public async Task<CreateFornecedorCommandResult> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaQueryStore.ObterEmpresaPeloId(Guid.Parse(request.EmpresaId));

            var fornecedorCadastrado = await _fornecedorService.Cadastrar(new Fornecedor(empresa, request.Nome, request.DataCadastro,
                request.DadosPessoais, request.IdentificadorReceitaFederal));

            return new CreateFornecedorCommandResult()
            {
                DadosPessoais = fornecedorCadastrado.DadosPessoais,
                DataCadastro = fornecedorCadastrado.DataCadastro,
                Empresa = new EmpresaResult()
                {
                    CNPJ = fornecedorCadastrado.Empresa.CNPJ,
                    NomeFantasia = fornecedorCadastrado.Empresa.NomeFantasia,
                    UF = fornecedorCadastrado.Empresa.UF
                },
                Nome = fornecedorCadastrado.Nome
            };
        }
    }
}