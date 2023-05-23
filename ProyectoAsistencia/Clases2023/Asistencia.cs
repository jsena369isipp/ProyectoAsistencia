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
        public string CodigoCurso { get; set; }
        public int CodigoPreceptor { get; set; }
        public int IdMateria { get; set; }
        public bool AlumnoAsistencia { get; set; }
    }
}
