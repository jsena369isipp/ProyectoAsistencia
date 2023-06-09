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
    /// Lógica de interacción para Cursos.xaml
    /// </summary>
    public partial class VentanaCursos : Window
    {
        List<Cursos> ListaCursosBuscar;
        public VentanaCursos()
        {
            InitializeComponent();

            txtCurso.Focus();
            ClasesPublicas.LeerPreceptor();
            cmbPreceptor.ItemsSource = ClasesPublicas.ListaPreceptor;
            ClasesPublicas.LeerArchivoCursos();
            DatosDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 DescripcionVariable = Convert.ToInt32(txtCurso.Text);
                Cursos objCursos = ClasesPublicas.ListaCursos.Where(n => n.CodigoCursos == DescripcionVariable).FirstOrDefault();
                if (objCursos == null)
                {
                    objCursos = new Cursos();
                    objCursos.Descripcion = Convert.ToString(txtDescripcion.Text);
                    objCursos.Estado = chbEstado.IsChecked.Value;
                    objCursos.CodigoPreceptor = Convert.ToInt16(cmbPreceptor.SelectedValue);
                    objCursos.CodigoCursos = Convert.ToInt32(txtCurso.Text);

                    ClasesPublicas.ListaCursos.Add(objCursos);
                }
                else
                {
                    objCursos.Estado = chbEstado.IsChecked.Value;
                    objCursos.CodigoPreceptor = Convert.ToInt16(cmbPreceptor.SelectedValue);
                    objCursos.CodigoCursos = Convert.ToInt32(txtCurso.Text);
                }
                dtgCursos.ItemsSource = ClasesPublicas.ListaCursos;
                dtgCursos.Items.Refresh();
                Guardar();
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void Limpiar()
        {
            txtCurso.Text = "";
            txtDescripcion.Text = "";
            cmbPreceptor.SelectedIndex = -1;
        }

        void Guardar()
        {
            try
            {
                if (File.Exists("Cursos.txt"))
                {
                    File.Delete("Cursos.txt");
                }
                string CursosConectando = "";
                foreach (Cursos objetoCursos in ClasesPublicas.ListaCursos)
                {
                    CursosConectando = CursosConectando + "\r\n" + objetoCursos.Descripcion + ";" + objetoCursos.Estado + ";" + objetoCursos.CodigoPreceptor + ";" + objetoCursos.CodigoCursos;
                }
                File.WriteAllText("Cursos.txt", CursosConectando);
                MessageBox.Show("Almacenado de forma correcta!!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DatosDataGrid()
        {
            dtgCursos.ItemsSource = ClasesPublicas.ListaCursos;
            dtgCursos.CanUserAddRows = false;
            lblCanReg.Content = "Cantidad registros: " + ClasesPublicas.ListaCursos.Count;
        }

        private void ButtonQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursos objetoCursos = (Cursos)dtgCursos.SelectedItem;
                if (objetoCursos != null)
                {
                    ClasesPublicas.ListaCursos.Remove(objetoCursos);
                    dtgCursos.ItemsSource = ClasesPublicas.ListaCursos;
                    dtgCursos.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SELECCIONE UN ITEM", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Cursos objCursos = (Cursos)dtgCursos.SelectedItem;
                if (objCursos != null)
                {
                    txtDescripcion.Text = objCursos.Descripcion.ToString();
                    txtCurso.Text = objCursos.CodigoCursos.ToString();
                    cmbPreceptor.Text = objCursos.CodigoPreceptor.ToString();
                    chbEstado.IsChecked = objCursos.Estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bttnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaCursosBuscar = ClasesPublicas.ListaCursos;
                if (chkCodCursos.IsChecked == true)
                {
                    int codDesde = Convert.ToInt32(txtDesde.Text);
                    int codHasta = Convert.ToInt32(txtHasta.Text);
                    ListaCursosBuscar = ListaCursosBuscar.Where(n => n.CodigoCursos >= codDesde && n.CodigoCursos <= codHasta).ToList();
                }
                if (chkDescripcion.IsChecked == true)
                {
                    string codDescripcion = Convert.ToString(txtDescripcion2.Text);
                    ListaCursosBuscar = ListaCursosBuscar.Where(n => n.Descripcion.Contains(txtDescripcion2.Text)).ToList();
                }
                if (chkEstado.IsChecked == true)
                {
                    bool codEstado = Convert.ToBoolean(chkHabilitado.IsChecked);
                    ListaCursosBuscar = ListaCursosBuscar.Where(n => n.Estado == codEstado).ToList();
                }

                dtgBuscador.ItemsSource = ListaCursosBuscar;
                dtgBuscador.Items.Refresh();
                LblCant.Content = "Registros encontrados: " + ListaCursosBuscar.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtDesde.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtHasta_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtHasta.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCurso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDescripcion.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDescripcion_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    cmbPreceptor.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbPreceptor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    cmbPreceptor.IsDropDownOpen = true;
                    e.Handled = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbPreceptor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    chbEstado.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDescripcion2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    chkCodCursos.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void chkCodCursos_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDesde.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtHasta.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtHasta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    chkEstado.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bttnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stream = GetType().Assembly.GetManifestResourceStream("ProyectoAsistencia.Reportes.ListaCursos.rdlc");
                if (stream != null)
                {

                    ReportViewer reporViewer = new ReportViewer();
                    reporViewer.LocalReport.DataSources.Add(new ReportDataSource("DSCursos", ListaCursosBuscar));
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
