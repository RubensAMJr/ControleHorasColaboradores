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
    public class AssosiacaoProjetosController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public AssosiacaoProjetosController(ControleHorasContext context)
        {
            _context = context;
        }

        [ActionName("AssociarProjetoEquipe")]
        [HttpPut]
        public async Task<ActionResult<Projeto>> PutProjeto(ProjetoEquipeRequestModel projetoModel)
        {
            var projeto = _context.Projetos.Find(projetoModel.ProjetoId);
            var equipe  = _context.Equipes.Find(projetoModel.EquipeId);

            if (projeto == null)
                return NotFound("O projeto com o id informado não foi encontrado");

            else if (equipe == null)
                return NotFound("A Equipe com o id informado não foi encontrada");

            projeto.Equipe = equipe;
            _context.Entry(projeto).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return projeto;
        }

        [ActionName("DesassociarColaboradorEquipe")]
        [HttpPut]
        public async Task<ActionResult<Projeto>> DeleteProjeto(ProjetoEquipeRequestModel projetoModel)
        {
            var projeto = _context.Projetos.Where(p => p.ProjetoId == projetoModel.ProjetoId &&
                                                  p.Equipe.EquipeId == projetoModel.EquipeId)
                                            .FirstOrDefault();

            if (projeto == null)
                return NotFound("O projeto ou a equipe com o id informado não foi encontrado");

            projeto.Equipe = null;
            _context.Entry(projeto).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return projeto;
        }

        private bool ProjetoExists(long id)
        {
            return _context.Projetos.Any(p => p.ProjetoId == id);
        }
    }
}
