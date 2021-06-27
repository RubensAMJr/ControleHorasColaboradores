using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class Equipe
    {
        public long equipeId { get; set; }
        public string nomeEquipe { get; set; }
        public int horasTrabalhadasProjeto { get; set; }
    }
}
