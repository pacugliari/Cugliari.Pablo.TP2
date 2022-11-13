using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace UnoPacTest
{
    [TestClass]
    public class MazoTest
    {
        [TestMethod]
        public void CreacionMazoTest()
        {
            Mazo mazo = new Mazo();
            Assert.AreEqual(108, mazo.CantidadCartas);
        }

        [TestMethod]
        public void ObtenerCartasMazoTest()
        {
            Mazo mazo = new Mazo();
            Partida partida = new Partida("Prueba1", "Prueba2");


            List<Carta> cartas = new List<Carta>();

            cartas = mazo.ObtenerCartas(partida, 108);

            Assert.AreEqual(0, mazo.CantidadCartas);
            Assert.AreEqual(108, cartas.Count);
        }

        [TestMethod]
        public void ContarCartasMazoTest()
        {
            Mazo mazo = new Mazo();
            Partida partida = new Partida("Prueba1", "Prueba2");


            List<Carta> cartas = new List<Carta>();

            cartas = mazo.ObtenerCartas(partida, 108);

            Dictionary<ETipo, int> cartasConCantidad = new Dictionary<ETipo, int>();
            foreach (Carta item in cartas)
            {
                if (!cartasConCantidad.ContainsKey(item.Tipo))
                {
                    cartasConCantidad.Add(item.Tipo, 1);
                }
                else
                {
                    cartasConCantidad[item.Tipo]++;
                }
            }

            Assert.AreEqual(4, cartasConCantidad[ETipo.CambioColor]);
            Assert.AreEqual(4, cartasConCantidad[ETipo.MasCuatro]);
            Assert.AreEqual(8, cartasConCantidad[ETipo.Invertir]);
            Assert.AreEqual(8, cartasConCantidad[ETipo.MasDos]);
            Assert.AreEqual(76, cartasConCantidad[ETipo.Numero]);
            Assert.AreEqual(8, cartasConCantidad[ETipo.Salteo]);

        }

        [TestMethod]
        public void MazoSinCartasTest()
        {
            Mazo mazo = new Mazo();
            Partida partida = new Partida("Prueba1", "Prueba2");
            partida.CartasTiradas.Clear();

            List<Carta> cartas = new List<Carta>();

            cartas = mazo.ObtenerCartas(partida, 108);
            foreach (Carta item in cartas)
            {
                partida.AgregarCartaTirada = item;
            }
            cartas.Clear();

            Assert.AreEqual(0, mazo.CantidadCartas);
            Assert.AreEqual(108, partida.CartasTiradas.Count);

            cartas = mazo.ObtenerCartas(partida, 1);

            Assert.AreEqual(1, partida.CartasTiradas.Count);
            Assert.AreEqual(106, mazo.CantidadCartas);
            Assert.AreEqual(1, cartas.Count);

        }

    }
}
