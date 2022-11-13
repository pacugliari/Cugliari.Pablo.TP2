using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IEstadoJugador
    {
        /// <summary>
        /// Definicion del metodo Jugar
        /// </summary>
        public void Jugar();
        /// <summary>
        /// Definicion del metodo AvanzarTurno
        /// </summary>
        /// <returns>Debe retornar una instancia de alguna clase que implemente IEstadoJugador</returns>
        public IEstadoJugador AvanzarTurno();
    }

    /// <summary>
    /// Clase que implementa la interfaz IEstadoJugador
    /// </summary>
    public class JugadorDisponible : IEstadoJugador
    {
        /// <summary>
        /// Retorna una instancia de JugadorOcupado
        /// </summary>
        /// <returns>Retorna una instancia de JugadorOcupado</returns>
        public IEstadoJugador AvanzarTurno()
        {
            return new JugadorOcupado();
        }

        /// <summary>
        /// Implementacion vacia de jugar
        /// </summary>
        public void Jugar()
        {

        }

    }

    /// <summary>
    /// Clase que implementa la interfaz IEstadoJugador
    /// </summary>
    public class JugadorOcupado : IEstadoJugador
    {
        /// <summary>
        /// Retorna una instancia de JugadorDisponible 
        /// </summary>
        /// <returns>Retorna una instancia de JugadorDisponible </returns>
        public IEstadoJugador AvanzarTurno()
        {
            return new JugadorDisponible();
        }

        /// <summary>
        /// Lanza una excepcion del tipo JugadorNoEsTurnoException con un mensaje
        /// </summary>
        public void Jugar()
        {
            throw new JugadorNoEsTurnoException("No es el turno del jugador seleccionado");

        }
    }
}
