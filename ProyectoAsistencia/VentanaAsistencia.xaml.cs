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
        List<Asistencia> ListaAsistenciaBuscar;
        // List<Alumno> ListaALumnos;
        public VentanaAsistencia()
        {
            InitializeComponent();

            DpFecha.SelectedDate = DateTime.Now;

            ClasesPublicas.LeerArchivoMateria();
            cmbMateria.ItemsSource = ClasesPublicas.ListaMaterias;
            ClasesPublicas.LeerArchivoCursos();
            CmbCurso.ItemsSource = ClasesPublicas.ListaCursos;
            ClasesPublicas.LeerPreceptor();
            CmbPreceptor.ItemsSource = ClasesPublicas.ListaPreceptor;
            ClasesPublicas.LeerArchivoAsistencia();
            CmbMateriaX.ItemsSource = ClasesPublicas.ListaMaterias;

        }
        private void btnGrd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                
                if (File.Exists("Asistencias.txt"))
                {
                    File.Delete("Asistencias.txt");
                }

                string AsistenciasConcatenados = "";
                foreach (Asistencia ObjetoAsistencia in ListaAsistencias)
                {
                    int presente = 0;
                    if (ObjetoAsistencia.AlumnoAsistencia == true)
                    {
                        presente = 1;
                    }
                   
                    AsistenciasConcatenados = AsistenciasConcatenados + "\r\n" + ObjetoAsistencia.CodigoAlumno + ";" + ObjetoAsistencia.CodigoAsistencia + ";" + ObjetoAsistencia.Fecha + ";" + ObjetoAsistencia.CodigoCursos + ";" + ObjetoAsistencia.CodigoPreceptor + ";" + ObjetoAsistencia.CodigoMateria + ";" + presente + ";" + ObjetoAsistencia.NombreApellido; 
                }

                File.WriteAllText("Asistencias.txt", AsistenciasConcatenados);
                MessageBox.Show("Alamcenado de forma correcta!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void dtgAsistencia_SC(object sender, RoutedEventArgs e)
        {
            try
            {
                Asistencia ObjetoAsistencia = (Asistencia)dtg.SelectedItem;

                if (ObjetoAsistencia != null)
                {

                    TxtID.Text = ObjetoAsistencia.CodigoAsistencia.ToString();
                    DpFecha.Text = ObjetoAsistencia.Fecha.ToString();
                    CmbCurso.SelectedValue = ObjetoAsistencia.CodigoCursos.ToString();
                    CmbPreceptor.SelectedValue = ObjetoAsistencia.CodigoPreceptor.ToString();
                    cmbMateria.SelectedValue = ObjetoAsistencia.CodigoMateria.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnAlumnosCarga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtID.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el ID","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    TxtID.Focus();
                }
                else
                {
                    ListaAsistencias = new List<Asistencia>();

                    ClasesPublicas.LeerArchivoAlumno();
                    dtg.ItemsSource = ClasesPublicas.ListaAlumnos;
                    int codCurso = Convert.ToInt32(CmbCurso.SelectedValue);
                    foreach (Alumno alumno in ClasesPublicas.ListaAlumnos.Where(n => n.CodigoCurso == codCurso))
                    {
                        Asistencia asistencia = new Asistencia();
                        asistencia.CodigoAlumno = alumno.CodigoAlumno;
                        asistencia.CodigoAsistencia = Convert.ToInt32(TxtID.Text);
                        asistencia.Fecha = DateTime.Now;
                        asistencia.CodigoCursos = Convert.ToInt32(CmbCurso.SelectedValue);
                        asistencia.CodigoPreceptor = Convert.ToInt32(cmbMateria.SelectedValue);
                        asistencia.CodigoMateria = Convert.ToInt32(cmbMateria.SelectedValue);
                        asistencia.AlumnoAsistencia = false;
                        asistencia.NombreApellido = alumno.NombreApellido;


                        ListaAsistencias.Add(asistencia);
                    }

                
                }
                dtg.ItemsSource = ListaAsistencias.OrderBy(n => n.NombreApellido).ToList(); ;
                dtg.Items.Refresh();
                LblArchivos.Content = dtg.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ListaAsistenciaBuscar = ClasesPublicas.ListaAsistencias;

                if (ChIDRegistro.IsChecked == true)
                {
                    int IdRegsitro = Convert.ToInt32(txtCodDesdeX.Text);

                    ListaAsistenciaBuscar = ListaAsistenciaBuscar.Where(n => n.CodigoAsistencia == IdRegsitro).ToList();
                }
                if(ChMateriaX.IsChecked == true)
                {
                    int codmateriaX = Convert.ToInt32(CmbMateriaX.SelectedValue);
                    ListaAsistenciaBuscar = ListaAsistenciaBuscar.Where(n => n.CodigoMateria == codmateriaX).ToList();
                }
                
                dgResultadoX.ItemsSource = ListaAsistenciaBuscar.OrderBy(n=>n.NombreApellido).ToList();
                dgResultadoX.Items.Refresh();
                lblResultadoX.Content = "Registros encontrados: " + ListaAsistenciaBuscar.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCodDesdeX.Text = "";
        }
        /*private void txtHasta_GotFocus(Object sender, RoutedEventArgs e)
        {
            txtCodHastaX.Text = "";
        }*/

        private void cmbMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Materia materia = (Materia)cmbMateria.SelectedItem;
            if (materia != null)
            {
                CmbCurso.SelectedValue = materia.CodigoCursos;
            }
        }

        private void ChPresente_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

