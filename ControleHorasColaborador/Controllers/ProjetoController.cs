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
    public class ProjetoController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public ProjetoController(ControleHorasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjeto(long id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return projeto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(long id, Projeto projeto)
        {
            if (id != projeto.projetoId)
            {
                return BadRequest();
            }

            _context.Entry(projeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(id))
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
        public async Task<ActionResult<Projeto>> PostProjeto(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjeto", new { id = projeto.projetoId }, projeto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Projeto>> DeleteProjeto(long id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return projeto;
        }

        private bool ProjetoExists(long id)
        {
            return _context.Projetos.Any(e => e.projetoId == id);
        }
    }
}
