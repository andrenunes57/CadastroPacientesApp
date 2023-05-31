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
                return Ok(await context.Convenios.ToListAsync());
            }
            catch
            {
                return StatusCode(500, new { StatusCode500 = "ERRX45 - Falha interna no servidor" });
            }
        }

        [HttpGet("v1/convenios/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] DataContext context)
        {
            try
            {
                var convenio = await context.Convenios.FirstOrDefaultAsync(x => x.Id == id);

                if (convenio == null)
                    return NotFound(new { StatusCode404 = "Conteúdo não encontrado" });

                return Ok(convenio);
            }
            catch
            {
                return StatusCode(500, new { StatusCode500 = "ERRX50 - Falha interna no servidor" });
            }
        }
    }
}