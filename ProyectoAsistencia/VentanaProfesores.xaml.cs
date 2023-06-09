﻿using Microsoft.Reporting.WinForms;
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
        /*List<Clases2023.Profesores> ListaProfesores = new List<Clases2023.Profesores>();*/
        List<Profesores> ListaProfesorBuscar;
        public VentanaProfesores()
        {
            InitializeComponent();
            dateGrid_Fecha.SelectedDate = DateTime.Now;
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int64 IDProfesor = Convert.ToInt32(txt_ID.Text);
                Clases2023.Profesores Profesor = ClasesPublicas.ListaProfesores.Where(n => n.IDProfesor == IDProfesor).FirstOrDefault();
                if (Profesor == null)
                {
                    Profesor = new Clases2023.Profesores();
                    Profesor.NombreProfe = txt_Nombre.Text;
                    Profesor.IDProfesor = Convert.ToInt32(txt_ID.Text);
                    Profesor.DNI = Convert.ToInt32(txtDNI.Text);
                    Profesor.FechaDeAlta = dateGrid_Fecha.SelectedDate.Value;
                    Profesor.Tel = Convert.ToInt64(txtTelefono.Text);
                    Profesor.Correo = txtCorreo.Text;
                    Profesor.Domicilio = txtDomicilio.Text;
                    Profesor.Estado = checkBx_Estado.IsChecked.Value;
                    /*ListaProfesores.Add(Profesor);*/
                    ClasesPublicas.ListaProfesores.Add(Profesor);
                }
                else
                {
                    Profesor.NombreProfe = txt_Nombre.Text;
                    Profesor.IDProfesor = Convert.ToInt32(txt_ID.Text);
                    Profesor.DNI = Convert.ToInt32(txtDNI.Text);
                    Profesor.FechaDeAlta = dateGrid_Fecha.SelectedDate.Value;
                    Profesor.Tel = Convert.ToInt64(txtTelefono.Text);
                    Profesor.Correo = txtCorreo.Text;
                    Profesor.Domicilio = txtDomicilio.Text;
                    Profesor.Estado = checkBx_Estado.IsChecked.Value;
                }

                dataGrid_Resultado.ItemsSource = ClasesPublicas.ListaProfesores;
                dataGrid_Resultado.Items.Refresh();
                btnGuardar_Click(sender, e);
                MessageBox.Show("Datos cargados correctamente.", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    ClasesPublicas.ListaProfesores.Remove(profesor);
                    dataGrid_Resultado.ItemsSource = ClasesPublicas.ListaProfesores;
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

                    txt_Nombre.Text = VentanaProfesores.NombreProfe.ToString();
                    txt_ID.Text = VentanaProfesores.IDProfesor.ToString();
                    txtDNI.Text = VentanaProfesores.DNI.ToString();
                    dateGrid_Fecha.SelectedDate = VentanaProfesores.FechaDeAlta;
                    txtTelefono.Text = VentanaProfesores.Tel.ToString();
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
                foreach (Profesores objetoProfe in ClasesPublicas.ListaProfesores)
                {
                    ProfeConcatenado = ProfeConcatenado + "\r\n" + objetoProfe.NombreProfe + ";" + objetoProfe.IDProfesor + ";" + objetoProfe.DNI + ";" + objetoProfe.FechaDeAlta + ";" + objetoProfe.Tel + ";" + objetoProfe.Correo + ";" + objetoProfe.Domicilio + ";" + objetoProfe.Estado;
                }
                File.WriteAllText("Profesores.txt", ProfeConcatenado);
                MessageBox.Show("Almacenado de forma correcta!!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
                labelCant2.Content = "Cantidad de Profesores: " + ClasesPublicas.ListaProfesores.Count;
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaProfesorBuscar = ClasesPublicas.ListaProfesores;
                if (checkCodProfe.IsChecked == true)
                {
                    int codDesde, codHasta;
                    if (int.TryParse(txtDesde.Text, out codDesde) && int.TryParse(txtHasta.Text, out codHasta))
                    {
                        ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.IDProfesor >= codDesde && n.IDProfesor <= codHasta).ToList();
                    }
                    else
                    {
                        // Manejar el caso en que los valores ingresados no sean numéricos
                        MessageBox.Show("Los valores de código de profesor deben ser numéricos", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (checkNombre.IsChecked == true)
                {
                    ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.NombreProfe.Contains(txtNombre2.Text)).ToList();
                }
                if (checkDNI.IsChecked== true)
                {
                    int codDni;
                    if (int.TryParse(txtDNI2.Text, out codDni))
                    {
                        ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.DNI == codDni).ToList();
                    }
                    else
                    {
                        // Manejar el caso en que el valor ingresado para DNI no sea numérico
                        MessageBox.Show("El valor del DNI debe ser numérico", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (checkDomicilio.IsChecked == true)
                {
                    ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.Domicilio.Contains(txtDom2.Text)).ToList();
                }
                if (checkTel.IsChecked == true)
                {
                    int codTel;
                    if (int.TryParse(txtTel2.Text, out codTel))
                    {
                        ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.Tel == codTel).ToList();
                    }
                    else
                    {
                        // Manejar el caso en que el valor ingresado para Teléfono no sea numérico
                        MessageBox.Show("El valor del Teléfono debe ser numérico", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (checkCorreo.IsChecked == true)
                {
                    ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.Correo.Contains(txtCorreo2.Text)).ToList();
                }
                if (checkFecha.IsChecked == true)
                {
                    DateTime fechaDesde, fechaHasta;
                    if (DateTime.TryParse(dateGrid_FechaDesde.SelectedDate.ToString(), out fechaDesde) && DateTime.TryParse(dateGrid_FechaHasta.SelectedDate.ToString(), out fechaHasta))
                    {
                        ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.FechaDeAlta.Date >= fechaDesde.Date && n.FechaDeAlta.Date <= fechaHasta.Date).ToList();
                    }
                    else
                    {
                        // Manejar el caso en que no se hayan seleccionado fechas válidas
                        MessageBox.Show("Seleccione fechas válidas de inicio y fin", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (checkBx_Estado2.IsChecked == true)
                {
                    bool codEstado = (bool)checkBx_Estado2.IsChecked;
                    ListaProfesorBuscar = ListaProfesorBuscar.Where(n => n.Estado == codEstado).ToList();
                }
                dataGrid_Resultado2.ItemsSource = ListaProfesorBuscar;
                dataGrid_Resultado2.Items.Refresh();
                labelCant.Content = "Registros encontrados: " + ListaProfesorBuscar.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtDesde.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtHasta_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtHasta.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /*Saltar cajas con Enter*/
        private void txtID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txt_Nombre.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtNombre_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDNI.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDNI_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDomicilio.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDomicilio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtTelefono.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtTelefono_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtCorreo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCorrreo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    dateGrid_Fecha.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /*Saltar cajas con enter buscador*/

        private void txtDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtHasta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtHasta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtNombre2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtNombre2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDNI2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDNI2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDom2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDom2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtTel2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtTel2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtCorreo2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCorreo2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    dateGrid_FechaDesde.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void FechaDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    dateGrid_FechaHasta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stream = GetType().Assembly.GetManifestResourceStream("ProyectoAsistencia.Reportes.ListaProfesores.rdlc");
                if (stream != null)
                {

                    ReportViewer reporViewer = new ReportViewer();
                    reporViewer.LocalReport.DataSources.Add(new ReportDataSource("dsProfesores", ListaProfesorBuscar));
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
    }
}
