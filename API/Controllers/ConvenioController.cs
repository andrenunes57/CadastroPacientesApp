using API.Data;
using API.Entities;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        [HttpGet("v1/convenios")]
        public async Task<IActionResult> GetAsync([FromServices] DataContext context)
        {
            try 
            {
                var convenios = await context.Convenios.ToListAsync();
                return Ok(new ResultViewModel<List<Convenio>>(convenios));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Convenio>>("ERRX45 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/convenios/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] DataContext context)
        {
            try 
            {
                var convenio = await context.Convenios.FirstOrDefaultAsync(x => x.Id == id);

                if (convenio == null)
                    return NotFound(new ResultViewModel<Paciente>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Convenio>(convenio));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Paciente>>("ERRX50 - Falha interna no servidor"));
            }
        }
    }
}