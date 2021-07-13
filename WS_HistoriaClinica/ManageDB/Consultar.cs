using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace WS_HistoriaClinica.ManageDB
{
    public class Consultar
    {
        private Conectar conexionManager_SQL;
        private DataSet ds;
        private DataTable datos;

        public Consultar()
        {
            ds = new DataSet();
            datos = new DataTable();
        }

        public DataTable ejecutarQuery_SQL(string query)
        {
            conexionManager_SQL = new Conectar();

            try
            {
                conexionManager_SQL.iniciarConexion_SQL();
                datos = conexionManager_SQL.ejecutarQuery_SQL(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexionManager_SQL.cerrarConexion_SQL();
            }

            ds.Tables.Add(datos);
            return ds.Tables[0];
        }
    }
}