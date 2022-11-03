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

        /*
        public static bool SobreescribirElArchivo(List<Persona> lista)
        {
            bool agrego = false;
            try
            {
                using(ArchivosDeTexto.sw = new StreamWriter(ArchivosDeTexto.path))
                {
                 foreach (Persona item in lista)
                 {
                  ArchivosDeTexto.sw.WriteLine(item.ToString());
                 }
                }              
                agrego = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return agrego;
        }

        public static List<Persona> LeerArchivoLineaALinea()
        {
            string retorno = "";
            List<Persona> lista = new List<Persona>();
            try
            {
                using (ArchivosDeTexto.sr = new StreamReader(ArchivosDeTexto.path))
                {
                    while ((retorno = ArchivosDeTexto.sr.ReadLine()) != null)
                    {
                        string[] persona = retorno.Split(" - ");

                        Empleado p = new Empleado(persona[0], int.Parse(persona[1]), double.Parse(persona[2]));

                        lista.Add(p);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lista;
        }

        public static string LeerArchivoHastaElFinal()
        {
            string retorno = "";
            try
            {
                using (ArchivosDeTexto.sr = new StreamReader(ArchivosDeTexto.path))
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

        */
       
    }


}
