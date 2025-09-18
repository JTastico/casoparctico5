using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Casopractico.Models;

namespace Casopractico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IntereaccionesController : ControllerBase
    {
        private readonly ConsultoriaDbContext _context;

        public IntereaccionesController(ConsultoriaDbContext context)
        {
            _context = context;
        }

        // GET: api/Intereacciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interaccione>>> GetIntereacciones()
        {
            return await _context.Interacciones
                .Include(i => i.Proyecto)
                .Include(i => i.Usuario)
                .ToListAsync();
        }

        // GET: api/Intereacciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interaccione>> GetIntereaccion(int id)
        {
            var interaccion = await _context.Interacciones
                .Include(i => i.Proyecto)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(i => i.InteraccionId == id);

            if (interaccion == null)
                return NotFound();

            return interaccion;
        }

        // POST: api/Intereacciones
        [HttpPost]
        public async Task<ActionResult<Interaccione>> PostIntereaccion(Interaccione interaccion)
        {
            _context.Interacciones.Add(interaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIntereaccion), new { id = interaccion.InteraccionId }, interaccion);
        }

        // PUT: api/Intereacciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntereaccion(int id, Interaccione interaccion)
        {
            if (id != interaccion.InteraccionId)
                return BadRequest();

            _context.Entry(interaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Interacciones.Any(e => e.InteraccionId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Intereacciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntereaccion(int id)
        {
            var interaccion = await _context.Interacciones.FindAsync(id);
            if (interaccion == null)
                return NotFound();

            _context.Interacciones.Remove(interaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
