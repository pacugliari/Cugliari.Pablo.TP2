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

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Jugador1 { get => jugador1; set => jugador1 = value; }
        public string Jugador2 { get => jugador2; set => jugador2 = value; }
        public string Ganador { get => ganador; set => ganador = value; }
        public string PuntosGanador { get => puntosGanador; set => puntosGanador = value; }
        public string Duracion { get => duracion; set => duracion = value; }

        public override string ToString()
        {
            return $"{this.id}-{this.fecha}-{this.jugador1}-{this.jugador2}-{this.ganador}-{this.puntosGanador}-{this.duracion}";
        }
    }
}
