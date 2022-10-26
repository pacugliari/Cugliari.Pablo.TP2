using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IEstadoJugador
    {
        public Carta Jugar(List<Carta> cartas,Jugador jugador);
        public IEstadoJugador AvanzarTurno();
    }
}
