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
    /// Lógica de interacción para Ventana_InformeAsistencia.xaml
    /// </summary>
    public partial class Ventana_InformeAsistencia : Window
    {
        List<Asistencia> ListaAsistencias = new List<Asistencia>();
        List<Asistencia> ListaInformeAsistencia;
        public Ventana_InformeAsistencia()
        {
            
            InitializeComponent();
            ClasesPublicas.LeerArchivoAsistencia();
            ClasesPublicas.LeerArchivoMateria();
            cmbMateria.ItemsSource = ClasesPublicas.ListaMaterias;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaInformeAsistencia = ClasesPublicas.ListaAsistencias;
                
                if (chHabilitado.IsChecked == true)
                {
                    DateTime? fechaDesde = dpFechaDesde.SelectedDate;
                    DateTime? fechaHasta = dpFechaHasta.SelectedDate;
                    ListaInformeAsistencia = ListaInformeAsistencia.Where(n => n.Fecha >= fechaDesde && n.Fecha <= fechaHasta).ToList();
                }
                if (chHabilitadoMateria.IsChecked == true)
                {
                    int comboMateria = Convert.ToInt32(cmbMateria.SelectedValue);
                    ListaInformeAsistencia = ListaInformeAsistencia.Where(n => n.CodigoMateria == comboMateria).ToList();
                }
                
                dgResultado.ItemsSource = ListaInformeAsistencia;
                dgResultado.Items.Refresh();
                lblResultado.Content = "Registros encontrados; " + ListaInformeAsistencia.Count;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void dgResultado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Asistencia ObjAsistencia = (Asistencia)dgResultado.SelectedItem;

                if (ObjAsistencia != null)
                {
                    dpFechaDesde.Text = ObjAsistencia.Fecha.ToString();
                    dpFechaHasta.Text = ObjAsistencia.Fecha.ToString();
                    cmbMateria.SelectedValue = ObjAsistencia.CodigoMateria.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dpFechaHasta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    cmbMateria.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dpFechaDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    dpFechaHasta.Focus();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void cmbMateria_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    btnBuscar.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbMateria_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
