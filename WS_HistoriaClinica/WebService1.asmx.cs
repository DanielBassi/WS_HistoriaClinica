using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WS_HistoriaClinica
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        //ManageDB.Consultar consultar;
        Consulta.Paciente paciente;
        DataTable dt;

        public WebService1()
        {
            paciente = new Consulta.Paciente();
            dt = new DataTable();
        }

        [WebMethod]
        public DataTable obtenerPacientes()
        {
            return paciente.selectPacientes();
        }

        [WebMethod]
        public DataTable obtenerPaciente(int id)
        {
            return paciente.selectPaciente(id);
        }

        [WebMethod]
        //string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellidos, string tipo_identificacion, string identificacion, string direccion, string telefono, string edad, string sexo, string fecha_nacimiento
        public DataTable guardarPaciente(Objetos.Paciente Datos)
        {
            return paciente.insertPaciente(Datos);
            //return paciente.insertPaciente(primer_nombre, segundo_nombre, primer_apellido, segundo_apellidos, tipo_identificacion, identificacion, direccion, telefono, edad, sexo, fecha_nacimiento);
        }

        [WebMethod]
        public DataTable actualizarPaciente(int id, Objetos.Paciente Datos)
        {
            return paciente.updatePaciente(id, Datos);
        }

        [WebMethod]
        public DataTable eliminarPaciente(int id)
        {
            return paciente.deletePaciente(id);
        }
    }
}
