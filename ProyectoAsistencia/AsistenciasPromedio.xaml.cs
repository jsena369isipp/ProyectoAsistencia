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
        List<Materia> listaBuscarMateria = ClasesPublicas.ListaMaterias;
        List<Asistencia> listaBuscarAsistencia = ClasesPublicas.ListaAsistencias;
        
        List<AsistenciaPromedio> listaAsisPromedio = new List<AsistenciaPromedio>();
        List<Alumno> listaBuscarAlumno = new List<Alumno>();
        public AsistenciasPromedio()
        {
            InitializeComponent();
            ClasesPublicas.LeerArchivoAsistencia();
            ClasesPublicas.LeerArchivoMateria();
            ClasesPublicas.LeerArchivoAlumno();
            listaBuscarAsistencia = ClasesPublicas.ListaAsistencias;
            ComboMateria.ItemsSource = ClasesPublicas.ListaMaterias;
            ComboAlumno.ItemsSource = ClasesPublicas.ListaAlumnos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFechI.IsChecked == true)
                {
                    DateTime fechaIncio = Convert.ToDateTime(DateFechaInicio);
                    DateTime fechaFin = Convert.ToDateTime(DateFechaFinal);
                    listaBuscarAsistencia = listaBuscarAsistencia.Where(n => n.Fecha >= fechaIncio && n.Fecha >= fechaFin).ToList();
                }
                if  (CheckMateria.IsChecked == true)
                {
                        int codNombreMateria = Convert.ToInt32(ComboMateria.SelectedValue);
                    listaBuscarAsistencia = listaBuscarAsistencia.Where(n => n.CodigoMateria == codNombreMateria).ToList();
                }
                if (ChAlumno.IsChecked == true)
                {
                    int codAlumno = Convert.ToInt32(ComboAlumno.SelectedValue);
                    listaBuscarAsistencia = listaBuscarAsistencia.Where(n => n.CodigoAlumno == codAlumno).ToList();
                }
                //if (File.Exists("AsistenciaPromedio.txt"))
                //{
                //    File.Delete("AsistenciaPromedio.txt");
                //}
                //string AsistenciasPromedio = "";

                foreach (Asistencia ObjAsistencia in listaBuscarAsistencia)
                {
                    AsistenciaPromedio ObjAlumno = listaAsisPromedio.Where(n => n.CodigoAlumno == ObjAsistencia.CodigoAlumno).FirstOrDefault();
                    if (ObjAlumno == null)
                    {
                        ObjAlumno = new AsistenciaPromedio
                        {
                            FechaInicial = DateFechaInicio.SelectedDate.Value,
                            FechaFinal = DateFechaFinal.SelectedDate.Value,
                            Materia = ObjAsistencia.CodigoMateria.ToString(),
                            NombreAlumno = ObjAsistencia.NombreApellido,
                            DíasClases = 1
                        };
                        if (ObjAsistencia.AlumnoAsistencia == true)
                        {
                            ObjAlumno.DíasAsistencias = 1;
                        }
                        listaAsisPromedio.Add(ObjAlumno);
                    }
                    else
                    {
                        if (ObjAsistencia.AlumnoAsistencia == true)
                        {
                            ObjAlumno.DíasAsistencias += 1;
                        }
                        ObjAlumno.DíasClases += 1;
                    }

                    decimal total = 0.0m;
                    total = ObjAlumno.DíasClases * ObjAlumno.DíasAsistencias / total;
                }
                DgResultados.ItemsSource = listaAsisPromedio;
                DgResultados.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}