using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    internal class Alumno
    {
        public int CodigoCurso { get; set; }

        public int CodigoAlumno { get; set; }

        public Int64 Dni { get; set; }

        public string NombreApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Domicilio { get; set;}

        public Int64 Tel { get; set; }

        public string CorreoElectronico { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaIngreso { get; set; }
    }
}
