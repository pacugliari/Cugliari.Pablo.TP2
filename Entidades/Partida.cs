using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Entidades
{
    public class Partida
    {
        private List<Jugador> jugadores;
        private Jugador jugadorActual;
        private Mazo mazo;
        private Stack<Carta> cartasTiradas;
        private int indiceJugadorActual;
        private EColor colorActual;
        public  bool yaSeSalteo;
        public  Log log;


        public Mazo Mazo { get { return this.mazo; } }
        public  Carta UltimaCartaTirada { get { return this.cartasTiradas.Peek(); } }
        public  Stack<Carta> CartasTiradas { get { return this.cartasTiradas; } }
        public  Carta AgregarCartaTirada { set {
                this.colorActual = value.Color;
                this.cartasTiradas.Push(value); } }

        public  int IndiceJugadorActual { get { return this.indiceJugadorActual; } }

        public  Jugador JugadorActual { get { return this.jugadorActual; } }

        public  List<Jugador> Jugadores { get { return this.jugadores; } }

        public  EColor ColorActual { get { return this.colorActual; } set { this.colorActual = value; } }


        public Partida(string nombreJugadorUno, string nombreJugadorDos)
        {
            this.cartasTiradas = new Stack<Carta>();
            this.yaSeSalteo = false;
            this.colorActual = EColor.Verde;

            this.jugadores = new List<Jugador> {new Jugador(nombreJugadorUno,EJugadores.Jugador1,new JugadorDisponible()),
                new Jugador(nombreJugadorDos, EJugadores.Jugador2, new JugadorOcupado()) };
            this.mazo = new Mazo();

            //2022-10-30 at 17.59
            string hora = DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Day.ToString() + "_" +
                DateTime.Now.Hour.ToString() + '.' + DateTime.Now.Minute.ToString();
            this.log = new Log($"{nombreJugadorUno}vs{nombreJugadorDos}_{hora}");

            this.log.AgregarAlLog($"[{DateTime.Now}][INICIO DE PARTIDA]");

            this.jugadores[0].AgregarCartas(this.mazo.ObtenerCartas(this, 3));
            this.jugadores[1].AgregarCartas(this.mazo.ObtenerCartas(this, 3));
            this.cartasTiradas.Push(this.mazo.ObtenerCartas(this, 1)[0]);
            this.colorActual = this.UltimaCartaTirada.Color;
            if (this.colorActual == EColor.Negro)
                this.colorActual = EColor.Verde;
            this.indiceJugadorActual = (int)EJugadores.Jugador1;//1
            this.jugadorActual = this.jugadores[0];

        }

        public Jugador SiguienteJugador()
        {
            this.JugadorActual.RecogioCarta = false;
            this.jugadorActual.CambiarEstado();
            if (this.jugadorActual.NumeroJugador == (int)EJugadores.Jugador1)//1
            {
                this.jugadorActual = this.jugadores[1];//1
                this.indiceJugadorActual = (int)EJugadores.Jugador2;//2
                
            }
            else
            {
                this.jugadorActual = this.jugadores[0];//0
                this.indiceJugadorActual = (int)EJugadores.Jugador1;//1
            }
            this.jugadorActual.CambiarEstado();
            return this.jugadorActual;
        }

    }
}
