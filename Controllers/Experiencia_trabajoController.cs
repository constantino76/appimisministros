using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppiMinistros.Data;
using AppiMinistros.Models;

namespace AppiMinistros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Experiencia_trabajoController : ControllerBase
    {
        private readonly Oferente_DbContext _context;

        public Experiencia_trabajoController(Oferente_DbContext context)
        {
            _context = context;
        }

        // GET: api/Experiencia_trabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experiencia_trabajo>>> GetTbExpLaboral()
        {
            return await _context.TbExpLaboral.ToListAsync();
        }

        // GET: api/Experiencia_trabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experiencia_trabajo>> GetExperiencia_trabajo(int id)
        {
            var experiencia_trabajo = await _context.TbExpLaboral.FindAsync(id);

            if (experiencia_trabajo == null)
            {
                return NotFound();
            }

            return experiencia_trabajo;
        }

        // PUT: api/Experiencia_trabajo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperiencia_trabajo(int id, Experiencia_trabajo experiencia_trabajo)
        {
            if (id != experiencia_trabajo.Idtrabajo)
            {
                return BadRequest();
            }

            _context.Entry(experiencia_trabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Experiencia_trabajoExists(id))
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

        // POST: api/Experiencia_trabajo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Experiencia_trabajo>> PostExperiencia_trabajo(Experiencia_trabajo experiencia_trabajo)
        {
            _context.TbExpLaboral.Add(experiencia_trabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperiencia_trabajo", new { id = experiencia_trabajo.Idtrabajo }, experiencia_trabajo);
        }

        // DELETE: api/Experiencia_trabajo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperiencia_trabajo(int id)
        {
            var experiencia_trabajo = await _context.TbExpLaboral.FindAsync(id);
            if (experiencia_trabajo == null)
            {
                return NotFound();
            }

            _context.TbExpLaboral.Remove(experiencia_trabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Experiencia_trabajoExists(int id)
        {
            return _context.TbExpLaboral.Any(e => e.Idtrabajo == id);
        }
    }
}
