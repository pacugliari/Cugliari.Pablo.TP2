using System;
using System.Data;
using System.Collections.Generic;
using System.Text.Json;
using System.Data.SqlClient;

namespace Entidades
{
    public static class SQL
    {
        private static string cadena_conexion;
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;

        static SQL()
        {
            SQL.cadena_conexion = @"Server=localhost;Database=UnoPac;Trusted_Connection=True;";
            
            try
            {
                SQL.conexion = new SqlConnection(SQL.cadena_conexion);
            }
            catch (Exception)
            {

                throw new SqlConexionException("Error en la conexion con la base de datos");
            }

        }



        public static bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                SQL.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (SQL.conexion.State == ConnectionState.Open)
                {
                    SQL.conexion.Close();
                }
            }

            return rta;
        }


        public static List<PartidaSQL> ObtenerListaDato()
        {
            List<PartidaSQL> lista = new List<PartidaSQL>();

            try
            {
                SQL.comando = new SqlCommand();
                SQL.comando.CommandType = CommandType.Text;
                SQL.comando.CommandText = "SELECT * FROM partidas";
                SQL.comando.Connection = SQL.conexion;
                SQL.conexion.Open();

                SQL.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    //lector[0] es id
                    //lector[1] es string JSON de la partida
                    PartidaSQL item = JsonSerializer.Deserialize<PartidaSQL>(lector[1].ToString());
                    item.Id = (int)lector[0];
                    lista.Add(item);
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (SQL.conexion.State == ConnectionState.Open)
                {
                    SQL.conexion.Close();
                }
            }

            return lista;
        }


        public static bool AgregarDato(PartidaSQL dato)
        {
            bool rta = true;

            try
            {

                string sql = "INSERT INTO partidas (partida_json) VALUES(";
                sql = sql + "'" + JsonSerializer.Serialize(dato) + "')";

                SQL.comando = new SqlCommand();
                SQL.comando.CommandType = CommandType.Text;
                SQL.comando.CommandText = sql;
                SQL.comando.Connection = SQL.conexion;
                SQL.conexion.Open();

                int filasAfectadas = SQL.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (SQL.conexion.State == ConnectionState.Open)
                {
                    SQL.conexion.Close();
                }
            }

            return rta;
        }


        public static bool EliminarDato(int id)
        {
            bool rta = true;

            try
            {
                SQL.comando = new SqlCommand();

                SQL.comando.Parameters.AddWithValue("@id", id);

                string sql = "DELETE FROM partidas ";
                sql += "WHERE id = @id";

                SQL.comando.CommandType = CommandType.Text;
                SQL.comando.CommandText = sql;
                SQL.comando.Connection = SQL.conexion;

                SQL.conexion.Open();

                int filasAfectadas = SQL.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (SQL.conexion.State == ConnectionState.Open)
                {
                    SQL.conexion.Close();
                }
            }

            return rta;
        }

    }
}
