using Application.Commands.Fornecedores.Create;
using Application.Commands.Fornecedores.Delete;
using Application.Commands.Fornecedores.Update;
using Application.Queries.Fornecedores;
using Application.Queries.Fornecedores.FiltrarFornecedorPorId;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class FornecedorController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateFornecedorCommand command)
        {
            var createFornecedorResult = await Mediator.Send(command);

            return Ok(createFornecedorResult);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] UpdateFornecedorCommand command)
        {
            var updateFornecedorResult = await Mediator.Send(command);

            return Ok(updateFornecedorResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remover([FromRoute] string id)
        {
            var deleteFornecedorResult = await Mediator.Send(new DeleteFornecedorCommand() { Id = Guid.Parse(id) });

            return Ok(deleteFornecedorResult);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            var listaFornecedoresQueryResult = await Mediator.Send(new FiltrarFornecedoresQueryRequest());

            return Ok(listaFornecedoresQueryResult);
        }

        [HttpGet]
        [Route("filtrar")]
        public async Task<IActionResult> Listar([FromBody] FiltrarFornecedoresQueryRequest query)
        {
            var listaFornecedoresQueryResult = await Mediator.Send(query);

            return Ok(listaFornecedoresQueryResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarPeloId([FromRoute] string id)
        {
            var listaFornecedoresQueryResult = await Mediator.Send(new FiltrarFornecedorPorIdQuery() { Id = id });

            return Ok(listaFornecedoresQueryResult);
        }
    }
}