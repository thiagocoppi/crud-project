using Application.Commands.Empresas.Create;
using Application.Commands.Empresas.Update;
using Application.Queries.Empresas.FindById;
using Application.Queries.Empresas.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class EmpresaController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateEmpresaCommand command)
        {
            var createEmpresaResult = await Mediator.Send(command);

            return Ok(createEmpresaResult);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] UpdateEmpresaCommand command)
        {
            var updateEmpresaResult = await Mediator.Send(command);

            return Ok(updateEmpresaResult);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var listarTodasEmpresas = await Mediator.Send(new ObterTodasEmpresasQueryRequest());
            return Ok(listarTodasEmpresas);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Listar([FromRoute] string id)
        {
            var empresaEncontrada = await Mediator.Send(new EmpresaFindByIdQuery() { Id = Guid.Parse(id) });
            return Ok(empresaEncontrada);
        }
    }
}