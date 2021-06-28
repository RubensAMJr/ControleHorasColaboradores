using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class CadastroHorasResponseModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public int horasTrabalhadas { get; set; }

        public CadastroHorasResponseModel(long id, string nome, int horasTrabalhadas)
        {
            this.Id = id;
            this.Nome = nome;
            this.horasTrabalhadas = horasTrabalhadas;
        }
    }
}
