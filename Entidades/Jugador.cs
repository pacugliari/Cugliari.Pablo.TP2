using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador
    {
        private int numeroJugador;
        private string nombre;
        private List<Carta> cartas;
        private IEstadoJugador estado;
        private bool recogioCarta;

        public bool RecogioCarta { get { return this.recogioCarta; } set { this.recogioCarta = value; } }


        public string Nombre { get { return this.nombre; } }

        public int NumeroJugador { get { return this.numeroJugador; } }
        public Carta this[int index]
        {
            get {
                Carta rta = null;
                if (index >= 0 && index < this.cartas.Count) {
                    rta = this.cartas[index];
                }
                return rta;
            }
        }

        public int CantidadCartas { get { return this.cartas.Count; } }

        private Jugador()
        {
            this.cartas = new List<Carta>();
            for (int i = 0; i < 7; i++)
            {
                this.cartas.Add(null);
            }

            this.RecogioCarta = false;
        }

        public Jugador(string nombre,int numeroJugador,IEstadoJugador estado):this()
        {
            this.nombre = nombre;
            this.estado = estado;
            this.numeroJugador = numeroJugador;

        }

        public bool Jugar(int posicionCarta,out bool esCambioColor)
        {
            bool retorno = false;
            esCambioColor = false;
            IEstadoJugador estadoPrevio = this.estado;
            try
            {
                Carta elegida = this.cartas[posicionCarta];
                if (elegida.Color == Partida.ColorActual || (elegida.Numero == Partida.UltimaCartaTirada.Numero && Partida.UltimaCartaTirada.Color != EColor.Negro) 
                     || elegida.Color == EColor.Negro)
                {
                    estado.Jugar();
                    if (elegida.Tipo == ETipo.MasCuatro || elegida.Tipo == ETipo.CambioColor)
                    {
                        esCambioColor = true;
                    }
                    Partida.ColorActual = elegida.Color;
                    Partida.AgregarCartaTirada = elegida;
                    retorno = true;
                    this.cartas[posicionCarta] = null;
                }
            }
            catch (Exception )
            {
                //PUEDE TIRAR EXCEPCION SI EL ESTADO DEL JUGADOR ES NO DISPONIBLE
            }
            finally
            {
                if (retorno)
                {
                    if (Partida.JugadorActual.recogioCarta)
                        Partida.JugadorActual.recogioCarta = false;
                    Partida.SiguienteJugador();
                }
                    

            }

            return retorno;
        }

        private int BuscarPosicionVacia()
        {
            int posicion = -1;
            for (int i = 0; i < this.cartas.Count; i++)
            {
                if (this.cartas[i] is null)
                {
                    posicion = i;
                    break;
                }

            }
            return posicion;
        }

        public List<int> AgregarCartas(List<Carta> cartas)
        {
            List<int> posiciones = new List<int>();
            int posicionAgregada = -1;
            foreach (Carta item in cartas)
            {
                posicionAgregada = this.BuscarPosicionVacia();
                if (posicionAgregada != -1)
                {
                    this.cartas[posicionAgregada] = item;
                    posiciones.Add(posicionAgregada);
                }
                posicionAgregada = -1;
            }
            return posiciones;
        }

        public void CambiarEstado()
        {
            this.estado = this.estado.AvanzarTurno();
        }

        public List<int> ActualizarJugador()
        {
            Carta ultimaCartaTirada = Partida.UltimaCartaTirada;
            List<int> posiciones = new List<int>();
            if(ultimaCartaTirada.Tipo == ETipo.MasCuatro)
            {
                posiciones = this.AgregarCartas(Mazo.ObtenerCartas(4));
            }else if (ultimaCartaTirada.Tipo == ETipo.MasDos)
            {
                posiciones = this.AgregarCartas(Mazo.ObtenerCartas(2));

            }else if (ultimaCartaTirada.Tipo == ETipo.Salteo || ultimaCartaTirada.Tipo == ETipo.Invertir)
            {
                //Partida.SiguienteJugador();
            }
            return posiciones;
        }
    }


    public class JugadorDisponible : IEstadoJugador
    {
        public IEstadoJugador AvanzarTurno()
        {
            return new JugadorOcupado();
        }

        public void Jugar()
        {
            
        }

        private Carta BuscarCartaATirar(List<Carta> cartas)
        {
            Carta ultimaTirada = Partida.UltimaCartaTirada;
            Carta cartaATirar = null;
            for (int i = 0; i < cartas.Count; i++)
            {
                cartaATirar = cartas[i];
                if (cartaATirar == ultimaTirada)
                {
                    cartas.RemoveAt(i);
                }
            }
            return cartaATirar;
        }
    }

    public class JugadorOcupado : IEstadoJugador
    {
        public IEstadoJugador AvanzarTurno()
        {
            return new JugadorDisponible();
        }

        public void Jugar()
        {
            //DEFINIR NUEVA EXEPCION
            throw new NotImplementedException();

        }
    }


}
