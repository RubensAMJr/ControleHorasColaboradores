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

        [ActionName("GetAllColaboradores")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradores()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        [ActionName("GetColaboradorById")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(long id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return colaborador;
        }

        [ActionName("AdicionarColaborador")]
        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
                _context.Colaboradores.Add(colaborador);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetColaborador", new { id = colaborador.ColaboradorId }, colaborador);

        }

        [ActionName("RemoverColaborador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Colaborador>> DeleteColaborador(long id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            _context.Colaboradores.Remove(colaborador);
            await _context.SaveChangesAsync();

            return colaborador;
        }

    }
}
