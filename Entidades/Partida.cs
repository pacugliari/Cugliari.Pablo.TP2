using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Partida
    {
        private static List<Jugador> jugadores;
        private static Jugador jugadorActual;
        private DateTime tiempoInicio;
        private DateTime tiempoFin;
        private Mazo mazo;
        private static Stack<Carta> cartasTiradas;
        private static int indiceJugadorActual;
        private static EColor colorActual;

        public static Carta UltimaCartaTirada { get { return Partida.cartasTiradas.Peek(); } }
        public static Stack<Carta> CartasTiradas { get { return Partida.cartasTiradas; } }
        public static Carta AgregarCartaTirada { set { Partida.cartasTiradas.Push(value); } }

        public static int IndiceJugadorActual { get { return Partida.indiceJugadorActual; } }

        public static Jugador JugadorActual { get { return Partida.jugadorActual; } }

        public static List<Jugador> Jugadores { get { return Partida.jugadores; } }

        public static EColor ColorActual { get { return Partida.colorActual; } set { Partida.colorActual = value; } }


        static Partida()
        {
            Partida.cartasTiradas = new Stack<Carta>();
        }
        public Partida(string nombreJugadorUno,string nombreJugadorDos)
        {
            Partida.jugadores = new List<Jugador> {new Jugador(nombreJugadorUno,1,new JugadorDisponible()),
                new Jugador(nombreJugadorDos, 2, new JugadorOcupado()) };
            this.tiempoInicio = DateTime.Now;
            this.mazo = new Mazo();

            Partida.jugadores[0].AgregarCartas(Mazo.ObtenerCartas(3));
            Partida.jugadores[1].AgregarCartas(Mazo.ObtenerCartas(3));
            Partida.cartasTiradas.Push(Mazo.ObtenerCartas(1)[0]);
            Partida.colorActual = Partida.UltimaCartaTirada.Color;
            Partida.indiceJugadorActual = 1;
            Partida.jugadorActual = Partida.jugadores[0];
        }

        public static Jugador SiguienteJugador()
        {
            Partida.JugadorActual.RecogioCarta = false;
            Partida.jugadorActual.CambiarEstado();
            if (Partida.jugadorActual.NumeroJugador == 1)
            {
                Partida.jugadorActual = Partida.jugadores[1];
                Partida.indiceJugadorActual = 2;
                
            }
            else
            {
                Partida.jugadorActual = Partida.jugadores[0];
                Partida.indiceJugadorActual = 1;
            }
            Partida.jugadorActual.CambiarEstado();
            Partida.jugadorActual.ActualizarJugador();

            return Partida.jugadorActual;
        }


    }
}
