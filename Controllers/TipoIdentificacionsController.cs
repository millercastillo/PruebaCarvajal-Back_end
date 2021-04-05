using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_end;
using Back_end.Models;

namespace Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoIdentificacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoIdentificacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIdentificacion>>> GetTipoIdentificacion()
        {
            return await _context.TipoIdentificacion.ToListAsync();
        }

        // GET: api/TipoIdentificacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIdentificacion>> GetTipoIdentificacion(int id)
        {
            var tipoIdentificacion = await _context.TipoIdentificacion.FindAsync(id);

            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            return tipoIdentificacion;
        }

        // PUT: api/TipoIdentificacions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIdentificacion(int id, TipoIdentificacion tipoIdentificacion)
        {
            if (id != tipoIdentificacion.IdTipoIdentificacion)
            {
                return BadRequest();
            }

            _context.Entry(tipoIdentificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIdentificacionExists(id))
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

        // POST: api/TipoIdentificacions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoIdentificacion>> PostTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
        {
            _context.TipoIdentificacion.Add(tipoIdentificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoIdentificacion", new { id = tipoIdentificacion.IdTipoIdentificacion }, tipoIdentificacion);
        }

        // DELETE: api/TipoIdentificacions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoIdentificacion>> DeleteTipoIdentificacion(int id)
        {
            var tipoIdentificacion = await _context.TipoIdentificacion.FindAsync(id);
            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            _context.TipoIdentificacion.Remove(tipoIdentificacion);
            await _context.SaveChangesAsync();

            return tipoIdentificacion;
        }

        private bool TipoIdentificacionExists(int id)
        {
            return _context.TipoIdentificacion.Any(e => e.IdTipoIdentificacion == id);
        }
    }
}
