using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Importante para conectarse a la DB */
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WS_HistoriaClinica.ManageDB
{
    public class Conectar
    {
        private string cadenaConexion;
        private SqlConnection conexion_SQL;
        private SqlCommand comando_SQL;
        private SqlDataAdapter datos_SQL;
        private SqlTransaction transaccion_SQL;

        public Conectar()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["HistoriaDB"].ConnectionString;
        }

        public void iniciarConexion_SQL()
        {
            try
            {
                conexion_SQL = new SqlConnection(cadenaConexion);
                conexion_SQL.Open();
                comando_SQL = new SqlCommand();
                comando_SQL.Connection = conexion_SQL;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ejecutarQuery_SQL(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                comando_SQL.CommandTimeout = 0;
                comando_SQL.CommandText = query;
                SqlCommand command = new SqlCommand(query, conexion_SQL);
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion_SQL()
        {
            try
            {
                if (conexion_SQL != null) /*IsNot Nothing*/
                {
                    conexion_SQL.Close();
                    conexion_SQL.Dispose();
                }

                if (comando_SQL != null)
                {
                    comando_SQL.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}