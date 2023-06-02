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

        private void btnAlumn_Click(object sender, RoutedEventArgs e)
        {

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

        private void mnuAsistencias_Click(object sender, RoutedEventArgs e)
        {
            VentanaAsistencia VentanaAsistencia = new VentanaAsistencia();
            VentanaAsistencia.Show();

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

      

       
    }
}
