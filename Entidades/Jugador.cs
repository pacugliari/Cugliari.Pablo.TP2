using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador
    {
        public event Action cambioColor;
        private EJugadores numeroJugador;
        private string nombre;
        private List<Carta> cartas;
        private IEstadoJugador estado;
        private bool recogioCarta;
        private int paginaCartas;

        /// <summary>
        /// Propiedad del tipo get que devuelve la cantidad de paginas de cartas, una pagina es
        /// un grupo de 7 cartas
        /// </summary>
        public int PaginaCartas { get { return (this.paginaCartas/7)+1; } }

        /// <summary>
        /// Propiedad del tipo get que retorna el estado del jugador que es del tipo IEstadoJugador
        /// </summary>
        public IEstadoJugador Estado { get { return this.estado; } }

        /// <summary>
        /// Propiedad del tipo get and set que retorna si el jugador agarro o no una carta en su turno
        /// </summary>
        public bool RecogioCarta { get { return this.recogioCarta; } set { this.recogioCarta = value; } }

        /// <summary>
        /// Propiedad del tipo get que retorna el nombre en formato string del jugador
        /// </summary>
        public string Nombre { get { return this.nombre; } }

        /// <summary>
        /// Propiedad del tipo get que retorna el numero del jugador
        /// </summary>
        public int NumeroJugador { get { return (int)this.numeroJugador; } }

        /// <summary>
        /// Indexador que retorna una carta segun el index, validando que sea valido
        /// </summary>
        /// <param name="index">int, indice de la carta a consultar</param>
        /// <returns>Carta ubicada en el indice pasado por parametro si es valido, sino retorna null</returns>
        public Carta this[int index]
        {
            get {
                Carta rta = null;
                index += this.paginaCartas;
                if (index >= 0 && index < this.cartas.Count) {
                    rta = this.cartas[index];
                }
                return rta;
            }
        }
        /// <summary>
        /// Propiedad del tipo get que retorna la cantidad de cartas que tiene el jugador
        /// </summary>
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

        /// <summary>
        /// Crea una instancia del tipo Jugador, inicializando la lista de cartas en null y RecogioCarta en false
        /// </summary>
        private Jugador()
        {
            this.cartas = new List<Carta>();

            for (int i = 0; i < 108; i++)
            {
                this.cartas.Add(null);
            }

            this.RecogioCarta = false;
            this.paginaCartas = 0;
        }

        /// <summary>
        /// Crea una instancia del tipo Jugador con el nombre,numero de jugador,estado pasado por el parametro
        /// </summary>
        /// <param name="nombre">string que contiene el nombre del jugador</param>
        /// <param name="numeroJugador">EJugadores, contiene el numero de jugador</param>
        /// <param name="estado">IEstadoJugador,contiene el estado con el que se va a crear el jugador</param>
        public Jugador(string nombre,EJugadores numeroJugador,IEstadoJugador estado):this()
        {
            this.nombre = nombre;
            this.estado = estado;
            this.numeroJugador = numeroJugador;

        }

        /// <summary>
        /// Avanza a la siguiente pagina de cartas
        /// </summary>
        public void AvanzarPaginaCartas()
        {
            if (this.paginaCartas + 7 < 108)
                this.paginaCartas = this.paginaCartas + 7;
        }

        /// <summary>
        /// Retrocede a la pagina de cartas anterior
        /// </summary>
        public void RetrocederPaginaCartas()
        {
            if (this.paginaCartas >= 7)
                this.paginaCartas = this.paginaCartas - 7;

        }

        /// <summary>
        /// Calcula los puntos que se van a dar al otro jugador en caso de perder, si es de tipo Numero se suma el numero y si e
        /// es una carta especial suma +30 puntos
        /// </summary>
        /// <returns>int con los puntos a dar al jugador ganador</returns>
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

        /// <summary>
        /// Permite agrupar las cartas de la baraja de cartas del jugador para que no esten
        /// desparramadas por las distintas paginas
        /// </summary>
        private void AgruparCartas()
        {
            List<Carta> cartasNoVacias = new List<Carta>();
            int cartasVacias = 0;
            foreach (Carta item in this.cartas)
            {
                if(item is not null)
                {
                    cartasNoVacias.Add(item);
                }
                else
                {
                    cartasVacias++;
                } 
            }

            for (int i = 0; i < cartasVacias; i++)
            {
                cartasNoVacias.Add(null);
            }
            this.cartas = cartasNoVacias;

        }

        /// <summary>
        /// Verifica que el indice de la carta pasada por parametro se pueda jugar con respecto a la ultima carta tirada en la
        /// partida , si es posible tirar la carta ejecuta la funcion Jugar del estado, si el jugador estaba en un estado de tipo
        /// JugadorDisponible no hace nada y continua con la ejecucion indicando si la carta jugada es de cambio de color y agregando
        /// dicha accion en el log de la partida, en el caso que el Jugador estaba en un estado del tipo JugadorOcupado lanza una excepcion
        /// que es capturada para ser grabada en el log de la partida, finalmente verifica si la cantidad de cartas del jugador es 0 o 1
        /// si es 1, lanza la excepcion MensajeUnoException y graba accion en el log, si es 0 lanza la excepcion MensajeGanadorException
        /// </summary>
        /// <param name="partida">de tipo Partida, partida actual donde se consulta la ultima carta tirada</param>
        /// <param name="posicionCarta">int, posee el index donde esta la carta a jugar por el Jugador</param>
        /// <returns>si pudo jugar la carta retorna true, sino false</returns>
        public bool Jugar(Partida partida,int posicionCarta)
        {
            bool jugoCarta = false;
            posicionCarta = posicionCarta + this.paginaCartas;
            try
            {
                Carta elegida = this.cartas[posicionCarta];
                if (elegida.Color == partida.ColorActual || (elegida.Numero == partida.UltimaCartaTirada.Numero && partida.UltimaCartaTirada.Color != EColor.Negro) 
                     || elegida.Color == EColor.Negro)
                {
                    estado.Jugar();
                    partida.yaSeSalteo = false;
                    partida.AgregarCartaTirada = elegida;
                    partida.ColorActual = elegida.Color;
                    jugoCarta = true;
                    this.cartas[posicionCarta] = null;
                    partida.log.AgregarAlLog($"[{DateTime.Now}][{this.nombre}][Carta jugada -> {elegida.ToString()}]");

                    if (elegida.Tipo == ETipo.MasCuatro || elegida.Tipo == ETipo.CambioColor)
                    {
                        this.cambioColor.Invoke();
                    }

                    this.recogioCarta = false;
                    this.AgruparCartas();
                    partida.SiguienteJugador();
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
                    if (this.CantidadCartas == 0)
                    {
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

        /// <summary>
        /// Busca la primer posicion vacia (que este igualada a null) de la lista de cartas
        /// </summary>
        /// <returns>retorna la posicion de la lista donde esta vacio, sino retorna -1</returns>
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

        /// <summary>
        /// Agrega una lista de cartas del parametro a las cartas del jugador
        /// </summary>
        /// <param name="cartas">List<Carta>, lista de cartas agregar al jugador</param>
        /// <returns>List<int> que contiene las posiciones donde se agregaron dichas cartas</returns>
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

        /// <summary>
        /// Cambia el estado del jugador,poniendolo en Ocupado si estaba Disponible o en
        /// Disponible si estaba Ocupado
        /// </summary>
        public void CambiarEstado()
        {
            this.estado = this.estado.AvanzarTurno();
        }

        /// <summary>
        /// Suma +2 o +4 cartas a la mano del jugador si la ultima carta tirada de la partida
        /// corresponde a un +2 o +4
        /// </summary>
        /// <param name="partida">Partida, contiene la ultima carta tirada</param>
        /// <returns>List<int> lista de las posiciones donde se agregaron dichas cartas</returns>
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


}
