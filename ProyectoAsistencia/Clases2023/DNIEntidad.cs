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
                if (cont == 0)
                {
                    this.ApellidoYNombre = val;
                }
                else if (cont == 1)
                {
                    this.FechaDeNacimiento = Convert.ToDateTime(val);
                }
                else if (cont == 2)
                {
                    this.DNI = Convert.ToInt64(val);
                }
                cont += 1;
            }
        }
    }
}
