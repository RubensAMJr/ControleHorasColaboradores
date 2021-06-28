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
    [Route("Gestao/[action]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public ProjetoController(ControleHorasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os projetos
        /// </summary>
        [ActionName("GetAllProjetos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _context.Projetos.Include(p => p.Equipe)
                                          .ToListAsync();
        }

        /// <summary>
        /// Retorna o projeto informado
        /// </summary>
        [ActionName("GetProjetoById")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjeto(long id)
        {
            var projeto = await _context.Projetos.Include(p => p.Equipe)
                                                 .FirstOrDefaultAsync();

            if (projeto == null)
            {
                return NotFound("O projeto com o Id informado não foi encontrado");
            }

            return projeto;
        }

        /// <summary>
        /// Adiciona um novo projeto
        /// </summary>
        [ActionName("AdicionarProjeto")]
        [HttpPost]
        public async Task<ActionResult<Projeto>> PostProjeto(Projeto projeto)
        {
            _context.Projetos.Add(projeto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjetoExists(projeto.ProjetoId))
                    return Conflict("Um projeto com o nome informado já existe.");
                else
                    throw;
            }

            return CreatedAtAction("AdicionarProjeto", new { id = projeto.ProjetoId }, projeto);
        }

        /// <summary>
        /// Deleta o projeto informado
        /// </summary>
        [ActionName("ApagarProjeto")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projeto>> DeleteProjeto(long id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound("O projeto com o Id informado não foi encontrado");
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return projeto;
        }

        private bool ProjetoExists(long projetoId)
        {
            return _context.Projetos.Any(p => p.ProjetoId == projetoId);
        }
    }
}
