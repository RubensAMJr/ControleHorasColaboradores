using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHorasColaborador.Model
{
    public class EquipeColaborador
    {
        public long EquipeId { get; set; }

        public Equipe Equipe { get; set; }
        public long ColaboradorId{ get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
