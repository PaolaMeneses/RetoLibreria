using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetoLibreria.Modelos;

namespace RetoLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionsController : ControllerBase
    {
        private readonly DataContext _context;

        public CalificacionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Calificacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacion>>> GetCalificaciones()
        {
          if (_context.Calificaciones == null)
          {
              return NotFound();
          }
            return await _context.Calificaciones.ToListAsync();
        }

        // GET: api/Calificacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacion>> GetCalificacion(int id)
        {
          if (_context.Calificaciones == null)
          {
              return NotFound();
          }
            var calificacion = await _context.Calificaciones.FindAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return calificacion;
        }

        // PUT: api/Calificacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacion(int id, Calificacion calificacion)
        {
            if (id != calificacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Calificacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calificacion>> PostCalificacion(Calificacion calificacion)
        {
          if (_context.Calificaciones == null)
          {
              return Problem("Entity set 'DataContext.Calificaciones'  is null.");
          }
            _context.Calificaciones.Add(calificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificacion", new { id = calificacion.Id }, calificacion);
        }

        // DELETE: api/Calificacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacion(int id)
        {
            if (_context.Calificaciones == null)
            {
                return NotFound();
            }
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            _context.Calificaciones.Remove(calificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificacionExists(int id)
        {
            return (_context.Calificaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
