using MarcasAutosApi.Data;
using MarcasAutosApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasAutosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarcasAutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MarcasAutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetMarcas()
        {
            var marcas = await _context.MarcasAutos.ToListAsync();
            return Ok(marcas);
        }

        // GET: api/MarcasAutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaAuto>> GetMarca(int id)
        {
            var marca = await _context.MarcasAutos.FindAsync(id);
            if (marca == null)
                return NotFound();

            return Ok(marca);
        }

        // POST: api/MarcasAutos
        [HttpPost]
        public async Task<ActionResult<MarcaAuto>> CreateMarca(MarcaAuto nuevaMarca)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.MarcasAutos.Add(nuevaMarca);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMarca), new { id = nuevaMarca.Id }, nuevaMarca);
        }


        // DELETE: api/MarcasAutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _context.MarcasAutos.FindAsync(id);
            if (marca == null)
                return NotFound();

            _context.MarcasAutos.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
