using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace WS_HistoriaClinica.Consulta
{
    public class Paciente
    {
        private string table;
        private DataTable dt;
        private DataSet ds;
        private ManageDB.Consultar consultar;

        public Paciente()
        {
            table = "pacientes";
            dt = new DataTable();
            ds = new DataSet();
            consultar = new ManageDB.Consultar();
        }

        public DataTable selectPacientes(string columns = "*")
        { 
            return consultar.ejecutarQuery_SQL("SELECT " + columns + " FROM " + table + " WITH (NOLOCK)");
        }

        public DataTable selectPaciente(int id)
        {
            return consultar.ejecutarQuery_SQL("SELECT * FROM " + table + " WHERE id = " + id);
        }

        //string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string tipo_identificacion, string identificacion, string direccion, string telefono, string edad , string sexo , string fecha_nacimiento
        public DataTable insertPaciente( Objetos.Paciente Datos )
        {
            return consultar.ejecutarQuery_SQL($"INSERT INTO pacientes(" +
                $"primer_nombre" +
                $",segundo_nombre" +
                $",primer_apellido" +
                $",segundo_apellido" +
                $",tipo_identificacion" +
                $",identificacion" +
                $",direccion" +
                $",telefono" +
                $",edad" +
                $",sexo" +
                $",fecha_nacimiento)" +
                $"VALUES(" +
                $"'{Datos.primer_nombre}'" +
                $",'{Datos.segundo_nombre}'" +
                $",'{Datos.primer_apellido}'" +
                $",'{Datos.segundo_apellido}'" +
                $",'{Datos.tipo_identificacion}'" +
                $",'{Datos.identificacion}'" +
                $",'{Datos.direccion}'" +
                $",'{Datos.telefono}'" +
                $",'{Datos.edad}'" +
                $",'{Datos.sexo}'" +
                $",'{Datos.fecha_nacimiento}')");
        }

        public DataTable updatePaciente(int id, Objetos.Paciente Datos)
        {
            return consultar.ejecutarQuery_SQL($@"UPDATE pacientes set
                primer_nombre = '{Datos.primer_nombre}'
                ,segundo_nombre = '{Datos.segundo_nombre}'
                ,primer_apellido = '{Datos.primer_apellido}'
                ,segundo_apellido = '{Datos.segundo_apellido}'
                ,tipo_identificacion = '{Datos.tipo_identificacion}'
                ,identificacion = '{Datos.identificacion}'
                ,telefono = '{Datos.telefono}'
                ,direccion = '{Datos.direccion}'
                ,sexo = '{Datos.sexo}'
                ,edad = '{Datos.edad}'
                ,fecha_nacimiento = '{Datos.fecha_nacimiento}'
                WHERE id = '{id}'");
        }

        public DataTable deletePaciente(int id)
        {
            return consultar.ejecutarQuery_SQL($"DELETE pacientes WHERE id = {id}");
        }
    
    }
}