using System;
using System.Threading;

namespace CombateApp
{
    public abstract class Personaje : IJugador
    {
        protected decimal id;
        protected short nivel;
        protected string nombre;
        private int puntosDeDefensa;
        protected int puntosDePoder;
        protected int puntosDeVida;
        protected Random random;
        private string titulo;
        protected const short nivelMaximo = 100;
        protected const short nivelMinimo = 1;

        public event Action<Personaje, int> AtaqueLanzado;
        public event Action<Personaje, int> AtaqueRecibido;

        static Personaje()
        {
            Random random = new Random();
        }
        public Personaje(decimal id, string nombre) : this(id, 1, nombre)
        {

        }
        public Personaje(decimal id, short nivel, string nombre)
        {
            this.id = id;
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException();
            }
            this.nombre = nombre.Trim();

            if (ValidarNivel(nivel))
            {
                this.nivel = nivel;
            }
            else
            {
                throw new BusinessException("nivel fuera de limites");
            }
            this.puntosDeDefensa = 100 * nivel;
            this.puntosDePoder = 100 * nivel;
            this.puntosDeVida = 500 * nivel;
        }

        public string Titulo { set => titulo = value; }

        public short Nivel { get => nivel; }

        public int PuntosDeVida { get => puntosDeVida; }

        public int PuntosDeDefensa { get => puntosDeDefensa; set => puntosDeDefensa = value; }

        private bool ValidarNivel(short nivel)
        {
            return nivel <= nivelMaximo && nivel >= nivelMinimo;
        }

        public abstract void AplicarBeneficiosDeClase();
        public override string ToString()
        {
            return String.Format("{0}{1}", nombre, string.IsNullOrEmpty(titulo) ? "" : $" ,{titulo}");
        }
        public static bool operator ==(Personaje p1, Personaje p2)
        {
            return p1 is not null && p2 is not null && p1.GetHashCode() == p2.GetHashCode();
        }

        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return (p1 == p2);
        }

        public override bool Equals(Object obj)
        {
            return this == obj as Personaje;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public int Atacar()
        {
            Thread.Sleep(random.Next(1000, 5001));
            int porcentaje = random.Next(10, 101);
            int puntosAtaque = this.puntosDePoder * porcentaje / 100;
            if(AtaqueLanzado is not null)
            {
               AtaqueLanzado.Invoke(this, puntosAtaque);
            }
            return puntosAtaque;
        }
        public void RecibirAtaque(int puntosAtaque)
        {
            int porcentaje = random.Next(10, 101);
            puntosAtaque -= puntosAtaque * porcentaje / 100;
            this.puntosDeVida -= puntosAtaque;
            if (puntosDeVida < 0)
            {
                puntosDeVida = 0;
            }
            if (AtaqueRecibido is not null)
            {
                AtaqueRecibido.Invoke(this, puntosAtaque);
            }
        }

        //Tendrá dos eventos llamados AtaqueLanzado y AtaqueRecibido respectivamente, cuyos manejadores recibirán un Personaje y un int y no retornarán nada.
    }
}
