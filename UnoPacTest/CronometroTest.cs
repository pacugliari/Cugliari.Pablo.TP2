using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Threading;

namespace UnoPacTest
{
    [TestClass]
    public class CronometroTest
    {
        [TestMethod]
        public void CreacionCronometroTest()
        {
            Cronometro temp = new Cronometro(1000);
            Assert.AreEqual(1000, temp.Intervalo);
        }

        [TestMethod]
        public void CorrerTiempo5SegundosTest()
        {
            Cronometro temp = new Cronometro(1000);
            temp.IniciarCronometro();
            Thread.Sleep(1000);
            string tiempoTranscurrido = temp.DetenerCronometro();

            Assert.AreEqual("00:00:01", tiempoTranscurrido);
        }

        [TestMethod]
        public void CronometroEstaActivoTest()
        {
            Cronometro temp = new Cronometro(1000);
            temp.IniciarCronometro();

            Assert.AreEqual(true, temp.EstaActivo);

            Thread.Sleep(1000);
            temp.DetenerCronometro();

            Assert.AreEqual(false, temp.EstaActivo);

        }


    }
}
