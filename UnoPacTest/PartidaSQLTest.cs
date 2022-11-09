using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using System;

namespace UnoPacTest
{
    [TestClass]
    public class PartidaSQLTest
    {
        [TestMethod]
        public void GetAndSetPartidaSQLTest()
        {
            /*
            public int id;
            public string fecha;
            public string jugador1;
            public string jugador2;
            public string ganador;
            public string puntosGanador;
            public string duracion;
             */
            PartidaSQL sql = new PartidaSQL();
            sql.Id = 1;
            string fechaAsignada = sql.Fecha = DateTime.Now.ToString();
            sql.Jugador1 = "Jugador1";
            sql.Jugador2 = "Jugador2";
            sql.Ganador = "Ganador";
            sql.PuntosGanador = "10";
            sql.Duracion = "00:25:30";

            Assert.AreEqual(1, sql.Id);
            Assert.AreEqual(fechaAsignada, sql.Fecha);
            Assert.AreEqual("Jugador1", sql.Jugador1);
            Assert.AreEqual("Jugador2", sql.Jugador2);
            Assert.AreEqual("Ganador", sql.Ganador);
            Assert.AreEqual("10", sql.PuntosGanador);
            Assert.AreEqual("00:25:30", sql.Duracion);
        }

        [TestMethod]
        public void ToStringPartidaSQLTest()
        {
            PartidaSQL sql = new PartidaSQL();
            sql.id = 1;
            string fechaAsignada = sql.fecha = DateTime.Now.ToString();
            sql.jugador1 = "Jugador1";
            sql.jugador2 = "Jugador2";
            sql.ganador = "Ganador";
            sql.puntosGanador = "10";
            sql.duracion = "00:25:30";

            Assert.AreEqual($"{sql.id}-{sql.fecha}-{sql.jugador1}-{sql.jugador2}-{sql.ganador}-{sql.puntosGanador}-{sql.duracion}", sql.ToString());
        }
    }
}
