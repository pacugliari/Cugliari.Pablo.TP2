using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador
    {
        private EJugadores numeroJugador;
        private string nombre;
        private List<Carta> cartas;
        private IEstadoJugador estado;
        private bool recogioCarta;

        public IEstadoJugador Estado { get { return this.estado; } }

        public bool RecogioCarta { get { return this.recogioCarta; } set { this.recogioCarta = value; } }

        public string Nombre { get { return this.nombre; } }

        public int NumeroJugador { get { return (int)this.numeroJugador; } }

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

        public int CantidadCartas { 
            get {
                int retorno = 0;
                for (int i = 0; i < this.cartas.Count; i++)
                {
                    if (this.cartas[i] is not null)
                        retorno++;
                }
                return retorno;
            } 
        }

        private Jugador()
        {
            this.cartas = new List<Carta>();

            for (int i = 0; i < 7; i++)
            {
                this.cartas.Add(null);
            }

            this.RecogioCarta = false;
        }

        public Jugador(string nombre,EJugadores numeroJugador,IEstadoJugador estado):this()
        {
            this.nombre = nombre;
            this.estado = estado;
            this.numeroJugador = numeroJugador;

        }

        public int ObtenerPuntos()
        {
            int retorno = 0;
            foreach (Carta item in this.cartas)
            {
                if(item is not null)
                {
                    switch (item.Tipo)
                    {
                        case ETipo.Numero:
                            retorno += item.Numero;
                            break;
                        case ETipo.MasDos:
                        case ETipo.Salteo:
                        case ETipo.Invertir:
                        case ETipo.CambioColor:
                        case ETipo.MasCuatro:
                            retorno += 30;
                            break;
                    }
                }
            }
            return retorno;
        }

        public bool Jugar(Partida partida,int posicionCarta,out bool esCambioColor)
        {
            bool jugoCarta = false;
            esCambioColor = false;
            IEstadoJugador estadoPrevio = this.estado;
            try
            {
                Carta elegida = this.cartas[posicionCarta];
                if (elegida.Color == partida.ColorActual || (elegida.Numero == partida.UltimaCartaTirada.Numero && partida.UltimaCartaTirada.Color != EColor.Negro) 
                     || elegida.Color == EColor.Negro)
                {
                    estado.Jugar();
                    partida.yaSeSalteo = false;
                    if (elegida.Tipo == ETipo.MasCuatro || elegida.Tipo == ETipo.CambioColor)
                    {
                        esCambioColor = true;
                    }
                    partida.ColorActual = elegida.Color;
                    partida.AgregarCartaTirada = elegida;
                    jugoCarta = true;
                    partida.log.AgregarAlLog($"[{DateTime.Now}][{this.nombre}][Carta jugada -> Color: {elegida.Color} Numero: {elegida.Numero} " +
                        $"Tipo: {elegida.Tipo}]");
                    this.cartas[posicionCarta] = null;
                }
            }
            catch (Exception ex)
            {
                partida.log.AgregarAlLog($"[{DateTime.Now}][{this.nombre}][Exception: {ex.Message}]");
            }
            finally
            {
                if (jugoCarta)
                {
                    if (this.recogioCarta)
                        this.recogioCarta = false;

                    partida.SiguienteJugador();

                    if (this.CantidadCartas == 0)
                    {
                        esCambioColor = false;
                        throw new MensajeGanadorException(this.nombre);
                    }else if (this.CantidadCartas == 1)
                    {
                        partida.log.AgregarAlLog($"[{DateTime.Now}][{this.Nombre}][GRITA UNO!!!]");
                        throw new MensajeUnoException(this.NumeroJugador.ToString());
                    }
                    
                }
                    

            }

            return jugoCarta;
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
                else
                {
                    break;
                }

            }
            
            return posiciones;
        }

        public void CambiarEstado()
        {
            this.estado = this.estado.AvanzarTurno();
        }

        public List<int> ActualizarJugador(Partida partida)
        {
            
            Carta ultimaCartaTirada = partida.UltimaCartaTirada;
            List<int> posiciones = new List<int>();

            if (!partida.yaSeSalteo)
            {
                if (ultimaCartaTirada.Tipo == ETipo.MasCuatro)
                {
                    posiciones = this.AgregarCartas(partida.Mazo.ObtenerCartas(partida,4));
                }
                else if (ultimaCartaTirada.Tipo == ETipo.MasDos)
                {
                    posiciones = this.AgregarCartas(partida.Mazo.ObtenerCartas(partida, 2));

                }
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

    }

    public class JugadorOcupado : IEstadoJugador
    {
        public IEstadoJugador AvanzarTurno()
        {
            return new JugadorDisponible();
        }

        public void Jugar()
        {
            throw new JugadorNoEsTurnoException("No es el turno del jugador seleccionado");

        }
    }


}
