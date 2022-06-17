using System;
using System.Threading;

namespace BusinessLogic
{
    public abstract  class Personaje : IJugador
    {
        decimal id;
        short nivel;
        string nombre;
        private int puntosDeDefensa;
        protected int puntosDeVida;
        protected int puntosDePoder;
        static Random random;
        string titulo;
        const int NIVEL_MAX = 100;
        const int NIVEL_MIN = 1;


        public event Action<Personaje, int> AtaqueLanzado;
        public event Action<Personaje, int> AtaqueRecibido;

        static Personaje()
        {
            random = new Random();
        }

        public Personaje(decimal id, string nombre, short nivel)
        {

            puntosDeDefensa = 100 * nivel;
            puntosDeVida = 500 * nivel;
            puntosDePoder = 100 * nivel;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentNullException();
            }
            this.nombre = nombre.Trim();
            this.id = id;
            if(nivel >= NIVEL_MIN && nivel <= NIVEL_MAX)
            {
            this.nivel = nivel;

            }
            else
            {
                throw new BusinessException("nivel no valido");
            }

        }

        public Personaje(decimal id, string nombre) : this(id, nombre, 1)
        {
           
        }

        public abstract void AplicarBeneficiosDeClase();
        public string Titulo { set => titulo = value; }

        public short Nivel { get => nivel; }

        public int PuntosDeVida { get => puntosDeVida; }
        public int PuntosDeDefensa { get => puntosDeDefensa; set => puntosDeDefensa = value; }

        public static bool operator ==(Personaje p1, Personaje p2)
        {
            return p1 is not null && p2 is not null && p1.GetHashCode() == p2.GetHashCode();
        }
        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1 == p2);    
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this == obj as Personaje;
        }
        public override string ToString()
        {
            return String.Format("{0}{1}", nombre, string.IsNullOrEmpty(titulo) ? "" : $" ,{titulo}");
        }

        public int Atacar()
        {
            Thread.Sleep(random.Next(1000, 5001));
            int puntosDeAtaque = puntosDePoder * random.Next(10, 101) / 100;

            if (AtaqueLanzado is not null)
            {
                AtaqueLanzado.Invoke(this, puntosDeAtaque);
            }
            return puntosDeAtaque;
        }

        public void RecibirAtaque(int puntosDeAtaque)
        {
            puntosDeAtaque -= puntosDeDefensa * random.Next(10, 101) / 100;
            puntosDeVida -= puntosDeAtaque;
            if(puntosDeVida < 0)
            {
                puntosDeVida = 0;
            }
            if (AtaqueRecibido is not null)
            {
                AtaqueRecibido.Invoke(this, puntosDeAtaque);
            }

        }
    }
}
