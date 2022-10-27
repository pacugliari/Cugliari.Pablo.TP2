using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Partida
    {
        private List<Jugador> jugadores;
        private DateTime tiempoInicio;
        private DateTime tiempoFin;
        private Mazo mazo;
        private static Stack<Carta> cartasTiradas;
        private int indiceJugadorActual;
        private EColor colorActual;

        public static Carta UltimaCartaTirada { get { return Partida.cartasTiradas.Peek(); } }
        public static Stack<Carta> CartasTiradas { get { return Partida.cartasTiradas; } }

        public List<Jugador> Jugadores { get { return this.jugadores; } }


        static Partida()
        {
            Partida.cartasTiradas = new Stack<Carta>();
        }
        public Partida(string nombreJugadorUno,string nombreJugadorDos)
        {
            this.jugadores = new List<Jugador> {new Jugador(nombreJugadorUno,1,new JugadorDisponible()),
                new Jugador(nombreJugadorDos, 2, new JugadorOcupado()) };
            this.tiempoInicio = DateTime.Now;
            this.mazo = new Mazo();
            

            this.jugadores[0].AgregarCartas(Mazo.ObtenerCartas(7));
            this.jugadores[1].AgregarCartas(Mazo.ObtenerCartas(7));
            Partida.cartasTiradas.Push(Mazo.ObtenerCartas(1)[0]);
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
