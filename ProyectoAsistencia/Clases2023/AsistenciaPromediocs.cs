using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    public class AsistenciaPromedio
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Materia { get; set; }
        public string NombreAlumno { get; set; }
        public int DíasClases { get; set; }
        public int DíasAsistencias { get; set; }
        public decimal Promedio { get; set; }
        public int CodigoAlumno { get; set; }
    }
}
