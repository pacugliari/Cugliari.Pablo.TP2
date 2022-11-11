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

        /// <summary>
        /// Propiedad del tipo get que retorna el nombre del log
        /// </summary>
        public string Nombre { get { return this.nombre; } }

        /// <summary>
        /// Crea una instancia del tipo Log con el nombre pasado por parametro iniciando el atributo texto con
        /// un StringBuilder
        /// </summary>
        /// <param name="nombre">string, nombre del log</param>
        public Log(string nombre)
        {
            this.nombre = nombre;
            this.texto = new StringBuilder();
        }

        /// <summary>
        /// Agrega una Lista generica de tipo T al atributo texto utilizando el metodo ToString de los datos de la lista
        /// </summary>
        /// <typeparam name="T">tipo generico</typeparam>
        /// <param name="dato">List<T> lista generica con los datos</param>
        public void AgregarAlLog<T>(List<T> dato)
        {
            foreach (T item in dato)
            {
                this.AgregarAlLog(item);
            }
            
        }

        /// <summary>
        ///  Agrega una dato generico de tipo T al atributo texto utilizando el metodo ToString del dato
        /// </summary>
        /// <typeparam name="T">tipo generico</typeparam>
        /// <param name="dato">dato generico que se agrega al log</param>
        public void AgregarAlLog<T>(T dato)
        {
            this.texto.AppendLine(dato.ToString());
        }

        /// <summary>
        /// Retorna un string del atributo texto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return texto.ToString();
        }

    }
}
