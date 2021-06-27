using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleHorasColaborador.Context;
using ControleHorasColaborador.Model;

namespace ControleHorasColaborador.Controllers
{
    [Route("Operacao/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public ColaboradorController(ControleHorasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradores()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(long id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return colaborador;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaborador(long id, Colaborador colaborador)
        {
            if (id != colaborador.colaboradorId)
            {
                return BadRequest();
            }

            _context.Entry(colaborador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColaborador", new { id = colaborador.colaboradorId }, colaborador);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Colaborador>> DeleteColaborador(long id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            _context.Colaboradores.Remove(colaborador);
            await _context.SaveChangesAsync();

            return colaborador;
        }

        private bool ColaboradorExists(long id)
        {
            return _context.Colaboradores.Any(e => e.colaboradorId == id);
        }
    }
}
