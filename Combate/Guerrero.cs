using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateApp
{
    public class Guerrero :Personaje
    {
        public Guerrero(decimal id, string nombre) :base(id, nombre)
        {

        }
        public Guerrero(decimal id, short nivel, string nombre) : base(id, nivel, nombre)
        {

        }
        public override void AplicarBeneficiosDeClase()
        {
            int puntos = this.PuntosDeDefensa;
            puntos = puntos *10 / 100 + puntos;
            this.PuntosDeDefensa = puntos;
        }

       
    }
}
