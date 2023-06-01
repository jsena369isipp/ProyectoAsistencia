﻿using ProyectoAsistencia.Clases2023;
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
        public VentanaAsistencia()
        {
            InitializeComponent();

            DpFecha.SelectedDate = DateTime.Now;

            ClasesPublicas.LeerArchivoMateria();
            cmbMateria.ItemsSource = ClasesPublicas.ListaMaterias;
            ClasesPublicas.LeerArchivoCursos();
            CmbCurso.ItemsSource = ClasesPublicas.ListaCursos;
            
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
                foreach(Asistencia ObjetoAsistencia in ListaAsistencias)
                {
                    AsistenciasConcatenados = AsistenciasConcatenados + "\r\n" + ObjetoAsistencia.CodigoAsistencia + ";" + ObjetoAsistencia.Fecha + ";" + ObjetoAsistencia.CodigoCursos + ";" + ObjetoAsistencia.CodigoPreceptor + ";" + ObjetoAsistencia.CodigoMateria + ";" + ObjetoAsistencia.AlumnoAsistencia + ";";
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
        private void BtnLeer_Click(object sender, RoutedEventArgs e)
        {
            Clases2023.ClasesPublicas.LeerArchivoAlumno();

            //cargar lista asistencia
            int codCurso = Convert.ToInt32(CmbCurso.SelectedValue);
            foreach(Alumno alumno in ClasesPublicas.ListaAlumnos.Where(n=>n.CodigoCurso ==codCurso))
            {
                Asistencia asistencia = new Asistencia();
                asistencia.CodigoAsistencia = Convert.ToInt32(TxtID.Text);
                asistencia.CodigoAlumno = alumno.CodigoAlumno;
                asistencia.AlumnoAsistencia = false;
                ListaAsistencias.Add(asistencia);
            }
            dtg.ItemsSource = ListaAsistencias; //Clases2023.ClasesPublicas.ListaAlumnos;
            dtg.Items.Refresh();
            LblArchivos.Content = dtg.Items.Count;
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaAsistenciaBuscar = ClasesPublicas.ListaAsistencias;

                if(chCodAlumnoX.IsChecked == true)
                {
                    //int codDesde = Convert.ToInt32(txtCodDesdeX.Text);
                    //int codHasta = Convert.ToInt32(txtCodHastaX.Text);
                    //ListaAsistenciaBuscar = ListaAsistenciaBuscar.Where(n => n.CodigoAsistencia >= codDesde && n.CodigoAsistencia <= codHasta).ToList();
                }
                if(chNombreAlumnoX.IsChecked == true)
                {
                    //ListaAsistenciaBuscar = ListaAsistenciaBuscar.Where(n => n..Contains(txtNombMat.Text)).ToList();
                }
                dgResultadoX.ItemsSource = ListaAsistenciaBuscar;
                dgResultadoX.Items.Refresh();
                lblResultadoX.Content = "Registros encontrados: " + ListaAsistenciaBuscar.Count;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message,"Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCodDesdeX.Text = "";
        }
        private void txtHasta_GotFocus(Object sender, RoutedEventArgs e)
        {
            txtCodHastaX.Text = "";
        }

        private void cmbMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Materia materia = (Materia)cmbMateria.SelectedValue;
            if(materia!=null)
            {
                CmbCurso.SelectedValue = materia.CodigoCursos;
            }
            
        }
    }
}
