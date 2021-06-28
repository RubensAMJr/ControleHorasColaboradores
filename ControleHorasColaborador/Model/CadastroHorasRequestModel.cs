using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class CadastroHorasRequestModel
    {
        public int QuantidadeHoras { get; set; }
        public long ProjetoId { get; set; }
    }
}
