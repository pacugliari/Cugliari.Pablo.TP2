using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class ArchivosDeTexto
    {
        public static StreamWriter sw;
        public static StreamReader sr;
        public static string path;

        static ArchivosDeTexto()
        {  
            if(!Directory.Exists("..\\Archivos"))
            {
             Directory.CreateDirectory("..\\Archivos");
            }

            
        }

        public static string[] ObtenerArchivos()
        {
            return Directory.GetFiles("..\\Archivos");
        }

        public static bool AgregarAlArchivo(Log log)
        {
            bool agrego = false;
            ArchivosDeTexto.path = $"..\\Archivos\\{log.Nombre}.txt";

            try
            {
                ArchivosDeTexto.sw = new StreamWriter(ArchivosDeTexto.path, false);
                ArchivosDeTexto.sw.WriteLine(log.ToString());

               agrego = true;            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(ArchivosDeTexto.sw!=null)
                ArchivosDeTexto.sw.Close();
            }
            
            return agrego;
        }

        public static string LeerArchivoHastaElFinal(string path)
        {
            string retorno = "";
            try
            {
                using (ArchivosDeTexto.sr = new StreamReader(path))
                {
                    retorno = ArchivosDeTexto.sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }

            return retorno;
        }

        public static bool EliminarArchivo (string path)
        {
            bool elimino = false;
            try
            {
                File.Delete(path);

                elimino = true;
            }
            catch (Exception)
            {

                throw;
            }

            return elimino;
        }

    }


}
