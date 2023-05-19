using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    internal class Asistencia
    {
        public int IdAsistencia { get; set; }
        public DateTime Fecha { get; set; }
        public string Curso { get; set; }
        public string Preceptor { get; set; }
        public string Materia { get; set; }
        public bool AlumnoAsistencia { get; set; }
    }
}
