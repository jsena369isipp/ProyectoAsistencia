using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoAsistencia.Clases2023
{
    public class DNIEntidad
    {
        public string ApellidoYNombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public long DNI { get; set; }

        public void DatosDNI(string dniTexto)
        {
            DNIEntidad ObjetoDNI;
            string txtCompleto = dniTexto;
            ObjetoDNI = new DNIEntidad();
            string[] valores = txtCompleto.Split('@');
            int cont = 0;

            foreach (string val in valores)
            {
                if (cont == 1 || cont == 2)
                {
                    this.ApellidoYNombre += " " + val;
                }
                else if (cont == 4)
                {
                    this.DNI = Convert.ToInt64(val);
                }
                else if (cont == 6)
                {
                    this.FechaDeNacimiento = Convert.ToDateTime(val);
                }
                cont += 1;
            }
        }
    }
}
