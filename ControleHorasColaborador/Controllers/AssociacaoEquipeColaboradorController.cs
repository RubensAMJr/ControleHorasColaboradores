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

        /// <summary>
        /// Retorna todas as associacções de colaboradores e equipes
        /// </summary>
        /// <response code="200">Retorna todos os colaboradores e equipes</response>
        [ActionName("GetAllAssociacoes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipeColaborador>>> GetEquipeColaborador()
        {
            return await _context.EquipeColaborador.Include(e => e.Equipe)
                                                   .Include(c => c.Colaborador)
                                                   .ToListAsync();

        }

        /// <summary>
        /// Retorna todos os colaboradores da equipe informada
        /// </summary>
        /// <response code="200">Retorna os colaboradores da equipe informada</response>
        /// <response code="404">Se a equipe não foi encontrada</response>
        /// <param name="idEquipe"></param>
        [ActionName("GetColaboradoresDaEquipe")]
        [HttpGet("{idEquipe}")]
        public async Task<ActionResult<IEnumerable<EquipeColaborador>>> GetColaboradoresDaEquipe(long idEquipe)
        {
            var equipeColaborador = await _context.EquipeColaborador.Include(c => c.Colaborador)
                                                                    .Where(ec => ec.EquipeId == idEquipe)
                                                                    .ToListAsync();

            if (equipeColaborador == null)
                return NotFound("A Equipe informada não foi encontrada");

            return equipeColaborador;
        }

        /// <summary>
        /// Retorna todas as equipes do colaborador informado
        /// </summary>
        /// <response code ="200" > Retorna as equipes do colaborador</response>
        /// <response code="404">Se o colaborador não foi encontrada</response>
        /// <param name="idColaborador"></param>
        [ActionName("GetEquipesDoColaborador")]
        [HttpGet("{idColaborador}")]
        public async Task<ActionResult<IEnumerable<EquipeColaborador>>> GetEquipesDoColaborador(long idColaborador)
        {
            var equipeColaborador = await _context.EquipeColaborador.Include(e => e.Equipe)
                                                                    .Where(ec => ec.ColaboradorId == idColaborador)
                                                                    .ToListAsync();

            if (equipeColaborador == null)
                return NotFound("O Colaborador informado não foi encontrado");

            return equipeColaborador;
        }

        /// <summary>
        /// Realiza a associação do colaborador informado com a equipe informada
        /// </summary>
        /// <remarks>
        /// Request de exemplo:
        ///
        ///     POST 
        ///     {
        ///       "EquipeId":5, 
        ///       "ColaboradorId":4   
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna a nova associação criada</response>
        /// <response code="409">Se o colaborador já estiver ná equipe</response>
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

        /// <summary>
        /// Realiza a desasossiação do colaborador com a equipe
        /// </summary>
        /// <response code="200">Deleta a associação informada</response>
        /// <response code="404">Se a Assosiação não foi encontrada</response>
        /// <param name="id"></param>
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
