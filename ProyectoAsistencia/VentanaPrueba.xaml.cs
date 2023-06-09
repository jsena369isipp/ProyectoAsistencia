﻿using Microsoft.Reporting.WinForms;
using ProyectoAsistencia.Clases2023;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para VentanaPrueba.xaml
    /// </summary>
    public partial class VentanaPrueba : Window
    {
        List<Alumno> listaAlumnoBuscar;
        public VentanaPrueba()
        {
            InitializeComponent();
            ClasesPublicas.LeerArchivoAlumno();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //DNIEntidad dNIEntidad = new DNIEntidad();
                //dNIEntidad.DatosDNI("00636119460@SENA@JUAN ESTEBAN@M@30633343@B@10/03/1984@10/08/2020@208");
                //MessageBox.Show(dNIEntidad.ApellidoYNombre);

                listaAlumnoBuscar = ClasesPublicas.ListaAlumnos;
                //X
                if (chCodAlumno.IsChecked == true)
                {
                    int codDesde = Convert.ToInt32(txtCodDesde.Text);
                    int codHasta = Convert.ToInt32(txtCodHasta.Text);
                    listaAlumnoBuscar = listaAlumnoBuscar.Where(n => n.CodigoAlumno >= codDesde && n.CodigoAlumno <= codHasta).ToList();
                }
                if (chNombreAlumno.IsChecked == true)
                {
                    listaAlumnoBuscar = listaAlumnoBuscar.Where(n => n.NombreApellido.Contains(txtNombreBuscar.Text)).ToList();
                }
                dgResultado.ItemsSource = listaAlumnoBuscar;
                dgResultado.Items.Refresh();
                lblResultado.Content = "Registros encontrados: " + listaAlumnoBuscar.Count;
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

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stream = GetType().Assembly.GetManifestResourceStream("ProyectoAsistencia.Reportes.ListaAlumnos.rdlc");
                if (stream != null)
                {
                    
                    ReportViewer reporViewer = new ReportViewer();
                    reporViewer.LocalReport.DataSources.Add(new ReportDataSource("DS", listaAlumnoBuscar));
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
