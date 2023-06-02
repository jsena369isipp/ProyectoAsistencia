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
    /// Lógica de interacción para AsistenciasPromedio.xaml
    /// </summary>
    public partial class AsistenciasPromedio : Window
    {
        public AsistenciasPromedio()
        {
            InitializeComponent();
            ClasesPublicas.LeerArchivoAsistencia();

            ComboMateria.ItemsSource = ClasesPublicas.ListaMaterias;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClasesPublicas.LeerArchivoAsistencia();
                ClasesPublicas.LeerArchivoMateria();

                List<Materia> listaBuscarMateria = ClasesPublicas.ListaMaterias;
                List<Asistencia> listaBuscarAsistencia = ClasesPublicas.ListaAsistencias;

                

                if (CheckFechI.IsChecked == true)
                {
                    DateTime fechaIncio = Convert.ToDateTime(DateFechaInicio);
                    DateTime fechaFin = Convert.ToDateTime(DateFechaFinal);
                    listaBuscarAsistencia = listaBuscarAsistencia.Where(n => n.Fecha >= fechaIncio && n.Fecha >= fechaFin).ToList();
                if  (CheckMateria.IsChecked == true)
                    {
                        int codNombreMateria = Convert.ToInt32(ComboMateria.SelectedValue);
                        listaBuscarMateria = listaBuscarMateria.Where(n => n.CodigoMateria == codNombreMateria).ToList();
                    }

                }



                DgResultados.ItemsSource = listaBuscarAsistencia;
                DgResultados.Items.Refresh();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }






        }

     
    }
}