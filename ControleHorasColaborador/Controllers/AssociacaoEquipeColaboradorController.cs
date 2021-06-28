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
    [Route("Associacao/[action]")]
    [ApiController]
    public class AssociacaoEquipeColaboradorController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public AssociacaoEquipeColaboradorController(ControleHorasContext context)
        {
            _context = context;
        }

        [ActionName("GetAllAssociacoes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipeColaborador>>> GetEquipeColaborador()
        {
            return await _context.EquipeColaborador.Include(e => e.Equipe)
                                                   .Include(c => c.Colaborador)
                                                   .ToListAsync();

        }

        [ActionName("GetColaboradoresDaEquipe")]
        [HttpGet("{idEquipe}")]
        public async Task<ActionResult<IEnumerable<EquipeColaborador>>> GetEquipeColaboradorByEquipe(long idEquipe)
        {
            var equipeColaborador = await _context.EquipeColaborador.Include(c => c.Colaborador)
                                                                    .Where(ec => ec.EquipeId == idEquipe)
                                                                    .ToListAsync();

            if (equipeColaborador == null)
                return NotFound("A Equipe informada não foi encontrada");

            return equipeColaborador;
        }

        [ActionName("GetEquipesDoColaborador")]
        [HttpGet("{idColaborador}")]
        public async Task<ActionResult<IEnumerable<EquipeColaborador>>> GetEquipeColaboradorByColaborador(long idColaborador)
        {
            var equipeColaborador = await _context.EquipeColaborador.Include(e => e.Equipe)
                                                                    .Where(ec => ec.ColaboradorId == idColaborador)
                                                                    .ToListAsync();

            if (equipeColaborador == null)
                return NotFound("O Colaborador informado não foi encontrado");

            return equipeColaborador;
        }

        [ActionName("AssociarColaborador")]
        [HttpPost]
        public async Task<ActionResult<EquipeColaborador>> PostEquipeColaborador(EquipeColaborador equipeColaborador)
        {
            _context.EquipeColaborador.Add(equipeColaborador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipeColaboradorExists(equipeColaborador.ColaboradorId))
                    return Conflict("Este colaborador já está nessa equipe");
                else
                    throw;
            }

            return CreatedAtAction("GetAllEquipes", new { id = equipeColaborador.ColaboradorId }, equipeColaborador);
        }

        [ActionName("DesassociarColaboradorEquipe")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<EquipeColaborador>> DeleteEquipeColaborador(long id)
        {
            var equipeColaborador = await _context.EquipeColaborador.FindAsync(id);
            if (equipeColaborador == null)
                return NotFound("A Associação informada não foi encontrada");

            _context.EquipeColaborador.Remove(equipeColaborador);
            await _context.SaveChangesAsync();

            return equipeColaborador;
        }

        private bool EquipeColaboradorExists(long id)
        {
            return _context.EquipeColaborador.Any(e => e.ColaboradorId == id);
        }
    }
}
