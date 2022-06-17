using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public  class Guerrero : Personaje
    {
        public Guerrero(decimal id, string nombre, short nivel) : base(id, nombre, nivel)
        {
        }

        public override void AplicarBeneficiosDeClase()
        {
            puntosDeDefensa += (int)(puntosDeDefensa * 1.1);
        }
    }
}
