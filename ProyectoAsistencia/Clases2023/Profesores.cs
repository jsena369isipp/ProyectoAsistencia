using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    public class Profesores
    {
        public string NombreProfe { get; set; }
        public int IDProfesor { get; set; }
        public Int64 DNI { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public string Correo { get; set; }
        public Int64 Tel { get; set; }
        public string Domicilio { get; set; }
        public bool Estado { get; set; }
    }
}
