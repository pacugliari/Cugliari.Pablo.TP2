using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace UnoPacTest
{
    [TestClass]
    public class JugadorTest
    {
        [TestMethod]
        public void CrearJugadorTest()
        {
            Jugador jugador = new Jugador("Test", EJugadores.Jugador1, new JugadorDisponible());

            Assert.AreEqual("Test", jugador.Nombre);
            Assert.AreEqual((int)EJugadores.Jugador1, jugador.NumeroJugador);
            Assert.AreEqual(false, jugador.RecogioCarta);
            Assert.AreEqual(true, jugador[0] is null);
            Assert.AreEqual(0, jugador.CantidadCartas);
        }

        [TestMethod]
        public void AgregarCartasTest()
        {
            Mazo mazo = new Mazo();
            Partida partida = new Partida("Test", "Test2");
            Jugador jugador = new Jugador("Test", EJugadores.Jugador1, new JugadorDisponible());
            jugador.AgregarCartas(mazo.ObtenerCartas(partida, 3));
            Assert.AreEqual(3, jugador.CantidadCartas);
            Assert.AreEqual(true, jugador[0] is not null);
            Assert.AreEqual(true, jugador[1] is not null);
            Assert.AreEqual(true, jugador[2] is not null);
            Assert.AreEqual(true, jugador[3] is null);
            Assert.AreEqual(true, jugador[4] is null);
            Assert.AreEqual(true, jugador[5] is null);
            Assert.AreEqual(true, jugador[6] is null);
        }

        [TestMethod]
        public void ObtenerPuntosTest()
        {
            Jugador jugador = new Jugador("Test", EJugadores.Jugador1, new JugadorDisponible());
            jugador.AgregarCartas(new List<Carta> { new Carta(ETipo.CambioColor, EColor.Negro), new Carta(ETipo.Numero, EColor.Rojo, 8) });

            Assert.AreEqual(38, jugador.ObtenerPuntos());


        }

        [TestMethod]
        public void CambiarEstadoTest()
        {
            Jugador jugador = new Jugador("Test", EJugadores.Jugador1, new JugadorDisponible());

            Assert.IsInstanceOfType(jugador.Estado, typeof(JugadorDisponible));
            jugador.CambiarEstado();
            Assert.IsInstanceOfType(jugador.Estado, typeof(JugadorOcupado));
            jugador.CambiarEstado();
            Assert.IsInstanceOfType(jugador.Estado, typeof(JugadorDisponible));

        }

        [TestMethod]
        public void ActualizarJugadorTest()
        {
            Jugador jugador = new Jugador("Test", EJugadores.Jugador1, new JugadorDisponible());
            Partida partida = new Partida("Test", "Test2");

            Assert.AreEqual(0, jugador.CantidadCartas);

            partida.AgregarCartaTirada = new Carta(ETipo.MasCuatro, EColor.Negro);

            jugador.ActualizarJugador(partida);

            Assert.AreEqual(4, jugador.CantidadCartas);

            partida.AgregarCartaTirada = new Carta(ETipo.MasDos, EColor.Rojo);

            jugador.ActualizarJugador(partida);

            Assert.AreEqual(6, jugador.CantidadCartas);

        }

        [TestMethod]
        public void JugadorDisponibleTest()
        {
            IEstadoJugador estado = new JugadorDisponible();

            estado = estado.AvanzarTurno();
            Assert.IsInstanceOfType(estado, typeof(JugadorOcupado));

        }

        [TestMethod]
        public void JugadorOcupadoTest()
        {
            IEstadoJugador estado = new JugadorOcupado();

            try
            {
                estado.Jugar();
            }
            catch (System.Exception ex)
            {

                Assert.IsInstanceOfType(ex, typeof(JugadorNoEsTurnoException));
            }
            estado = estado.AvanzarTurno();
            Assert.IsInstanceOfType(estado, typeof(JugadorDisponible));

        }

        [TestMethod]
        public void JugarValidoTest()
        {
            Partida partida = new Partida("Test1", "Test2");
            Jugador jugador1 = partida.Jugadores[0];
            Jugador jugador2 = partida.Jugadores[1];
            partida.AgregarCartaTirada = new Carta(ETipo.Numero, EColor.Rojo, 1);
            partida.JugadorActual.AgregarCartas(new List<Carta> { new Carta(ETipo.Numero, EColor.Rojo, 5) });

            List<Carta> cartas = new List<Carta>();

            for (int i = 0; i < partida.JugadorActual.CantidadCartas; i++)
            {
                cartas.Add(partida.JugadorActual[i]);
            }



           Assert.AreEqual(true, partida.JugadorActual.Jugar(partida, 7));
           Assert.AreEqual(partida.UltimaCartaTirada, cartas[7]);

        }

        [TestMethod]
        public void JugarNoEsTurnoTest()
        {
            Partida partida = new Partida("Test1", "Test2");
            Jugador jugador1 = partida.Jugadores[0];
            Jugador jugador2 = partida.Jugadores[1];

            try
            {
                jugador2.Jugar(partida, 3);
            }
            catch (System.Exception ex)
            {

                Assert.IsInstanceOfType(ex, typeof(JugadorNoEsTurnoException));
            }

        }

        private void FuncionTestFormularioCambioColor()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void JugarValidoConCambioDeColorTest()
        {
            Partida partida = new Partida("Test1", "Test2");
            Jugador jugador1 = partida.Jugadores[0];
            Jugador jugador2 = partida.Jugadores[1];
            partida.JugadorActual.AgregarCartas(new List<Carta> { new Carta(ETipo.CambioColor, EColor.Negro) });
            partida.JugadorActual.cambioColor += this.FuncionTestFormularioCambioColor;

            try
            {
                partida.JugadorActual.Jugar(partida, 3);
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
            }


        }

        [TestMethod]
        public void JugarInvalidoTest()
        {
            Partida partida = new Partida("Test1", "Test2");
            Jugador jugador1 = partida.Jugadores[0];
            Jugador jugador2 = partida.Jugadores[1];
            partida.AgregarCartaTirada = new Carta(ETipo.Numero, EColor.Rojo, 1);
            partida.JugadorActual.AgregarCartas(new List<Carta> { new Carta(ETipo.Numero, EColor.Azul, 5) });

            Assert.AreEqual(false, partida.JugadorActual.Jugar(partida, 7));

        }

        [TestMethod]
        public void JugarValidoGritaUnoTest()
        {
            Partida partida = new Partida("Test1", "Test2");
            Jugador jugador1 = partida.Jugadores[0];
            Jugador jugador2 = partida.Jugadores[1];
            partida.AgregarCartaTirada = new Carta(ETipo.Numero, EColor.Rojo, 1);
            Carta carta1 = partida.JugadorActual[0];
            carta1 = null;

            Carta carta2 = partida.JugadorActual[1];
            carta2 = null;

            Carta carta3 = partida.JugadorActual[2];
            carta3 = null;

            partida.JugadorActual.AgregarCartas(new List<Carta> { new Carta(ETipo.Numero, EColor.Rojo, 5) });

            partida.JugadorActual.AgregarCartas(new List<Carta> { new Carta(ETipo.Numero, EColor.Rojo, 8) });

            try
            {
                partida.JugadorActual.Jugar(partida, 0);
            }
            catch (System.Exception ex)
            {

                Assert.IsInstanceOfType(ex, typeof(MensajeUnoException));
            }
    


        }

        [TestMethod]
        public void JugarValidoGanaTest()
        {
            Partida partida = new Partida("Test1", "Test2");
            Jugador jugador1 = partida.Jugadores[0];
            Jugador jugador2 = partida.Jugadores[1];
            partida.AgregarCartaTirada = new Carta(ETipo.Numero, EColor.Rojo, 1);


            Carta carta1 = partida.JugadorActual[0];
            carta1 = null;

            Carta carta2 = partida.JugadorActual[1];
            carta2 = null;

            Carta carta3 = partida.JugadorActual[2];
            carta3 = null;


            partida.JugadorActual.AgregarCartas(new List<Carta> { new Carta(ETipo.Numero, EColor.Rojo, 8) });

            try
            {
                partida.JugadorActual.Jugar(partida, 0);
            }
            catch (System.Exception ex)
            {

                Assert.IsInstanceOfType(ex, typeof(MensajeGanadorException));
            }

        }
    }
}
