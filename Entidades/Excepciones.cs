using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MensajeGanadorException : Exception
    {
        /// <summary>
        /// Crea una instancia de MensajeGanadorException asignando el mensaje del parametro al message de la clase base
        /// </summary>
        /// <param name="message">string con el mensaje a cargar en el message del base</param>
        public MensajeGanadorException(string message) : base(message)
        {

        }

    }

    /// <summary>
    /// Crea una instancia de MensajeUnoException asignando el mensaje del parametro al message de la clase base
    /// </summary>
    /// <param name="message">string con el mensaje a cargar en el message del base</param>
    public class MensajeUnoException : Exception
    {
        public MensajeUnoException(string message) : base(message)
        {

        }

    }

    /// <summary>
    /// Crea una instancia de JugadorNoEsTurnoException asignando el mensaje del parametro al message de la clase base
    /// </summary>
    /// <param name="message">string con el mensaje a cargar en el message del base</param>
    public class JugadorNoEsTurnoException : Exception
    {
        public JugadorNoEsTurnoException(string message) : base(message)
        {

        }

    }

    /// <summary>
    /// Crea una instancia de SqlConexionException asignando el mensaje del parametro al message de la clase base
    /// </summary>
    /// <param name="message">string con el mensaje a cargar en el message del base</param>
    public class SqlConexionException : Exception
    {
        public SqlConexionException(string message) : base(message)
        {

        }

    }


    /// <summary>
    /// Crea una instancia de CreacionCartaException 
    /// </summary>
    public class CreacionCartaException : Exception
    {
    }
}
