using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Log
    {
        private StringBuilder texto;
        private string nombre;

        //[HORA][JUGADOR VS JUGADOR]
        //[HORA][JUGADOR][ACCION]
        //[HORA][EXEPCION]
        //[HORA][GANADOR][DURACION]

        public string Nombre { get { return this.nombre; } }

        public Log(string nombre)
        {
            this.nombre = nombre;
            this.texto = new StringBuilder();
        }

        public void AgregarAlLog<T>(List<T> dato)
        {
            foreach (T item in dato)
            {
                this.AgregarAlLog(item);
            }
            
        }

        public void AgregarAlLog<T>(T dato)
        {
            this.texto.AppendLine(dato.ToString());
        }

        public override string ToString()
        {
            return texto.ToString();
        }

    }
}
