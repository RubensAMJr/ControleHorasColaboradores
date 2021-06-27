using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class Projeto
    {
        public long projetoId { get; set; }
        public string nomeProjeto { get; set; }
        public int horasTrabalhadasProjeto { get; set; }
    }
}
