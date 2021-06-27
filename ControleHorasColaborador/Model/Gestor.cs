using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class Gestor
    {
        public long GestorId { get; set; }
        public string Nome { get; set; }

        public Gestor(string nome)
        {
            this.Nome = nome;
        }
    }
}
