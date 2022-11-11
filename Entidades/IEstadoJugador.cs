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
}
