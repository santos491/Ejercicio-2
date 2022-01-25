using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas_API.AplicacionDBContext;
using Peliculas_API.Entidad;

namespace Peliculas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly ConexionBD _context;

        public PeliculasController(ConexionBD context)
        {
            _context = context;
        }

        // GET: api/Peliculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatosPeliculas>>> GetBaseDatosPeliculas()
        {
            return await _context.BaseDatosPeliculas.ToListAsync();
        }

        // GET: api/Peliculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatosPeliculas>> GetDatosPeliculas(int id)
        {
            var datosPeliculas = await _context.BaseDatosPeliculas.FindAsync(id);

            if (datosPeliculas == null)
            {
                return NotFound();
            }

            return datosPeliculas;
        }

        // PUT: api/Peliculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatosPeliculas(int id, DatosPeliculas datosPeliculas)
        {
            if (id != datosPeliculas.ID)
            {
                return BadRequest();
            }

            _context.Entry(datosPeliculas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatosPeliculasExists(id))
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

        // POST: api/Peliculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DatosPeliculas>> PostDatosPeliculas(DatosPeliculas datosPeliculas)
        {
            _context.BaseDatosPeliculas.Add(datosPeliculas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatosPeliculas", new { id = datosPeliculas.ID }, datosPeliculas);
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatosPeliculas(int id)
        {
            var datosPeliculas = await _context.BaseDatosPeliculas.FindAsync(id);
            if (datosPeliculas == null)
            {
                return NotFound();
            }

            _context.BaseDatosPeliculas.Remove(datosPeliculas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatosPeliculasExists(int id)
        {
            return _context.BaseDatosPeliculas.Any(e => e.ID == id);
        }
    }
}
