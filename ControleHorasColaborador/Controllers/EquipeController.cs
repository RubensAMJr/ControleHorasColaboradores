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
    public class EquipeController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public EquipeController(ControleHorasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipe>>> GetEquipes()
        {
            return await _context.Equipes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetEquipe(long id)
        {
            var equipe = await _context.Equipes.FindAsync(id);

            if (equipe == null)
            {
                return NotFound();
            }

            return equipe;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipe(long id, Equipe equipe)
        {
            if (id != equipe.equipeId)
            {
                return BadRequest();
            }

            _context.Entry(equipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeExists(id))
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
        public async Task<ActionResult<Equipe>> PostEquipe(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipe", new { id = equipe.equipeId }, equipe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Equipe>> DeleteEquipe(long id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            _context.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();

            return equipe;
        }

        private bool EquipeExists(long id)
        {
            return _context.Equipes.Any(e => e.equipeId == id);
        }
    }
}
