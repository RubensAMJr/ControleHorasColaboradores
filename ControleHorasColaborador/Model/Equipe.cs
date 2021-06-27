using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class Equipe
    {
        public long EquipeId { get; set; }
        public string NomeEquipe { get; set; }
        public int HorasTrabalhadasProjeto { get; set; }

        public List<EquipeColaborador> EquipeColaborador { get; set; }

        public long ProjetoId { get; set; }
        public Projeto Projeto { get; set; }


        public Equipe(string nomeEquipe)
        {
            this.NomeEquipe = nomeEquipe;
        }
    }
}
