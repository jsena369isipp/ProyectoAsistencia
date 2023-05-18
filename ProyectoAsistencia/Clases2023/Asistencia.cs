using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    internal class Asistencia
    {
        public bool Presente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMateria { get; set; }
        public int IdPreceptor { get; set; }
        public int IdCurso { get; set; }
    }
}
