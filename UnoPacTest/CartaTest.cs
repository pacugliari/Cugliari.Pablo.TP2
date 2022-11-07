using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnoPacTest
{
    [TestClass]
    public class CartaTest
    {
        [TestMethod]
        public void CreacionDeCartaTipoColorValidoTest()
        {

            Carta masDosAmarillo = new Carta(ETipo.MasDos, EColor.Amarillo);
            Carta salteoAzul = new Carta(ETipo.Salteo, EColor.Azul);
            Carta invertirRojo = new Carta(ETipo.Invertir, EColor.Rojo);
            Carta masCuatro = new Carta(ETipo.MasCuatro, EColor.Negro);
            Carta cambioColor = new Carta(ETipo.CambioColor, EColor.Negro);
            

            Assert.AreEqual(masDosAmarillo.Tipo, ETipo.MasDos);
            Assert.AreEqual(masDosAmarillo.Color, EColor.Amarillo);
            Assert.AreEqual(masDosAmarillo.Numero, -1);

            Assert.AreEqual(salteoAzul.Tipo, ETipo.Salteo);
            Assert.AreEqual(salteoAzul.Color, EColor.Azul);
            Assert.AreEqual(salteoAzul.Numero, -2);

            Assert.AreEqual(invertirRojo.Tipo, ETipo.Invertir);
            Assert.AreEqual(invertirRojo.Color, EColor.Rojo);
            Assert.AreEqual(invertirRojo.Numero, -3);

            Assert.AreEqual(cambioColor.Tipo, ETipo.CambioColor);
            Assert.AreEqual(cambioColor.Color, EColor.Negro);
            Assert.AreEqual(cambioColor.Numero, -4);

            Assert.AreEqual(masCuatro.Tipo, ETipo.MasCuatro);
            Assert.AreEqual(masCuatro.Color, EColor.Negro);
            Assert.AreEqual(masCuatro.Numero, -5);

        }


        [TestMethod]
        public void CreacionDeCartaTipoColorInvalidoTest()
        {

            try
            {
                Carta numeroVerde = new Carta(ETipo.Numero, EColor.Verde);
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(CreacionCartaException));

            }

            try
            {
                Carta masCuatroError = new Carta(ETipo.MasCuatro, EColor.Amarillo);
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(CreacionCartaException));

            }

            try
            {
                Carta cambioColorError = new Carta(ETipo.CambioColor, EColor.Azul);
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(CreacionCartaException));

            }

            try
            {
                Carta masDosAzulError = new Carta(ETipo.MasDos, EColor.Azul);
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(CreacionCartaException));

            }
        }

        [TestMethod]
        public void CreacionCartaPorTipoColorYNumeroValidoTest()
        {
            Carta c1 = new Carta(ETipo.Numero, EColor.Azul,5);

            Assert.AreEqual(c1.Numero,5);
            Assert.AreEqual(c1.Color, EColor.Azul);
            Assert.AreEqual(c1.Tipo, ETipo.Numero);

        }

        [TestMethod]
        public void CreacionCartaPorTipoColorYNumeroInvalidoTest()
        {
            
            try
            {
                Carta c1 = new Carta(ETipo.Numero, EColor.Azul, 10);
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(CreacionCartaException));
            }

        }

        [TestMethod]
        public void ComparacionCartasPorIgualValidoTest()
        {
            Carta c1 = new Carta(ETipo.MasDos, EColor.Azul);
            Carta c2 = new Carta(ETipo.MasDos, EColor.Azul);

            Assert.AreEqual(true, c1 == c2);

        }

        [TestMethod]
        public void ComparacionCartasPorDistintoValidoTest()
        {
            Carta c1 = new Carta(ETipo.MasDos, EColor.Azul);
            Carta c2 = new Carta(ETipo.MasDos, EColor.Amarillo);

            Assert.AreEqual(true, c1 != c2);

        }

        [TestMethod]
        public void ToStringCartaEspecialTest()
        {
            Carta c1 = new Carta(ETipo.MasDos, EColor.Azul);

            Assert.AreEqual("Tipo: MasDos Color: Azul", c1.ToString());

        }

        [TestMethod]
        public void ToStringCartaComunTest()
        {
            Carta c1 = new Carta(ETipo.Numero, EColor.Azul,8);

            Assert.AreEqual("Tipo: Numero Color: Azul Numero: 8", c1.ToString());

        }

        [TestMethod]
        public void EqualsValidoTest()
        {
            Carta c1 = new Carta(ETipo.MasDos, EColor.Azul);
            Carta c2 = new Carta(ETipo.MasDos, EColor.Azul);

            Assert.AreEqual(true, c1.Equals(c2));

        }

        [TestMethod]
        public void EqualsInvalidoTest()
        {
            Carta c1 = new Carta(ETipo.MasDos, EColor.Azul);
            Carta c2 = new Carta(ETipo.MasDos, EColor.Amarillo);

            Assert.AreEqual(false, c1.Equals(c2));

        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Carta c1 = new Carta(ETipo.MasDos, EColor.Azul);
            int hash = c1.GetHashCode();

            Assert.AreEqual(hash, c1.GetHashCode());

        }
    }
}


