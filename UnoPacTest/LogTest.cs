using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using System.Text;

namespace UnoPacTest
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void CreacionLogTest()
        {
            Log log = new Log("prueba");
            Assert.AreEqual("prueba", log.Nombre);
        }

        [TestMethod]
        public void ToStringLogTest()
        {
            Log log = new Log("prueba");
            log.AgregarAlLog("agregado.");
            Assert.AreEqual("agregado", log.ToString().Split('.')[0]);
        }

        [TestMethod]
        public void AgregarListaLogTest()
        {
            Log log = new Log("prueba");
            List<int> lista = new List<int> {1,2,3};
            log.AgregarAlLog(lista);

            StringBuilder textoEsperado = new StringBuilder();
            foreach (int item in lista)
            {
                textoEsperado.AppendLine(item.ToString());
            }

            Assert.AreEqual(textoEsperado.ToString(), log.ToString());
        }
    }
}
