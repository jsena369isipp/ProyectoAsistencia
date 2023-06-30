using Microsoft.Reporting.WinForms;
using Microsoft.SqlServer.Server;
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
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoAsistencia
{
    /// <summary>
    /// Lógica de interacción para VentanaPreceptor.xaml
    /// </summary>
    public partial class VentanaPreceptor : Window
    {
        //List<Clases2023.Preceptor> ListaPreceptor = new List<Clases2023.Preceptor>();
        List<Preceptor> ListaPreceptorBuscar;

        public VentanaPreceptor()
        {
            InitializeComponent();
            ClasesPublicas.LeerPreceptor();
            dg1.ItemsSource = ClasesPublicas.ListaPreceptor;
            lblCantReg.Content = "Cantidad registros: " + ClasesPublicas.ListaPreceptor.Count;
        }

        //private void btnGuardar_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (File.Exists("Preceptor.txt"))
        //        {
        //            File.Delete("Preceptor.txt");
        //        }
        //        string preceptorConcatenado = "";
        //        foreach (Preceptor objetoPreceptor in ListaPreceptor)
        //        {
        //            preceptorConcatenado = preceptorConcatenado + "\r\n" + objetoPreceptor.CodigoPreceptor + ";" + objetoPreceptor.ApellidoNombre + ";" + objetoPreceptor.DNI + ";" + objetoPreceptor.FechaNacimiento + ";" + objetoPreceptor.Estado;
        //        }
        //        File.WriteAllText("Preceptor.txt", preceptorConcatenado);
        //        MessageBox.Show("Almacenado de forma correcta!", "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Information);

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Error al guardar", "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}


        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Preceptor preceptor = (Preceptor)dg1.SelectedItem;
                if (preceptor != null)
                {
                    ClasesPublicas.ListaPreceptor.Remove(preceptor);
                    dg1.ItemsSource = ClasesPublicas.ListaPreceptor;
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
            try
            {
                Int64 dniVariable = Convert.ToInt64(txtdni.Text);
                Clases2023.Preceptor preceptor = ClasesPublicas.ListaPreceptor.Where(n => n.DNI == dniVariable).FirstOrDefault();

                if (preceptor == null)
                {

                    preceptor = new Clases2023.Preceptor();
                    preceptor.CodigoPreceptor = Convert.ToInt32(txtCodPreceptor.Text);
                    preceptor.DNI = Convert.ToInt64(txtdni.Text);
                    preceptor.ApellidoNombre = txtNombApellido.Text;
                    //preceptor.CodigoCursos = Convert.ToInt16(cbCursos.SelectedValue);
                    preceptor.Estado = Convert.ToBoolean(chbEstado.IsChecked);//<--para mostrar el estado en el DataGrid
                    preceptor.FechaNacimiento = Convert.ToDateTime(dpFechaNac.SelectedDate);

                    ClasesPublicas.ListaPreceptor.Add(preceptor);

                }
                else
                {
                    preceptor.CodigoPreceptor = Convert.ToInt32(txtCodPreceptor.Text);
                    preceptor.DNI = Convert.ToInt64(txtdni.Text);
                    preceptor.ApellidoNombre = txtNombApellido.Text;
                    //preceptor.CodigoCursos = Convert.ToInt16(cbCursos.SelectedValue);
                    preceptor.Estado = Convert.ToBoolean(chbEstado.IsChecked);//<--para mostrar el estado en el DataGrid
                    preceptor.FechaNacimiento = Convert.ToDateTime(dpFechaNac.SelectedDate);
                }
                dg1.ItemsSource = ClasesPublicas.ListaPreceptor;
                dg1.Items.Refresh();
                Guardar();
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(/*"Error: " + */ex.Message, "SIN REGISTROS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //lblCantReg.Content = "Cantidad registros: " + ListaPreceptor.Count;

        }
        private void Limpiar()
        {
            txtCodPreceptor.Text = "";
            txtdni.Text = "";
            txtNombApellido.Text = "";
            dpFechaNac.Text = string.Empty;


        }
        private void Guardar()
        {
            try
            {
                if (File.Exists("Preceptor.txt"))
                {
                    File.Delete("Preceptor.txt");
                }
                string preceptorConcatenado = "";
                foreach (Preceptor objetoPreceptor in ClasesPublicas.ListaPreceptor)
                {
                    preceptorConcatenado = preceptorConcatenado + "\r\n" + objetoPreceptor.CodigoPreceptor + ";" + objetoPreceptor.ApellidoNombre + ";" + objetoPreceptor.DNI + ";" + objetoPreceptor.FechaNacimiento + ";" + objetoPreceptor.Estado;
                }
                File.WriteAllText("Preceptor.txt", preceptorConcatenado);
                MessageBox.Show("Almacenado de forma correcta!", "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al guardar", "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void btnLeer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClasesPublicas.LeerPreceptor();
                dg1.ItemsSource = ClasesPublicas.ListaPreceptor;

                dg1.Items.Refresh();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            lblCantReg.Content = "Cantidad registros: " + ClasesPublicas.ListaPreceptor.Count;
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Preceptor preceptor = (Preceptor)dg1.SelectedItem;
                if (preceptor != null)
                {
                    txtCodPreceptor.Text = preceptor.CodigoPreceptor.ToString();
                    txtdni.Text = preceptor.DNI.ToString();
                    txtNombApellido.Text = preceptor.ApellidoNombre;
                    dpFechaNac.SelectedDate = preceptor.FechaNacimiento;
                    chbEstado.IsChecked = preceptor.Estado;
                    //cbCursos.SelectedIndex = preceptor.CodigoCursos;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaPreceptorBuscar = ClasesPublicas.ListaPreceptor;
                //X
                if (chCodPreceptor.IsChecked == true)
                {
                    int codDesde = Convert.ToInt32(txtCodDesde.Text);
                    int codHasta = Convert.ToInt32(txtCodHasta.Text);
                    ListaPreceptorBuscar = ListaPreceptorBuscar.Where(n => n.CodigoPreceptor >= codDesde && n.CodigoPreceptor <= codHasta).ToList();
                }
                if (chNombrePreceptor.IsChecked == true)
                {
                    ListaPreceptorBuscar = ListaPreceptorBuscar.Where(n => n.ApellidoNombre.Contains(txtNombreBuscar.Text)).ToList();
                }
                dgResultado.ItemsSource = ListaPreceptorBuscar;
                dgResultado.Items.Refresh();
                lblResultado.Content = "Registros encontrados: " + ListaPreceptorBuscar.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCodDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtCodHasta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCodPreceptor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtdni.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtdni_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtNombApellido.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtNombApellido_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    dpFechaNac.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void dpFechaNac_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    chbEstado.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //OK
                var stream = GetType().Assembly.GetManifestResourceStream("ProyectoAsistencia.Reportes.ListaPreceptor.rdlc");
                if (stream != null)
                {

                    ReportViewer reporViewer = new ReportViewer();
                    reporViewer.LocalReport.DataSources.Add(new ReportDataSource("DS", ListaPreceptorBuscar));
                    reporViewer.LocalReport.LoadReportDefinition(stream);

                    reporViewer.Visible = true;
                    reporViewer.RefreshReport();

                    VentanaReportes ventanaReportes = new VentanaReportes(reporViewer);
                    ventanaReportes.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCodHasta_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtCodHasta.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCodDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtCodDesde.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}