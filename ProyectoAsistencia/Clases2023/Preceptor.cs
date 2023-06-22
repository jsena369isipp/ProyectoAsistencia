using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    public class Preceptor
    {
         public int CodigoPreceptor { get; set; }
         public string ApellidoNombre { get; set; }        
         //public int CodigoCursos { get; set; }
         public long DNI { get; set; }
         public DateTime FechaNacimiento { get; set; }
         public bool Estado { get; set; }

    }
}
