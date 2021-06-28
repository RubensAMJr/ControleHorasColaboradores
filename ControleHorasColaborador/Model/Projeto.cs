using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class Projeto
    {
        public long ProjetoId { get; set; }
        public string NomeProjeto { get; set; }
        public int HorasTrabalhadasProjeto { get; set; }

        public Equipe Equipe { get; set; }

    }
}
