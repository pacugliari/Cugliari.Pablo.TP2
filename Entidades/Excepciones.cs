using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MensajeGanadorException : Exception
    {
        public MensajeGanadorException(string message) : base(message)
        {

        }

    }

    public class MensajeUnoException : Exception
    {
        public MensajeUnoException(string message) : base(message)
        {

        }

    }

    public class JugadorNoEsTurnoException : Exception
    {
        public JugadorNoEsTurnoException(string message) : base(message)
        {

        }

    }

    public class SqlConexionException : Exception
    {
        public SqlConexionException(string message) : base(message)
        {

        }

    }

    public class CreacionCartaException : Exception
    {
    }
}
