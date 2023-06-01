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
        List<Asistencia> ListaInformeAsistencia;
        public Ventana_InformeAsistencia()
        {
            InitializeComponent();
            ClasesPublicas.LeerArchivoAsistencia();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaInformeAsistencia = ClasesPublicas.ListaAsistencias;
                DateTime? fechaDesde = dpFechaDesde.SelectedDate;
                DateTime? fechaHasta = dpFechaHasta.SelectedDate;
                if (chHabilitado.IsChecked == true && fechaDesde.HasValue && fechaHasta.HasValue)
                {
                    int codDesde = Convert.ToInt32(fechaDesde.Value);
                    int codHasta = Convert.ToInt32(fechaHasta.Value);
                    ListaInformeAsistencia = ListaInformeAsistencia.Where(n => n.CodigoAsistencia >= codDesde && n.CodigoAsistencia <= codHasta).ToList();

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
            try
            {
                Asistencia objetoListaAsistencia = (Asistencia)dgResultado.SelectedItem;
                if (objetoListaAsistencia != null)
                {
                    ListaInformeAsistencia.Remove(objetoListaAsistencia);
                    dgResultado.ItemsSource = ListaInformeAsistencia;
                    dgResultado.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
}
