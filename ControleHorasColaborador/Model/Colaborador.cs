using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class Colaborador
    {
        public long ColaboradorId { get; set; }
        public string Nome { get; set; }
        public List<EquipeColaborador> EquipeColaborador { get; set; }


        public Colaborador(string nome)
        {
            this.Nome = nome;
        }
    }
}
