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
        List<Materia> ListaMateria;
        public Ventana_InformeAsistencia()
        {
            InitializeComponent();
            ClasesPublicas.LeerArchivoAsistencia();
            cmbMateria.ItemsSource = ClasesPublicas.ListaMaterias;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaInformeAsistencia = ClasesPublicas.ListaAsistencias;
                ListaMateria = ClasesPublicas.ListaMaterias;
                DateTime? fechaDesde = dpFechaDesde.SelectedDate;
                DateTime? fechaHasta = dpFechaHasta.SelectedDate;
                int filtromateria = cmbMateria.SelectedIndex;
                if (chHabilitado.IsChecked == true && fechaDesde.HasValue && fechaHasta.HasValue)
                {
                    //int codDesde = Convert.ToInt32(fechaDesde.Value);
                    //int codHasta = Convert.ToInt32(fechaHasta.Value);
                    ListaInformeAsistencia = ListaInformeAsistencia.Where(n => n.Fecha >= fechaDesde && n.Fecha <= fechaHasta).ToList();
                }
                if (filtromateria >= 0)
                {
                    string filtromateria2 = filtromateria.ToString();
                    ListaMateria = ListaMateria.Where(n => n.NombreMateria == filtromateria2).ToList();
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
    }
}
