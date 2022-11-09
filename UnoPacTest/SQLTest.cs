using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using System;

namespace UnoPacTest
{
    [TestClass]
    public class SQLTest
    {
        [TestMethod]
        public void ProbarConexionTest()
        {
            Assert.AreEqual(true, SQL.ProbarConexion());
        }

        [TestMethod]
        public void AgregarDatoTest()
        {
            PartidaSQL sql = new PartidaSQL();
            string fechaAsignada = sql.Fecha = DateTime.Now.ToString();
            sql.Jugador1 = "Test1";
            sql.Jugador2 = "Test2";
            sql.Ganador = "Ganador";
            sql.PuntosGanador = "10";
            sql.Duracion = "00:25:30";

            Assert.AreEqual(true, SQL.AgregarDato(sql));
        }

        [TestMethod]
        public void EliminarDatoObtenidoTest()
        {
            PartidaSQL sql = new PartidaSQL();
            string fechaAsignada = sql.Fecha = DateTime.Now.ToString();
            sql.Jugador1 = "Test1";
            sql.Jugador2 = "Test2";
            sql.Ganador = "Ganador";
            sql.PuntosGanador = "10";
            sql.Duracion = "00:25:30";

            List<PartidaSQL> lista = SQL.ObtenerListaDato();

            foreach (PartidaSQL item in lista)
            {
                if(item.Jugador1 == "Test1") {
                    Assert.AreEqual(true, SQL.EliminarDato(item.Id));
                }
            }

            
        }
    }
}
