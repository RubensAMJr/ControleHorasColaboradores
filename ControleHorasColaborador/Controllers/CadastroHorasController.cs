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
    [Route("ControleHoras/[action]")]
    [ApiController]
    public class CadastroHorasController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public CadastroHorasController(ControleHorasContext context)
        {
            _context = context;
        }

        [ActionName("CadastrarHoraProjeto")]
        [HttpPut]
        public async Task<ActionResult<Projeto>> CadastrarHoraProjeto(CadastroHorasRequestModel requestModel)
        {
            var projeto = await _context.Projetos.Include(p => p.Equipe)
                                                 .Where(p => p.ProjetoId == requestModel.ProjetoId)
                                                 .FirstOrDefaultAsync();

            if (projeto == null)
                return NotFound("O projeto com o id informado não foi encontrado");
            else if (projeto.Equipe == null)
                return NotFound("O projeto informado não possui uma equipe associada a ele");

            var equipe = await _context.Equipes.FindAsync(projeto.Equipe.EquipeId);

            projeto.HorasTrabalhadasProjeto = requestModel.QuantidadeHoras;
            _context.Entry(projeto).State = EntityState.Modified;

            equipe.HorasTrabalhadasProjeto  = requestModel.QuantidadeHoras;
            _context.Entry(equipe).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return projeto;
        }

        [ActionName("ConsultarHorasProjeto")]
        [HttpGet("{idProjeto}")]
        public async Task<ActionResult> ConsultarHorasProjeto(long idProjeto)
        {
            var projeto = await _context.Projetos.FindAsync(idProjeto);

            if (projeto == null)
                return NotFound("O projeto informado não foi encontrado");

            return new JsonResult(new CadastroHorasResponseModel(projeto.ProjetoId,projeto.NomeProjeto,projeto.HorasTrabalhadasProjeto));
        }

        [ActionName("ConsultarHorasEquipe")]
        [HttpGet("{idEquipe}")]
        public async Task<ActionResult> GetEquipeColaboradorByEquipe(long idEquipe)
        {
            var equipe = await _context.Equipes.FindAsync(idEquipe);

            if (equipe == null)
                return NotFound("A Equipe informada não foi encontrada");

            return new JsonResult(new CadastroHorasResponseModel(equipe.EquipeId, equipe.NomeEquipe, equipe.HorasTrabalhadasProjeto));
        }
    }
}
