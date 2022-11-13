using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;


namespace UnoPacTest
{
    [TestClass]
    public class PartidaTest
    {
        [TestMethod]
        public void PropiedadesTest()
        {
            Partida partida = new Partida("Test1", "Test2");

            ///Se reparten 7 cartas para cada jugador + 1 para tirar en la mesa, 108 - 15 = 93

            Assert.AreEqual(93, partida.Mazo.CantidadCartas);
            Assert.AreEqual(true, partida.UltimaCartaTirada is not null);
            Assert.AreEqual(1, partida.CartasTiradas.Count);
            Assert.AreEqual(1, partida.CartasTiradas.Count);
            partida.AgregarCartaTirada = partida.Mazo.ObtenerCartas(partida, 1)[0];
            Assert.AreEqual(2, partida.CartasTiradas.Count);
            Assert.AreEqual(2, partida.Jugadores.Count);
            Assert.AreEqual(partida.UltimaCartaTirada.Color, partida.ColorActual);

        }

        [TestMethod]
        public void SiguienteJugadorTest()
        {
            Partida partida = new Partida("Test1", "Test2");
            if(partida.IndiceJugadorActual == (int)EJugadores.Jugador1)
            {
                partida.SiguienteJugador();
                Assert.AreEqual((int)EJugadores.Jugador2, partida.IndiceJugadorActual);
                Assert.AreEqual(partida.Jugadores[1], partida.JugadorActual);
            }
            else
            {
                partida.SiguienteJugador();
                Assert.AreEqual((int)EJugadores.Jugador1, partida.IndiceJugadorActual);
                Assert.AreEqual(partida.Jugadores[0], partida.JugadorActual);
            }

        }
    }
}
