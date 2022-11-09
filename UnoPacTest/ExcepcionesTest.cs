using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using System;

namespace UnoPacTest
{
    [TestClass]
    public class ExcepcionesTest
    {
        [TestMethod]
        public void MensajeGanadorExceptionTest()
        {
            try
            {
                throw new MensajeGanadorException("MensajeGanadorException");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MensajeGanadorException));
                Assert.AreEqual("MensajeGanadorException", ex.Message);
            }
            
        }

        [TestMethod]
        public void MensajeUnoExceptionTest()
        {
            try
            {
                throw new MensajeUnoException("MensajeUnoException");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MensajeUnoException));
                Assert.AreEqual("MensajeUnoException", ex.Message);
            }

        }

        [TestMethod]
        public void JugadorNoEsTurnoExceptionTest()
        {
            try
            {
                throw new JugadorNoEsTurnoException("JugadorNoEsTurnoException");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(JugadorNoEsTurnoException));
                Assert.AreEqual("JugadorNoEsTurnoException", ex.Message);
            }

        }

        [TestMethod]
        public void SqlConexionExceptionTest()
        {
            try
            {
                throw new SqlConexionException("SqlConexionException");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(SqlConexionException));
                Assert.AreEqual("SqlConexionException", ex.Message);
            }

        }

        [TestMethod]
        public void CreacionCartaExceptionTest()
        {
            try
            {
                throw new CreacionCartaException();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(CreacionCartaException));
            }

        }
    }
}
