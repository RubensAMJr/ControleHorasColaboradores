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
    public class GestorController : ControllerBase
    {
        private readonly ControleHorasContext _context;

        public GestorController(ControleHorasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os gestores
        /// </summary>
        [ActionName("GetAllGestores")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gestor>>> GetGestor()
        {
            return await _context.Gestor.ToListAsync();
        }

        /// <summary>
        /// Retorna o gestor pelo Id
        /// </summary>
        [ActionName("GetGestorById")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Gestor>> GetGestor(long id)
        {
            var gestor = await _context.Gestor.FindAsync(id);

            if (gestor == null)
            {
                return NotFound();
            }

            return gestor;
        }
        /// <summary>
        /// Adiciona um novo gestor
        /// </summary>
        [ActionName("AdicionarGestor")]
        [HttpPost]
        public async Task<ActionResult<Gestor>> PostGestor(Gestor gestor)
        {
            _context.Gestor.Add(gestor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AdicionarGestor", new { id = gestor.GestorId }, gestor);
        }

        /// <summary>
        /// Apaga o gestor informado
        /// </summary>
        [ActionName("ApagarGestor")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gestor>> DeleteGestor(long id)
        {
            var gestor = await _context.Gestor.FindAsync(id);
            if (gestor == null)
            {
                return NotFound();
            }

            _context.Gestor.Remove(gestor);
            await _context.SaveChangesAsync();

            return gestor;
        }
    }
}
