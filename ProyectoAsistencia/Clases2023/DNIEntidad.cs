using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoAsistencia.Clases2023
{
    public class DNIEntidad
    {
        public string ApellidoYNombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public long DNI { get; set; }
        /*public bool VerificarFormato(string texto)
        {
            string patron = @"^\d{11}@[\w\s]+@[\w\s]+@[MF]@\d{8}@.\d{1,2}/\d{1,2}/\d{4}@\d+$";

            return Regex.IsMatch(texto, patron);
        }*/
        public void DatosDNI(string dniTexto)
        {
            /*if (!VerificarFormato(dniTexto))
            {
                MessageBox.Show("El formato del texto no es válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }*/

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
