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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoAsistencia
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void mnuMant_Click(object sender, RoutedEventArgs e)
        {
            Mantenimiento ventana = new Mantenimiento();
            ventana.Show();

        }

       

        private void mnuAlumnos_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Alumno ventana_Alumno = new Ventana_Alumno();
            ventana_Alumno.Show();
        }

        private void mnuCursos_Click(object sender, RoutedEventArgs e)
        {
            VentanaCursos ventanaCursos = new VentanaCursos();
            ventanaCursos.Show();
            

        }

        private void mnuMaterias_Click(object sender, RoutedEventArgs e)
        {
            Materias Materias = new Materias();
            Materias.Show();

        }

        private void menuAsistencias_Click(object sender, RoutedEventArgs e)
        {
            VentanaAsistencia ventana = new VentanaAsistencia();
            ventana.Show();

        }

        private void mnuPreceptor_Click(object sender, RoutedEventArgs e)
        {
            VentanaPreceptor VentanaPreceptor = new VentanaPreceptor();
            VentanaPreceptor.Show();

        }

       

        private void mnuInforme_Click(object sender, RoutedEventArgs e)
        {
            Ventana_InformeAsistencia ventana = new Ventana_InformeAsistencia();
            ventana.Show();

        }

        private void mnuProfes_Click(object sender, RoutedEventArgs e)
        {
            VentanaProfesores ventanaProfesores = new VentanaProfesores();
            ventanaProfesores.Show();

        }

        private void menuItemProm_Click(object sender, RoutedEventArgs e)
        {
            AsistenciasPromedio ventana = new AsistenciasPromedio();
            ventana.Show();
        }

        private void menuAsis_C_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
