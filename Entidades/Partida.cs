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

        /// <summary>
        /// Propiedad del tipo get que retorna la instancia del mazo de cartas
        /// </summary>
        public Mazo Mazo { get { return this.mazo; } }
        /// <summary>
        /// Propiedad del tipo get que retorna la ultima carta tirada
        /// </summary>
        public  Carta UltimaCartaTirada { get { return this.cartasTiradas.Peek(); } }
        /// <summary>
        /// Propiedad del tipo get que retorna el total de cartas tiradas
        /// </summary>
        public  Stack<Carta> CartasTiradas { get { return this.cartasTiradas; } }
        /// <summary>
        /// Propiedad del tipo set que agrega una nueva carta a las tiradas
        /// </summary>
        public  Carta AgregarCartaTirada { set {
                this.colorActual = value.Color;
                this.cartasTiradas.Push(value); } }

        /// <summary>
        /// Propiedad del tipo get que retorna el indice del jugador actual del vector de jugadores 
        /// </summary>
        public  int IndiceJugadorActual { get { return this.indiceJugadorActual; } }

        /// <summary>
        /// Propiedad del tipo get que retorna la instancia del jugadorActual
        /// </summary>

        public  Jugador JugadorActual { get { return this.jugadorActual; } }
        /// <summary>
        /// Propiedad del tipo get que retorna la lista de jugadores
        /// </summary>

        public  List<Jugador> Jugadores { get { return this.jugadores; } }
        /// <summary>
        /// Propiedad del tipo get and set que permite establecer/consultar el color actual de la partida
        /// </summary>

        public  EColor ColorActual { get { return this.colorActual; } set { this.colorActual = value; } }

        /// <summary>
        /// Crea una instancia del tipo Partida creando el mazo, los jugadores con los nombres del parametro,agregando accion
        /// de crear partida al log, seleccionando cartas para jugadores y ultima carta tirada, y definidiendo el jugador de inicio
        /// </summary>
        /// <param name="nombreJugadorUno">string con el nombre de jugador 1</param>
        /// <param name="nombreJugadorDos">string con el nombre de jugador 2</param>
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

        /// <summary>
        /// Cambia de estado al jugador actual, indicando a la partida el proximo jugador que tambien se le cambia su estado
        /// </summary>
        /// <returns>Jugador, instancia del jugador que debe jugar la proxima ronda</returns>
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
