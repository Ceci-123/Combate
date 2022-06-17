using Microsoft.VisualStudio.TestTools.UnitTesting;
using CombateApp;

namespace TestCombate
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Personaje_DeberiaLanzarBusinessException_CuandoRecibenivelInvalido()
        {
            //preparar
            decimal id = 1;
            short nivel = -25;
            string nombre = "Goku";
            //act
            Hechicero hechi = new Hechicero(id, nivel, nombre);
        }

        [TestMethod]
        public void Personaje_DeberiaTenerNivelDeVidaMayorACero_CuandoRecibeAtaque()
        {
            //preparar
            decimal id = 1;
            short nivel = 10;
            string nombre = "Goku";
            //act
            Hechicero hechi = new Hechicero(id, nivel, nombre);
            hechi.RecibirAtaque(1000);
            //assert
            Assert.IsTrue(hechi.Nivel >= 0);       
        }

        [TestMethod]
        public void PersonajePuntosDefensaCorrectosAlIniciarHechicero()
        {
            //preparar
            decimal id = 1;
            short nivel = 10;
            string nombre = "Goku";
            //act
            Hechicero hechicero = new Hechicero(id, nivel, nombre);
            //assert
            Assert.IsTrue(hechicero.PuntosDeDefensa == hechicero.Nivel * 100);
        }

        [TestMethod]
        public void PersonajePuntosDefensaCorrectosAlIniciarGuerrero()
        {
            //preparar
            decimal id = 1;
            short nivel = 10;
            string nombre = "Goku";
            //act
            Guerrero guerrero = new Guerrero(id, nivel, nombre);
            //assert
            Assert.IsTrue(guerrero.PuntosDeDefensa == guerrero.Nivel * 100);
        }

    }
}
