using ProyectoAsistencia.Clases2023;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// <summary>
    /// Lógica de interacción para VentanaProfesores.xaml
    /// </summary>
    public partial class VentanaProfesores : Window
    {
        List<Clases2023.Profesores> ListaProfesores = new List<Clases2023.Profesores>();
        public VentanaProfesores()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int64 IDProfesor = Convert.ToInt32(txt_ID.Text);
                Clases2023.Profesores Profesor = ListaProfesores.Where(n => n.IDProfesor == IDProfesor).FirstOrDefault();
                if (Profesor == null)
                {
                    Profesor = new Clases2023.Profesores();
                    Profesor.Nombre = txt_Nombre.Text;
                    Profesor.IDProfesor = Convert.ToInt32(txt_ID.Text);
                    Profesor.DNI = Convert.ToInt32(txtDNI.Text);
                    Profesor.FechaDeAlta = dateGrid_Fecha.SelectedDate.Value;
                    Profesor.Tel = txtTelefono.Text;
                    Profesor.Correo = txtCorreo.Text;
                    Profesor.Domicilio = txtDomicilio.Text;
                    Profesor.Estado = checkBx_Estado.IsChecked.Value;
                    ListaProfesores.Add(Profesor);
                }
                else
                {
                    Profesor.Nombre = txt_Nombre.Text;
                    Profesor.IDProfesor = Convert.ToInt32(txt_ID.Text);
                    Profesor.DNI = Convert.ToInt32(txtDNI.Text);
                    Profesor.FechaDeAlta = dateGrid_Fecha.SelectedDate.Value;
                    Profesor.Tel = txtTelefono.Text;
                    Profesor.Correo = txtCorreo.Text;
                    Profesor.Domicilio = txtDomicilio.Text;
                    Profesor.Estado = checkBx_Estado.IsChecked.Value;
                }

                dataGrid_Resultado.ItemsSource = ListaProfesores;
                dataGrid_Resultado.Items.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Profesores profesor = (Profesores)dataGrid_Resultado.SelectedItem;
                if (profesor != null)
                {
                    ListaProfesores.Remove(profesor);
                    dataGrid_Resultado.ItemsSource = ListaProfesores;
                    dataGrid_Resultado.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGrid_Resultado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Profesores VentanaProfesores = (Profesores)dataGrid_Resultado.SelectedItem;
                if (VentanaProfesores != null)
                {

                    txt_Nombre.Text = VentanaProfesores.Nombre.ToString();
                    txt_ID.Text = VentanaProfesores.IDProfesor.ToString();
                    txtDNI.Text = VentanaProfesores.DNI.ToString();
                    dateGrid_Fecha.SelectedDate = VentanaProfesores.FechaDeAlta;
                    txtTelefono.Text = VentanaProfesores.Tel;
                    txtCorreo.Text = VentanaProfesores.Correo;
                    txtDomicilio.Text = VentanaProfesores.Domicilio;
                    checkBx_Estado.IsChecked = VentanaProfesores.Estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("Profesores.text"))
                {
                    File.Delete("Profesores.text");
                }
                string ProfeConcatenado = "";
                foreach (Profesores objetoProfe in ListaProfesores)
                {
                    ProfeConcatenado = ProfeConcatenado + "\r\n" + objetoProfe.Nombre + ";" + objetoProfe.IDProfesor + ";" + objetoProfe.DNI + ";" + objetoProfe.FechaDeAlta + ";" + objetoProfe.Tel + ";" + objetoProfe.Correo + ";" + objetoProfe.Domicilio + ";" + objetoProfe.Estado;
                }
                File.WriteAllText("Profesores.txt", ProfeConcatenado);
                MessageBox.Show("Almacenado de forma correcta!!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClasesPublicas.LeerArchivoProfesores();
                dataGrid_Resultado.ItemsSource = ClasesPublicas.ListaProfesores;
                dataGrid_Resultado.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
