using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica2.Models;

namespace PruebaTecnica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosnegociosController : ControllerBase
    {
        private readonly ApipruebatecnicaContext _context;

        public UsuariosnegociosController(ApipruebatecnicaContext context)
        {
            _context = context;
        }

        // GET: api/Usuariosnegocios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuariosnegocio>>> GetUsuariosnegocios()
        {
            return await _context.Usuariosnegocios.ToListAsync();
        }

        // GET: api/Usuariosnegocios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuariosnegocio>> GetUsuariosnegocio(int id)
        {
            var usuariosnegocio = await _context.Usuariosnegocios.FindAsync(id);

            if (usuariosnegocio == null)
            {
                return NotFound();
            }

            return usuariosnegocio;
        }

        // PUT: api/Usuariosnegocios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuariosnegocio(int id, Usuariosnegocio usuariosnegocio)
        {
            if (id != usuariosnegocio.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuariosnegocio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosnegocioExists(id))
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

        // POST: api/Usuariosnegocios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuariosnegocio>> PostUsuariosnegocio(Usuariosnegocio usuariosnegocio)
        {
            _context.Usuariosnegocios.Add(usuariosnegocio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuariosnegocio", new { id = usuariosnegocio.Id }, usuariosnegocio);
        }

        // DELETE: api/Usuariosnegocios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuariosnegocio(int id)
        {
            var usuariosnegocio = await _context.Usuariosnegocios.FindAsync(id);
            if (usuariosnegocio == null)
            {
                return NotFound();
            }

            _context.Usuariosnegocios.Remove(usuariosnegocio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosnegocioExists(int id)
        {
            return _context.Usuariosnegocios.Any(e => e.Id == id);
        }
    }
}
