using System;

namespace CombateApp
{
    public static class ExtensionRandom
    {
        public static LadosMoneda TirarUnaMoneda(this Random rnd)
        {
            rnd = new Random();
            int resultado = rnd.Next(1,3);
            return (LadosMoneda)resultado;
        }
    }
}
