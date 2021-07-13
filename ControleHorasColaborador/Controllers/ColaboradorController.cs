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
        /// <response code="200">Retorna uma lista com todos os colaboradores</response>
        [ActionName("GetColaborador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaborador()
        {
			try
			{
				return await _context.Colaboradores.ToListAsync();
			}
			catch (Exception e)
			{
				throw new Exception($"Erro ao retornar os colaboradores: {e.Message}",e);
			}
        }

        /// <summary>
        /// Retorna os dados de um colaborador pelo ID dele
        /// </summary>
        /// <param name="idColaborador"></param>
        /// <response code="200">Retorna o colaborador com o Id informado</response>
        [ActionName("GetColaborador")]
        [HttpGet("{idColaborador}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(long idColaborador)
        {
			try
			{
				var colaborador = await _context.Colaboradores.FindAsync(idColaborador);

				if (colaborador == null)
					return NotFound("O Colaborador com o id informado não foi encontrado");

                return colaborador;
            }
			catch (Exception e)
			{
                throw new Exception($"Erro ao retornar o colaborador {idColaborador}: {e.Message}", e);
            }
        }

        /// <summary>
        /// Adiciona um novo colaborador
        /// </summary>
        /// <param name="colaborador">Colaborador a ser adicionado</param>
        [ActionName("AdicionarColaborador")]
        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
			try
			{
				_context.Colaboradores.Add(colaborador);
				await _context.SaveChangesAsync();

				return CreatedAtAction("AdicionarColaborador", new { id = colaborador.ColaboradorId }, colaborador);
			}
			catch (Exception e)
			{
                throw new Exception($"Erro ao adicionar o colaborador {colaborador.Nome}: {e.Message}", e);
            }
        }

        /// <summary>
        /// Altera os dados de um colaborador
        /// Example request:
        ///     PUT 
        ///     {
        ///       "ColaboradorId":10, 
        ///       "Nome":"John Doe"   
        ///     }
        /// </summary>
        [ActionName("AlterarColaborador")]
        [HttpPut]
        public async Task<ActionResult<Colaborador>> AlterarColaborador(ColaboradorRequestModel colaboradorRequest)
        {
			try
			{
				var colaborador = await _context.Colaboradores.FindAsync(colaboradorRequest.ColaboradorId);

				if (colaborador == null)
					return NotFound("O Colaborador com o id informado não foi encontrado");

				colaborador.Nome = colaboradorRequest.Nome;
				_context.Entry(colaborador).State = EntityState.Modified;

				await _context.SaveChangesAsync();

				return colaborador;
			}
			catch (Exception e)
			{
                throw new Exception($"Erro ao editar o colaborador {colaboradorRequest.Nome}: {e.Message}", e);
            }
        }

        /// <summary>
        /// Remove um colaborador
        /// </summary>
        /// <param name="idColaborador">Id do colaborador a ser removido</param>
        /// <response code="200">Colaborador removido com sucesso</response>
        /// <response code="404">Colaborador informado não foi encontrado</response>
        /// <response code="409">Colaborador informado está associado á uma equipe</response>
        [ActionName("RemoverColaborador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Colaborador>> DeleteColaborador(long idColaborador)
        {
			try
			{
				var colaborador = await _context.Colaboradores.FindAsync(idColaborador);

				if (colaborador == null)
					return NotFound("O Colaborador com o id informado não foi encontrado");

				if (ColaboradorEstaEmEquipe(idColaborador))
				{
					return Conflict("Este colaborador está associado á uma equipe, não è possível remove-lo");
				}
				else
				{
					_context.Colaboradores.Remove(colaborador);

					await _context.SaveChangesAsync();

					return Ok("Colaborador removido com sucesso");
				}
			}
			catch (Exception e)
			{
                throw new Exception($"Erro ao editar o colaborador {idColaborador}: {e.Message}", e);
            }
        }

        private bool ColaboradorEstaEmEquipe(long idColaborador)
        {
            return _context.EquipeColaborador.Where(ec => ec.ColaboradorId == idColaborador).FirstOrDefault() != null;
        }
    }
}
