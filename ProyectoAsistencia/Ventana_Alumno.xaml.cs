﻿using Microsoft.Reporting.WinForms;
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

    public partial class Ventana_Alumno : Window
    {
        List<Materia> ListaAlumnos = new List<Materia>();
        List<Alumno> ListaAlumnoBuscar;
        public Ventana_Alumno()
        {
            InitializeComponent();
            DateFechaIngreso.SelectedDate = DateTime.Now;
            ClasesPublicas.LeerArchivoCursos();
            ComboCurso.ItemsSource = ClasesPublicas.ListaCursos;
            ClasesPublicas.LeerArchivoAlumno();
        }
        
        private void BtnCargar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int64 VariableDni = Convert.ToInt64(TxtDNI.Text);
                int VariableCodAlumno = Convert.ToInt32(TxtCodAlumno.Text);
                Alumno ObjAlumno = ClasesPublicas.ListaAlumnos.Where(n => n.Dni == VariableDni || n.CodigoAlumno == VariableCodAlumno).FirstOrDefault();
                if (ObjAlumno == null)
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.Dni = VariableDni;
                    ObjAlumno.CodigoCurso = Convert.ToInt32(ComboCurso.SelectedValue);
                    ObjAlumno.CodigoAlumno = VariableCodAlumno;
                    ObjAlumno.NombreApellido = TxtNomApellido.Text;
                    ObjAlumno.Estado = CheckEstado.IsChecked.Value;
                    ObjAlumno.FechaNacimiento = DateFechaNac.SelectedDate.Value;
                    ObjAlumno.Domicilio = TxtDomicilio.Text;
                    ObjAlumno.Tel = Convert.ToInt64(TxtTelefono.Text);
                    ObjAlumno.CorreoElectronico = TxtCorreo.Text;
                    ObjAlumno.FechaIngreso = DateFechaIngreso.SelectedDate.Value;

                    ClasesPublicas.ListaAlumnos.Add(ObjAlumno);
                }
                else 
                {
                    ObjAlumno.CodigoCurso = Convert.ToInt32(ComboCurso.SelectedValue);
                    ObjAlumno.NombreApellido = TxtNomApellido.Text;
                    ObjAlumno.Estado = CheckEstado.IsChecked.Value;
                    ObjAlumno.FechaNacimiento = DateFechaNac.SelectedDate.Value;
                    ObjAlumno.Domicilio = TxtDomicilio.Text;
                    ObjAlumno.Tel = Convert.ToInt64(TxtTelefono.Text);
                    ObjAlumno.CorreoElectronico = TxtCorreo.Text;
                    ObjAlumno.FechaIngreso = DateFechaIngreso.SelectedDate.Value;
                }
                DgAlumno.ItemsSource = ClasesPublicas.ListaAlumnos;
                DgAlumno.Items.Refresh();
                LblCantAlumnos.Content = ClasesPublicas.ListaAlumnos.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno ObjAlumnoEliminar = (Alumno)DgAlumno.SelectedItem;
                if (ObjAlumnoEliminar != null)
                {
                    ClasesPublicas.ListaAlumnos.Remove(ObjAlumnoEliminar);
                    DgAlumno.ItemsSource = ClasesPublicas.ListaAlumnos;
                    DgAlumno.Items.Refresh();
                    LblCantAlumnos.Content = ClasesPublicas.ListaAlumnos.Count + 2 - 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void DgAlumno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Alumno ObjAlumno = (Alumno)DgAlumno.SelectedItem;
                if (ObjAlumno != null)
                {
                    ComboCurso.SelectedIndex = ObjAlumno.CodigoCurso;
                    TxtCodAlumno.Text = ObjAlumno.CodigoAlumno.ToString();
                    TxtDNI.Text = ObjAlumno.Dni.ToString();
                    TxtNomApellido.Text = ObjAlumno.NombreApellido;
                    CheckEstado.IsChecked = ObjAlumno.Estado;
                    DateFechaNac.SelectedDate = ObjAlumno.FechaNacimiento;
                    TxtDomicilio.Text = ObjAlumno.Domicilio;
                    TxtTelefono.Text = ObjAlumno.Tel.ToString();
                    TxtCorreo.Text = ObjAlumno.CorreoElectronico;
                    DateFechaIngreso.SelectedDate = ObjAlumno.FechaIngreso;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BtnCargar_Click(sender, e);
                if (File.Exists("Alumno.txt"))
                {
                    File.Delete("Alumno.txt");
                }
                string AlumnoConcatenado = "";
                foreach (Alumno ObjAlumno in ClasesPublicas.ListaAlumnos)
                {
                    AlumnoConcatenado = AlumnoConcatenado + "\r\n" + ObjAlumno.CodigoCurso + ";" + ObjAlumno.CodigoAlumno + ";" + ObjAlumno.Dni + ";" + ObjAlumno.NombreApellido + ";" + ObjAlumno.FechaNacimiento + ";" + ObjAlumno.Domicilio + ";" + ObjAlumno.Tel + ";" + ObjAlumno.CorreoElectronico + ";" + ObjAlumno.Estado + ";" + ObjAlumno.FechaIngreso + ";";
                }
                File.WriteAllText("Alumno.txt", AlumnoConcatenado);
                MessageBox.Show("Almacenado de forma correcta!!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaAlumnoBuscar = ClasesPublicas.ListaAlumnos;
                if (CheckCodAlumno.IsChecked == true)
                {
                    int codDesde = Convert.ToInt32(TxtDesde.Text);
                    int codHasta = Convert.ToInt32(TxtHasta.Text);
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.CodigoAlumno >= codDesde && n.CodigoAlumno <= codHasta).ToList();
                }
                if (CheckDNI.IsChecked == true)
                {
                    int codDni = Convert.ToInt32(TxtDNI1.Text);
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.Dni == codDni).ToList();
                }
                if (CheckTelefono.IsChecked == true)
                {
                    int codTel = Convert.ToInt32(TxtTelefono.Text);
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.Tel == codTel).ToList();
                }
                if (CheckFechaNacimiento.IsChecked == true)
                {
                    DateTime codFechNac = Convert.ToDateTime(DateFechaNacimiento1.SelectedDate);
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.FechaNacimiento == codFechNac).ToList();
                }
                if (CheckFechaIngreso.IsChecked == true)
                {
                    DateTime codFechIngDesde = Convert.ToDateTime(DateFechaIngresoDesde.SelectedDate);
                    DateTime codFechIngHasta = Convert.ToDateTime(DateFechaIngresoHasta.SelectedDate);
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.FechaIngreso >= codFechIngDesde && n.FechaIngreso <= codFechIngHasta).ToList();
                }
                if (CheckNombreApellido.IsChecked == true)
                {
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.NombreApellido.Contains(TxtNombreApellido1.Text)).ToList();
                }
                if (CheckEstado2.IsChecked == true)
                {
                    bool codEstado = Convert.ToBoolean(CheckEstado1.IsChecked);
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.Estado == codEstado).ToList();
                }
                if (CheckDomicilio.IsChecked == true)
                {
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.Domicilio.Contains(TxtDomicilio1.Text)).ToList();
                }
                if (CheckCorreoElectronico.IsChecked == true)
                {
                    ListaAlumnoBuscar = ListaAlumnoBuscar.Where(n => n.CorreoElectronico.Contains(TxtCorreoElectronico1.Text)).ToList();
                }
                DgBuscador.ItemsSource = ListaAlumnoBuscar;
                DgBuscador.Items.Refresh();
                LblCant.Content = ListaAlumnoBuscar.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtDesde.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtHasta_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtHasta.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLeer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClasesPublicas.LeerArchivoAlumno();
                DgAlumno.ItemsSource = ClasesPublicas.ListaAlumnos;
                DgAlumno.Items.Refresh();
                LblCantAlumnos.Content = ClasesPublicas.ListaAlumnos.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtCodAlumno_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtDNI.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void TxtDNI_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtNomApellido.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtNomApellido_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    CheckEstado.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckEstado_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    DateFechaNac.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DateFechaNac_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtDomicilio.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtDomicilio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtTelefono.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtTelefono_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtCorreo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtCorreo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    DateFechaIngreso.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboCurso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtCodAlumno.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtHasta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtHasta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtDNI1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtDNI1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtTelefono1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtTelefono1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    DateFechaNacimiento1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DateFechaNacimiento1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    DateFechaIngresoDesde.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DateFechaIngresoDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    DateFechaIngresoHasta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DateFechaIngresoHasta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtNombreApellido1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtNombreApellido1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    CheckEstado1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckEstado1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtDomicilio1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtDomicilio1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtCorreoElectronico1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtDNIEntidad_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.Key == Key.Enter)
                {
                    DNIEntidad dniEntidad = new DNIEntidad();
                    dniEntidad.DatosDNI(TxtDNIEntidad.Text);
                    if (dniEntidad != null)
                    {
                        TxtNomApellido.Text = dniEntidad.ApellidoYNombre;
                        DateFechaNac.SelectedDate = dniEntidad.FechaDeNacimiento;
                        TxtDNI.Text = dniEntidad.DNI.ToString();
                    }

                    ComboCurso.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stream = GetType().Assembly.GetManifestResourceStream("ProyectoAsistencia.Reportes.ListaAlumnos3.rdlc");
                if (stream != null)
                {

                    ReportViewer reporViewer = new ReportViewer();
                    reporViewer.LocalReport.DataSources.Add(new ReportDataSource("DSAlumnos", ListaAlumnoBuscar));
                    reporViewer.LocalReport.LoadReportDefinition(stream);

                    reporViewer.Visible = true;
                    reporViewer.RefreshReport();

                    VentanaReportes ventanaReportes = new VentanaReportes(reporViewer);
                    ventanaReportes.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
