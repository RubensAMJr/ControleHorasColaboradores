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
    public class EquipeController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public EquipeController(ControleHorasContext context)
        {
            _context = context;
        }

        [ActionName("GetAllEquipes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipe>>> GetEquipes()
        {
            return await _context.Equipes.ToListAsync();
        }

        [ActionName("GetAllEquipesById")]
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

        [ActionName("AdicionarEquipe")]
        [HttpPost]
        public async Task<ActionResult<Equipe>> PostEquipe(Equipe equipe)
        {
            _context.Equipes.Add(equipe);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipeExists(equipe.NomeEquipe))
                    return Conflict("Uma equipe com o nome informado já existe.");
                else
                    throw;
            }

            return CreatedAtAction("AdicionarEquipe", new { id = equipe.EquipeId }, equipe);
        }

        [ActionName("RemoverEquipe")]
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

        private bool EquipeExists(string nomeEquipe)
        {
            return _context.Equipes.Any(e => e.NomeEquipe == nomeEquipe);
        }




    }
}
