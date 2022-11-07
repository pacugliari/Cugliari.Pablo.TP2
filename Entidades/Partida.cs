using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Entidades
{
    public class Partida
    {
        private static List<Jugador> jugadores;
        private static Jugador jugadorActual;
        private static Stopwatch tiempo;
        private Mazo mazo;
        private static Stack<Carta> cartasTiradas;
        private static int indiceJugadorActual;
        private static EColor colorActual;
        public static bool yaSeSalteo;
        public static Log log;



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
            Partida.yaSeSalteo = false;
            Partida.colorActual = EColor.Verde;
        }
        public Partida(string nombreJugadorUno,string nombreJugadorDos)
        {
            Partida.jugadores = new List<Jugador> {new Jugador(nombreJugadorUno,1,new JugadorDisponible()),
                new Jugador(nombreJugadorDos, 2, new JugadorOcupado()) };
            Partida.tiempo = Stopwatch.StartNew();
            this.mazo = new Mazo();

            //2022-10-30 at 17.59
            string hora = DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Day.ToString() + "_" +
                DateTime.Now.Hour.ToString() + '.' + DateTime.Now.Minute.ToString();

            Partida.log = new Log($"{nombreJugadorUno}vs{nombreJugadorDos}_{hora}");
            Partida.log.AgregarAlLog($"[{DateTime.Now}][INICIO DE PARTIDA]");

            Partida.jugadores[0].AgregarCartas(Mazo.ObtenerCartas(3));
            Partida.jugadores[1].AgregarCartas(Mazo.ObtenerCartas(3));
            Partida.cartasTiradas.Push(Mazo.ObtenerCartas(1)[0]);
            Partida.colorActual = Partida.UltimaCartaTirada.Color;
            if(Partida.colorActual == EColor.Negro)
                Partida.colorActual = EColor.Verde;
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
            return Partida.jugadorActual;
        }

        public static string CalcularTiempo()
        {
            Partida.tiempo.Stop();
            return Partida.tiempo.Elapsed.ToString("hh\\:mm\\:ss");
        }




    }
}
