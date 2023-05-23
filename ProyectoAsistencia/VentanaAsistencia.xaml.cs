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
    /// Lógica de interacción para VentanaAsistencia.xaml
    /// </summary>
    public partial class VentanaAsistencia : Window
    {
        List<Asistencia> ListaAsistencias = new List<Asistencia>();
        public VentanaAsistencia()
        {
            InitializeComponent();
            ClasesPublicas.LeerArchivoMateria();
            cmbMateria.ItemsSource = ClasesPublicas.ListaMaterias;
            ClasesPublicas.LeerArchivoCursos();
            CmbCurso.ItemsSource = ClasesPublicas.ListaCursos;
            ClasesPublicas.LeerArchivoAlumno();
            dtg.ItemsSource = ClasesPublicas.ListaAlumnos;
            
        }
        private void btnGrd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(File.Exists("Asistencias.txt"))
                {
                    File.Delete("Asistencias.txt");
                }

                string AsistenciasConcatenados = "";
                foreach(Asistencia asistencia in ListaAsistencias)
                {
                    AsistenciasConcatenados = AsistenciasConcatenados + "\r\n" + asistencia.CodigoAsistencia + ";" + asistencia.Fecha + ";" + asistencia.CodigoCursos + ";" + asistencia.CodigoPreceptor + ";" + asistencia.CodigoMateria + ";" + asistencia.AlumnoAsistencia + ";";
                }

                File.WriteAllText("Asistencia.txt", AsistenciasConcatenados);
                MessageBox.Show("Alamcenado de forma correcta!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void dtgAsistencia_SC(object sender, RoutedEventArgs e)
        {
            try
            {
                Asistencia ObjetoAsistencia = (Asistencia)dtg.SelectedItem;

                if(ObjetoAsistencia != null)
                {
                    TxtID.Text = ObjetoAsistencia.CodigoAsistencia.ToString();
                    DpFecha.Text = ObjetoAsistencia.Fecha.ToString();
                    CmbCurso.Text = ObjetoAsistencia.CodigoCursos.ToString();
                    CmbPreceptor.Text = ObjetoAsistencia.CodigoPreceptor.ToString();
                    cmbMateria.Text = ObjetoAsistencia.CodigoMateria.ToString();
                    ChPresente.IsChecked = ObjetoAsistencia.AlumnoAsistencia;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
