using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ResultadoCombate
    {
        DateTime fechaCombate;
        string nombreGanador;
        string nombrePerdedor;

        public ResultadoCombate(string nombreGanador, string nombrePerdedor, DateTime fechaCombate)
        {
            this.nombreGanador = nombreGanador;
            this.nombrePerdedor = nombrePerdedor;
            this.fechaCombate = fechaCombate;
        }

        public DateTime Fecha { get => fechaCombate; set => fechaCombate = value; }
        public string Ganador { get => nombreGanador; set => nombreGanador = value; }
        public string Perdedor { get => nombrePerdedor; set => nombrePerdedor = value; }
    }
}
