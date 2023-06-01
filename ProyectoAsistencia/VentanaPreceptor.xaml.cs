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
    /// Lógica de interacción para VentanaPreceptor.xaml
    /// </summary>
    public partial class VentanaPreceptor : Window
    {
        List<Clases2023.Preceptor> ListaPreceptor = new List<Clases2023.Preceptor>();

        public VentanaPreceptor()
        {

            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
           
        }


        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Preceptor preceptor = (Preceptor)dg1.SelectedItem;
                if (preceptor != null)
                {
                    ListaPreceptor.Remove(preceptor);
                    dg1.ItemsSource = ListaPreceptor;
                    dg1.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Seleccionar item!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            Int64 dniVariable = Convert.ToInt64(txtdni.Text);
            Clases2023.Preceptor preceptor = ListaPreceptor.Where(n => n.DNI == dniVariable).FirstOrDefault();

            try
            {
                if (preceptor == null)
                {

                    preceptor = new Clases2023.Preceptor();
                    preceptor.CodigoPreceptor = Convert.ToInt32(txtCodPreceptor.Text);
                    preceptor.DNI = Convert.ToInt64(txtdni.Text);
                    preceptor.ApellidoNombre = txtNombApellido.Text;
                    preceptor.CodigoCursos = cbCursos.SelectedIndex;
                    preceptor.Estado = Convert.ToBoolean(chbEstado.IsChecked);//<--para mostrar el estado en el DataGrid
                    preceptor.FechaNacimiento = Convert.ToDateTime(dpFechaNac.SelectedDate);

                    ListaPreceptor.Add(preceptor);

                }
                else
                {
                    preceptor.CodigoPreceptor = Convert.ToInt32(txtCodPreceptor.Text);
                    preceptor.DNI = Convert.ToInt64(txtdni.Text);
                    preceptor.ApellidoNombre = txtNombApellido.Text;
                    preceptor.CodigoCursos = cbCursos.SelectedIndex;
                    preceptor.Estado = Convert.ToBoolean(chbEstado.IsChecked);//<--para mostrar el estado en el DataGrid
                    preceptor.FechaNacimiento = Convert.ToDateTime(dpFechaNac.SelectedDate);
                }
                dg1.ItemsSource = ListaPreceptor;
                dg1.Items.Refresh();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btnLeer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
