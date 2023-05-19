using ProyectoAsistencia.Clases2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoAsistencia
{

    public partial class Ventana_Alumno : Window
    {
        public Ventana_Alumno()
        {
            InitializeComponent();
        }

        List<Alumno> ListaAlumnos = new List<Alumno>();

        private void BtnCargar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int64 VariableDni = Convert.ToInt64(TxtDNI.Text);
                Alumno ObjAlumno = ListaAlumnos.Where(n => n.Dni == VariableDni).FirstOrDefault();
                if (ObjAlumno != null)
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.Dni = VariableDni;
                    ObjAlumno.CodigoCurso = Convert.ToInt32(TxtCodCurso.Text);
                    ObjAlumno.CodigoAlumno = Convert.ToInt32(TxtCodAlumno.Text);
                    ObjAlumno.NombreApellido = TxtNomApellido.Text;
                    ObjAlumno.Estado = CheckEstado.IsChecked.Value;
                    ObjAlumno.FechaNacimiento = DateFechaNac.SelectedDate.Value;
                    ObjAlumno.Domicilio = TxtDomicilio.Text;
                    ObjAlumno.Tel = Convert.ToInt64(TxtTelefono.Text);
                    ObjAlumno.CorreoElectronico = TxtCorreo.Text;
                    ObjAlumno.FechaIngreso = DateFechaIngreso.SelectedDate.Value;

                    ListaAlumnos.Add(ObjAlumno);
                }
                else 
                {
                    ObjAlumno.Dni = Convert.ToInt64(TxtTelefono.Text);
                    ObjAlumno.CodigoCurso = Convert.ToInt32(TxtCodCurso.Text);
                    ObjAlumno.CodigoAlumno = Convert.ToInt32(TxtCodAlumno.Text);
                    ObjAlumno.NombreApellido = TxtNomApellido.Text;
                    ObjAlumno.Estado = CheckEstado.IsChecked.Value;
                    ObjAlumno.FechaNacimiento = DateFechaNac.SelectedDate.Value;
                    ObjAlumno.Domicilio = TxtDomicilio.Text;
                    ObjAlumno.Tel = Convert.ToInt64(TxtTelefono.Text);
                    ObjAlumno.CorreoElectronico = TxtCorreo.Text;
                    ObjAlumno.FechaIngreso = DateFechaIngreso.SelectedDate.Value;
                }
                DgAlumno.ItemsSource = ListaAlumnos;
                DgAlumno.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno ObjAlumnoEliminar = (Alumno)DgAlumno.SelectedItem;
                if (ObjAlumnoEliminar != null)
                {
                    ListaAlumnos.Remove(ObjAlumnoEliminar);
                    DgAlumno.ItemsSource = ListaAlumnos;
                    DgAlumno.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void DgAlumno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Alumno ObjAlumno = (Alumno)DgAlumno.SelectedItem;
                if (ObjAlumno != null)
                {
                    TxtCodCurso.Text = ObjAlumno.CodigoCurso.ToString();
                    TxtCodAlumno.Text = ObjAlumno.CodigoAlumno.ToString();
                    TxtDNI.Text = ObjAlumno.Dni.ToString();
                    TxtNomApellido.Text = ObjAlumno.NombreApellido;
                    CheckEstado.IsChecked = ObjAlumno.Estado;
                    DateFechaNac.SelectedDate = ObjAlumno.FechaNacimiento;
                    TxtDomicilio.Text = ObjAlumno.Domicilio;
                    TxtTelefono.Text = ObjAlumno.Tel.ToString();
                    TxtCorreo.Text = ObjAlumno.CorreoElectronico;
                    DateFechaIngreso.SelectedDate = ObjAlumno.FechaIngreso;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLeer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
