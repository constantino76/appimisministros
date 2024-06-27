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
        public async Task<ActionResult<Oferente>> GetOferente(String id)

        // en este caso quitar el await 
        {  //Oferente oferente = await _context.TbOferente.Include(e=>e.list_Experiencia_laboral).Include(e=>e.titulos).Where(e=>e.OferenteId==id).Single();

            Oferente oferente =  _context.TbOferente.Include(e => e.list_Experiencia_laboral).Include(e => e.titulos).Where(e => e.OferenteId == id).Single();



            if (oferente == null)
            {
                return null;
            }
           

            return oferente;
        }

        // PUT: api/Oferentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOferente(string id, Oferente oferente)
        {
            var OferenteUpdate = _context.TbOferente.Include(e => e.list_Experiencia_laboral).Include(e => e.titulos).FirstOrDefault(e => e.OferenteId== id);
            
            
            
            if (OferenteUpdate == null)
            {
                return BadRequest();
            }

       

            try
            {

                //Actualizando datos del oferente
                //OferenteUpdate.Telefono = oferente.Telefono;
                //OferenteUpdate.Nombre = oferente.Nombre;
                //OferenteUpdate.Telefono = oferente.Telefono;
                //OferenteUpdate.Email = oferente.Email;
                //OferenteUpdate.FechaNacimiento = oferente.FechaNacimiento;
                //OferenteUpdate.Puesto = oferente.Puesto;


                //limpiamos la lista de titulos  de la base de datos;
                OferenteUpdate.titulos.Clear();
                OferenteUpdate.list_Experiencia_laboral.Clear();


                OferenteUpdate.titulos = oferente.titulos;
                OferenteUpdate.list_Experiencia_laboral = oferente.list_Experiencia_laboral;

                ////Actualizar datos de los titulos 
                //foreach (var n in oferente.titulos) {
                //    OferenteUpdate.titulos.Add(n);
                
                //}
                ////Actualizar los datos de los atestados academicos

                //foreach (var n in oferente.list_Experiencia_laboral)
                //{
                //    OferenteUpdate.list_Experiencia_laboral.Add(n);

                //}

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
