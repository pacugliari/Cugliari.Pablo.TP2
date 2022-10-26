using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Partida
    {
        private List<Jugador> jugadores;
        private DateTime tiempoInicio;
        private DateTime tiempoFin;
        private Stack<string> victorias;
        private int numeroRonda;
        private Mazo mazo;
        private static Stack<Carta> cartasTiradas;
        private int indiceJugadorActual;
        private EColor colorActual;

        public static Carta UltimaCartaTirada { get { return Partida.cartasTiradas.Peek(); } }
        public static Stack<Carta> CartasTiradas { get { return Partida.cartasTiradas; } }

        public Partida(string nombreJugadorUno,string nombreJugadorDos)
        {
            this.jugadores = new List<Jugador> {new Jugador(nombreJugadorUno,new JugadorDisponible()), new Jugador(nombreJugadorDos, new JugadorOcupado()) };
            this.tiempoInicio = DateTime.Now;
            this.victorias = new Stack<string>();
            this.numeroRonda = 1;
            this.mazo = new Mazo();

            this.jugadores[0].AgregarCartas(Mazo.ObtenerCartas(7));
            this.jugadores[1].AgregarCartas(Mazo.ObtenerCartas(7));
        }

        public void JugarRonda()
        {
            foreach (Jugador item in this.jugadores)
            {
                Carta cartaTirada = item.Jugar();
                if(cartaTirada is not null)
                    Partida.cartasTiradas.Push(cartaTirada);
            }
        }


    }
}
