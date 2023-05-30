using API.Data;
using API.Entities;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    public class PacienteController : ControllerBase
    {
        // private readonly DataContext _context;
        // public PacienteController(DataContext context)
        // {
        //     _context = context;
        // }

        [HttpGet("v1/pacientes")]
        public async Task<IActionResult> GetAsync([FromServices] DataContext context)
        {
            try
            {
                var pacientes = await context.Pacientes.ToListAsync();
                return Ok(new ResultViewModel<List<Paciente>>(pacientes));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Paciente>>("ERRX10 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/pacientes/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] DataContext context)
        {
            try
            {
                var paciente = await context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);

                if (paciente == null)
                    return NotFound(new ResultViewModel<Paciente>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Paciente>(paciente));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Paciente>>("ERRX15 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/pacientes/{name}")]
        public async Task<IActionResult> GetByNameAsync([FromRoute] string name, [FromServices] DataContext context)
        {
            try
            {
                // This will bring a list that matches tha string inputed
                //var paciente = await context.Pacientes.Where(x => x.Nome.Contains(name)).ToListAsync();
                var paciente = await context.Pacientes.FirstOrDefaultAsync(x => x.Nome.Contains(name));

                if (paciente == null)
                    return NotFound(new ResultViewModel<Paciente>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Paciente>(paciente));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Paciente>>("ERRX20 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/pacientes")]
        public async Task<IActionResult> PostAsync([FromBody] EditorPacienteViewModel model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var paciente = new Paciente
                {
                    Id = 0,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    DataNascimento = model.DataNascimento,
                    Genero = model.Genero,
                    CPF = model.CPF,
                    RG = model.RG,
                    UfRG = model.UfRG,
                    Email = model.Email,
                    Celular = model.Celular,
                    Telefone = model.Telefone,
                    Carteirinha = model.Carteirinha,
                    CarteirinhaValidade = model.CarteirinhaValidade,
                    ConvenioId = model.ConvenioId
                };

                await context.Pacientes.AddAsync(paciente);
                await context.SaveChangesAsync();

                return Created($"v1/pacientes/{paciente.Id}", new ResultViewModel<Paciente>(paciente));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Paciente>("ERRX25 - Não foi possível incluir o paciente"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Paciente>("ERRX30 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/pacientes/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorPacienteViewModel model, [FromServices] DataContext context)
        {
            try
            {
                var paciente = await context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);

                if (paciente == null)
                    return NotFound(new ResultViewModel<Paciente>("Conteúdo não encontrado"));

                paciente.Nome = model.Nome;
                paciente.Sobrenome = model.Sobrenome;
                paciente.DataNascimento = model.DataNascimento;
                paciente.Genero = model.Genero;
                paciente.CPF = model.CPF;
                paciente.RG = model.RG;
                paciente.UfRG = model.UfRG;
                paciente.Email = model.Email;
                paciente.Celular = model.Celular;
                paciente.Telefone = model.Telefone;
                paciente.Carteirinha = model.Carteirinha;
                paciente.CarteirinhaValidade = model.CarteirinhaValidade;
                paciente.ConvenioId = model.ConvenioId;

                context.Pacientes.Update(paciente);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Paciente>(paciente));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Paciente>("ERRX35 - Não foi possível alterar a categoria"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Paciente>("ERRX40 - Falha interna no servidor"));
            }
        }
    }
}