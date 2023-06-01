using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    public class Profesores
    {
        public string Nombre { get; set; }
        public int IDProfesor { get; set; }
        public long DNI { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public string Correo { get; set; }
        public string Tel { get; set; }
        public string Domicilio { get; set; }
        public bool Estado { get; set; }
    }
}
