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
    public class OferentesController : ControllerBase
    {
        private readonly Oferente_DbContext _context;

        public OferentesController(Oferente_DbContext context)
        {
            _context = context;
        }

        // GET: api/Oferentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oferente>>> GetTbOferente()
        {
            return await _context.TbOferente.Include(e=>e.list_Experiencia_laboral).Include(e=>e.titulos).ToListAsync();
        }

        // GET: api/Oferentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oferente>> GetOferente(string id)
        {
            var oferente = await _context.TbOferente.FindAsync(id);

            if (oferente == null)
            {
                return NotFound();
            }

            return oferente;
        }

        // PUT: api/Oferentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOferente(string id, Oferente oferente)
        {
            if (id != oferente.OferenteId)
            {
                return BadRequest();
            }

            _context.Entry(oferente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OferenteExists(id))
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

        // POST: api/Oferentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oferente>> PostOferente(Oferente oferente)
        {
            _context.TbOferente.Add(oferente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OferenteExists(oferente.OferenteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOferente", new { id = oferente.OferenteId }, oferente);
        }

        // DELETE: api/Oferentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOferente(string id)
        {
            var oferente = await _context.TbOferente.FindAsync(id);
            if (oferente == null)
            {
                return NotFound();
            }

            _context.TbOferente.Remove(oferente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OferenteExists(string id)
        {
            return _context.TbOferente.Any(e => e.OferenteId == id);
        }
    }
}
