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

        /// <summary>
        /// Realiza a associação de um projeto com uma equipe
        /// </summary>
        /// <response code ="200" >Retorna a nova associação </response>
        /// <response code="404">Se o projeto ou a equipe não forem encontrados</response>
        /// <param name="projetoModel"></param>
        [ActionName("AssociarProjetoEquipe")]
        [HttpPut]
        public async Task<ActionResult<Projeto>> AssociarProjetoEquipe(ProjetoEquipeRequestModel projetoModel)
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

        /// <summary>
        /// Realiza a desassosiação de um projeto de uma equipe
        /// </summary>
        /// <remarks>
        /// Request de exemplo:
        ///
        ///     POST 
        ///     {
        ///       "EquipeId":5, 
        ///       "ProjetoId":4   
        ///     }
        ///
        /// </remarks>
        /// <response code ="200" >Retorna o Projeto Desassociado</response>
        /// <response code="404">Se o projeto ou a equipe não forem encontrados</response>
        /// <param name="projetoModel"></param>
        [ActionName("DesassociarProjetoEquipe")]
        [HttpPut]
        public async Task<ActionResult<Projeto>> DesassociarProjetoEquipe(ProjetoEquipeRequestModel projetoModel)
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
