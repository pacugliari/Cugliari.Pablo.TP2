using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnoPacTest
{
    [TestClass]
    public class ArchivosDeTextoTest
    {
        [TestMethod]
        public void AgregarAlArchivoTest()
        {
            Log log = new Log("prueba");
            log.AgregarAlLog("prueba texto.");
            Assert.AreEqual(true, ArchivosDeTexto.AgregarAlArchivo(log));

        }

        [TestMethod]
        public void ObtenerArchivosTest()
        {
            Log log = new Log("prueba");
            log.AgregarAlLog("prueba texto.");
            Assert.AreEqual(true, ArchivosDeTexto.AgregarAlArchivo(log));
            string pathArchivo = ArchivosDeTexto.ObtenerArchivos()[0];
            string pathArchivoEsperado = "..\\Archivos\\prueba.txt";

            Assert.AreEqual(pathArchivo, pathArchivoEsperado);
        }



        [TestMethod]
        public void LeerArchivoHastaElFinalTest()
        {
            Log log = new Log("prueba");
            log.AgregarAlLog("prueba texto.");
            Assert.AreEqual(true, ArchivosDeTexto.AgregarAlArchivo(log));
            string textoLeido = ArchivosDeTexto.LeerArchivoHastaElFinal("..\\Archivos\\prueba.txt").Split('.')[0];
            string textoEsperado = "prueba texto";
            Assert.AreEqual(textoEsperado, textoLeido);
        }
   
        [TestMethod]
        public void EliminarArchivoTest()
        {
            Assert.AreEqual(true, ArchivosDeTexto.EliminarArchivo("..\\Archivos\\prueba.txt"));

        }


    }
}
