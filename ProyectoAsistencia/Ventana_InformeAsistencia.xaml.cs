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
                DateTime? fechaDesde = dpFechaDesde.SelectedDate;
                DateTime? fechaHasta = dpFechaHasta.SelectedDate;
                int filtromateria = Convert.ToInt32(cmbMateria.SelectedValue);
                
                if (chHabilitado.IsChecked == true && fechaDesde.HasValue && fechaHasta.HasValue)
                {
                    ListaInformeAsistencia = ListaInformeAsistencia.Where(n => n.Fecha >= fechaDesde && n.Fecha <= fechaHasta).ToList();
                }
                if (chHabilitadoMateria.IsChecked == true && filtromateria >= 0)
                {
                    ListaInformeAsistencia = ListaInformeAsistencia.Where(n => n.CodigoMateria == filtromateria).ToList();
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}
