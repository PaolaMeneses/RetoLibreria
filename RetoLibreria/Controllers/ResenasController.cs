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
    public class ResenasController : ControllerBase
    {
        private readonly DataContext _context;

        public ResenasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Resenas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resena>>> GetResenas()
        {
          if (_context.Resenas == null)
          {
              return NotFound();
          }
            return await _context.Resenas.ToListAsync();
        }

        // GET: api/Resenas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resena>> GetResena(int id)
        {
          if (_context.Resenas == null)
          {
              return NotFound();
          }
            var resena = await _context.Resenas.FindAsync(id);

            if (resena == null)
            {
                return NotFound();
            }

            return resena;
        }

        // PUT: api/Resenas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResena(int id, Resena resena)
        {
            if (id != resena.Id)
            {
                return BadRequest();
            }

            _context.Entry(resena).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResenaExists(id))
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

        // POST: api/Resenas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resena>> PostResena(Resena resena)
        {
          if (_context.Resenas == null)
          {
              return Problem("Entity set 'DataContext.Resenas'  is null.");
          }
            _context.Resenas.Add(resena);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResena", new { id = resena.Id }, resena);
        }

        // DELETE: api/Resenas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResena(int id)
        {
            if (_context.Resenas == null)
            {
                return NotFound();
            }
            var resena = await _context.Resenas.FindAsync(id);
            if (resena == null)
            {
                return NotFound();
            }

            _context.Resenas.Remove(resena);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResenaExists(int id)
        {
            return (_context.Resenas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
