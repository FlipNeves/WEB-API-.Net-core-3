using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Controlers
{
    [ApiController]
    [Route("system/clientes")]
    public class ClienteController : ControllerBase
    {

        //Rota autorizada para listagem de todos os itens cadastrados
        //localhost/system/clientes/
        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {
            var cliente = await context.Cliente.ToListAsync();
            return cliente;
        }

        //Rota autorizada para apresentação de item pelo ID
        //localhost/system/clientes/ID desejado
        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> GetByID([FromServices] DataContext context, int id)
        {
            var cliente = await context.Cliente.FirstOrDefaultAsync(x => x.ID == id);
            return cliente;
        }

        //Rota autorizada para apresentação de item pela UF
        //localhost/system/clientes/UF desejada
        [HttpGet]
        [Authorize]
        [Route("{uf}")]
        public async Task<ActionResult<List<Cliente>>> GetByUF([FromServices] DataContext context, string uf)
        {
            var cliente = await context.Cliente.Where(x => x.UF.Equals(uf)).ToListAsync();
            return cliente;
        }

        //Rota autorizada para a postagem de um item com dados em JSON
        //localhost/system/clientes/
        [HttpPost]
        [Authorize]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post(
            [FromServices] DataContext context,
            [FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Cliente.Add(model);
                await context.SaveChangesAsync();
                return Ok("Salvo com sucesso!");
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //Rota autorizada para a alteração de um item pelo ID
        //lovalhost/system/clientes/ ID desejado
        [HttpPut()]
        [Authorize]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Put([FromServices] DataContext context, [FromBody] Cliente model
            , int id)
        {
            var cliente = await context.Cliente.FirstOrDefaultAsync(x => x.ID == id);

            context.Entry(cliente).State = EntityState.Modified;

            cliente.Nome = model.Nome;
            cliente.CPF = model.CPF;
            cliente.Data = model.Data;
            cliente.UF = model.UF;

            context.Cliente.Update(cliente);
            
            await context.SaveChangesAsync();
            

            return  cliente;
        }
        


        //Rota autorizada para deletar um item atraves do ID
        //localhost/system/clientes/ ID desejado
        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> DeletByID([FromServices] DataContext context
            , [FromBody] Cliente model
            , int id)
        {
            var deleteID = await context.Cliente.FindAsync(id);
            if (deleteID == null)
            {
                return NotFound();
            }
            context.Cliente.Remove(deleteID);
            await context.SaveChangesAsync();

            return model;
        }

    }
}
