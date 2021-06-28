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
    public class ColaboradorController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public ColaboradorController(ControleHorasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os colaboradores cadastrados
        /// </summary>
        [ActionName("GetAllColaboradores")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradores()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        /// <summary>
        /// Retorna os dados de um colaborador pelo ID dele
        /// </summary>
        [ActionName("GetColaboradorById")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(long id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound("O Colaborador com o id informado não foi encontrado");
            }

            return colaborador;
        }

        /// <summary>
        /// Adiciona um novo colaborador
        /// </summary>
        [ActionName("AdicionarColaborador")]
        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
                _context.Colaboradores.Add(colaborador);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AdicionarColaborador", new { id = colaborador.ColaboradorId }, colaborador);

        }

        /// <summary>
        /// Remove um colaborador
        /// </summary>
        [ActionName("RemoverColaborador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Colaborador>> DeleteColaborador(long id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound("O Colaborador com o id informado não foi encontrado");
            }

            if (ColaboradorEstaEmEquipe(id))
            {
                return Conflict("Este colaborador está associado á uma equipe, não è possível remove-lo");
            }
            else
            {
                _context.Colaboradores.Remove(colaborador);

                await _context.SaveChangesAsync();

                return colaborador;
            }
        }

        private bool ColaboradorEstaEmEquipe(long id)
        {
            return _context.EquipeColaborador.Where(ec => ec.ColaboradorId == id).FirstOrDefault() != null;
        }
    }
}
