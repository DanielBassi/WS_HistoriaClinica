using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_HistoriaClinica.Objetos
{
    public class Paciente
    {
        public int id;
        public string primer_nombre;
        public string segundo_nombre;
        public string primer_apellido;
        public string segundo_apellido;
        public string tipo_identificacion;
        public string identificacion;
        public string telefono;
        public string direccion;
        public int edad;
        public string sexo;
        public string fecha_nacimiento;
    }
}