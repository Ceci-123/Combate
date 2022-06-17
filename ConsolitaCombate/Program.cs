using System;
using CombateApp;

namespace ConsolitaCombate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personaje personaje1 = PersonajeDAO.ObtenerPersonajePorId(1);

            Personaje personaje2 = PersonajeDAO.ObtenerPersonajePorId(2);

            CombateApp.Combate combate = new(personaje1, personaje2);

            Console.WriteLine("¡FIGHT!");

            combate.IniciarCombate().Wait();
        }

        static void IniciarRonda(IJugador atacante, IJugador atacado)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"¡{atacante} ataca a {atacado}!");
        }

        static void FinalizarCombate(IJugador ganador)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Combate finalizado. El ganador es {ganador}.");
        }

        static void MostrarAtaqueLanzado(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{personaje} lanzó un ataque de {puntosDeAtaque} puntos.");
        }

        static void MostrarAtaqueRecibido(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{personaje} recibió un ataque por {puntosDeAtaque} puntos. Le quedan {personaje.PuntosDeVida} puntos de vida.");
        }
    }
}
