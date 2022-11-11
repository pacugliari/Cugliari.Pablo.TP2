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

        /// <summary>
        /// Constructor estatico, verifica si existe el directorio donde se almacenaran los archivos y
        /// sino lo crea
        /// </summary>
        static ArchivosDeTexto()
        {  
            if(!Directory.Exists("..\\Archivos"))
            {
             Directory.CreateDirectory("..\\Archivos");
            }

            
        }

        /// <summary>
        /// Devuelve un array de string con los paths de todos los archivos del directorio actual
        /// </summary>
        /// <returns></returns>
        public static string[] ObtenerArchivos()
        {
            return Directory.GetFiles("..\\Archivos");
        }

        /// <summary>
        /// Escribe en el archivo el ToString del log pasado por parametro
        /// </summary>
        /// <param name="log">Contiene la informacion a escribir en el archivo</param>
        /// <returns>si pudo agregar el log retorna true, sino false</returns>
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

        /// <summary>
        /// Lee el archivo del path pasado por parametro de manera completa escribiendolo en un string
        /// </summary>
        /// <param name="path">path del archivo a leer</param>
        /// <returns>string con la informacion leida del archivo</returns>
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

        /// <summary>
        /// Elimina un archivo del directorio pasado por parametro
        /// </summary>
        /// <param name="path">path del archivo a borrar</param>
        /// <returns>si pudo borrarlo retorna true sino false</returns>
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
