using System;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Environment;

namespace CombateApp
{
    public sealed class Combate
    {
        public IJugador atacado;
        public IJugador atacante;
        private static Random random;
        private Personaje personaje1;
        private Personaje personaje2;

        private event DelegadoCombate RondaIniciada;
        private event Action<IJugador> CombateFinalizado;
        public delegate void DelegadoCombate(IJugador j1, IJugador j2);

        static Combate()
        {
            random = new Random();
        }
        Combate(IJugador jugador1, IJugador jugador2)
        {
            atacante = SeleccionarJugadorAleatoriamente(jugador1, jugador2);
            atacado = atacante.Equals(jugador1) ? jugador2 : jugador1;
        }

        public Combate(Personaje personaje1, Personaje personaje2)
        {
            this.personaje1 = personaje1;
            this.personaje2 = personaje2;
        }

        public void Combatir()
        {
            IJugador auxGanador = null;

            do
            {
                IniciarRonda();
                auxGanador = EvaluarGanador();
            } while (auxGanador is null);
            if (CombateFinalizado is not null)
            {
                CombateFinalizado.Invoke(auxGanador);
            }
            GuardarResultado(new ResultadoCombate(DateTime.Now, auxGanador.ToString(), atacado.ToString()));

        }

        public void GuardarResultado(ResultadoCombate resultadoDelCombate)
        {
            string json = JsonSerializer.Serialize(resultadoDelCombate);
            new Logger(GetFolderPath(SpecialFolder.Desktop) + "\\resultados.json").GuardarLog(json);
        }
        public IJugador EvaluarGanador()
        {
            if (atacado.PuntosDeVida == 0)
            {
                return atacante;
            }
            else
            {
                IJugador aux = atacante;
                atacante = atacado;
                atacado = aux;
                return null;
            }
        }
        public Task IniciarCombate()
        {
            return Task.Run(Combatir);
        }
        public void IniciarRonda()
        {
            if (RondaIniciada is not null)
            {
                RondaIniciada.Invoke(this.atacante, this.atacado);
            }
            int puntos = atacante.Atacar();
            atacado.RecibirAtaque(puntos);

        }
        public IJugador SeleccionarJugadorAleatoriamente(IJugador jugador1, IJugador jugador2)
        {
            LadosMoneda moneda = random.TirarUnaMoneda();
            if (moneda is LadosMoneda.Cara)
            {
                return jugador1;
            }
            else
            {
                return jugador2;
            }
        }
        public IJugador SeleccionarPrimerAtacante(IJugador jugador1, IJugador jugador2)
        {
            if (jugador1.Nivel < jugador2.Nivel)
            {
                return jugador1;
            }
            else if (jugador1.Nivel > jugador2.Nivel)
            {
                return jugador2;
            }
            else
            {
                return SeleccionarJugadorAleatoriamente(jugador1, jugador2);
            }
        }

    }
}
