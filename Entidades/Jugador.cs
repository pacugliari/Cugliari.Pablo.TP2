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

        private Jugador()
        {
            this.cartas = new List<Carta>();
        }

        public Jugador(string nombre,int numeroJugador,IEstadoJugador estado):this()
        {
            this.nombre = nombre;
            this.estado = estado;
            this.numeroJugador = numeroJugador;

        }

        public Carta Jugar()
        {
            Carta retorno = null;
            try
            {
                retorno = estado.Jugar(cartas,this);
            }
            catch (Exception)
            {
                //PUEDE TIRAR EXCEPCION SI EL ESTADO DEL JUGADOR ES NO DISPONIBLE
                throw;
            }

            return retorno;
        }

        public void AgregarCartas(List<Carta> cartas)
        {
            foreach (Carta item in cartas)
            {
                this.cartas.Add(item);
            }
        }
    }

    public class JugadorDisponible : IEstadoJugador
    {
        public IEstadoJugador AvanzarTurno()
        {
            return new JugadorOcupado();
        }

        public Carta Jugar(List<Carta> cartas,Jugador jugador)
        {
            Carta cartaATirar = this.BuscarCartaATirar(cartas);

            if (cartaATirar is null)//NO TIENE CARTAS PARA TIRAR
            {
                //JUNTA UNA DEL MAZO
                List<Carta> cartasLevantadas = Mazo.ObtenerCartas(1);

                if(cartasLevantadas is null)//EL MAZO SE QUEDO SIN CARTAS
                {
                    Mazo.MezclarCartasTiradas();
                    cartasLevantadas = Mazo.ObtenerCartas(1);

                }
                jugador.AgregarCartas(cartasLevantadas);
                cartaATirar = this.BuscarCartaATirar(cartas);
            }

            if (cartas.Count == 1)
            {
                //EXCEPCION GRITAR UNO
            }else if (cartas.Count == 0)
            {
                //EXCEPCION GRITAR GANO
            }

            return cartaATirar;
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

        public Carta Jugar(List<Carta> cartas, Jugador jugador)
        {
            //DEFINIR NUEVA EXEPCION
            throw new NotImplementedException();
        }
    }


}
