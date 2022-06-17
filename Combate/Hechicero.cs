namespace CombateApp
{
    public class Hechicero : Personaje
    {
        public Hechicero(decimal id, string nombre) : base(id, nombre)
        {

        }
        public Hechicero(decimal id, short nivel, string nombre) : base(id, nivel, nombre)
        {

        }

        public override void AplicarBeneficiosDeClase()
        {
            int puntos = this.PuntosDeDefensa;
            puntos = puntos * 10 / 100 + puntos;
            this.PuntosDeDefensa = puntos;
        }

    }

}
