using System;


namespace Entidades
{
    public class PartidaSQL
    {
        public int id;
        public string fecha;
        public string jugador1;
        public string jugador2;
        public string ganador;
        public string puntosGanador;
        public string duracion;

        /// <summary>
        /// Propiedad del tipo get and set para consultar/cambiar ID en la base de datos
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Propiedad del tipo get and set para consultar/cambiar Fecha de la partida finalizada
        /// </summary>
        public string Fecha { get => fecha; set => fecha = value; }
        /// <summary>
        /// Propiedad del tipo get and set para consultar/cambiar el nombre del jugador 1 de la partida finalizada
        /// </summary>
        public string Jugador1 { get => jugador1; set => jugador1 = value; }
        /// <summary>
        /// Propiedad del tipo get and set para consultar/cambiar el nombre del jugador 2 de la partida finalizada
        /// </summary>
        public string Jugador2 { get => jugador2; set => jugador2 = value; }
        /// <summary>
        /// Propiedad del tipo get and set para consultar/cambiar el nombre del jugador ganador de la partida finalizada
        /// </summary>
        public string Ganador { get => ganador; set => ganador = value; }
        /// <summary>
        /// Propiedad del tipo get and set para consultar/cambiar los puntos del ganador de la partida finalizada
        /// </summary>
        public string PuntosGanador { get => puntosGanador; set => puntosGanador = value; }
        /// <summary>
        /// Propiedad del tipo get and set para consultar/cambiar la duracion de la partida finalizada
        /// </summary>
        public string Duracion { get => duracion; set => duracion = value; }

        /// <summary>
        /// Retorna una cadena con todos los atributos en orden segun la tabla de la base de datos separados por -
        /// </summary>
        /// <returns>string con los valores de atributos concatenados y separados por -</returns>
        public override string ToString()
        {
            return $"{this.id}-{this.fecha}-{this.jugador1}-{this.jugador2}-{this.ganador}-{this.puntosGanador}-{this.duracion}";
        }
    }
}
