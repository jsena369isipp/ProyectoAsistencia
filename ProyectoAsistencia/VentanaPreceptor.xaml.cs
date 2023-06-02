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
    /// Lógica de interacción para VentanaPreceptor.xaml
    /// </summary>
    public partial class VentanaPreceptor : Window
    {
        List<Clases2023.Preceptor> ListaPreceptor = new List<Clases2023.Preceptor>();
        

        public VentanaPreceptor()
        {

            InitializeComponent();
            ClasesPublicas.LeerPreceptor();
            ClasesPublicas.LeerArchivoCursos();
            cbCursos.ItemsSource = ClasesPublicas.ListaCursos;
            

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("Preceptor.txt"))
                {
                    File.Delete("Preceptor.txt");
                }
                string preceptorConcatenado = "";
                foreach (Preceptor objetoPreceptor in ListaPreceptor)
                {
                    preceptorConcatenado = preceptorConcatenado + "\r\n" + objetoPreceptor.CodigoPreceptor + ";" + objetoPreceptor.ApellidoNombre + ";" + objetoPreceptor.CodigoCursos + ";" + objetoPreceptor.DNI + ";" + objetoPreceptor.FechaNacimiento + ";" + objetoPreceptor.Estado;
                }
                File.WriteAllText("Preceptor.txt", preceptorConcatenado);
                MessageBox.Show("Almacenado de forma correcta!", "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al guardar", "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Preceptor preceptor = (Preceptor)dg1.SelectedItem;
                if (preceptor != null)
                {
                    ListaPreceptor.Remove(preceptor);
                    dg1.ItemsSource = ListaPreceptor;
                    dg1.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Seleccionar item!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            Int64 dniVariable = Convert.ToInt64(txtdni.Text);
            Clases2023.Preceptor preceptor = ListaPreceptor.Where(n => n.DNI == dniVariable).FirstOrDefault();

            try
            {
                if (preceptor == null)
                {

                    preceptor = new Clases2023.Preceptor();
                    preceptor.CodigoPreceptor = Convert.ToInt32(txtCodPreceptor.Text);
                    preceptor.DNI = Convert.ToInt64(txtdni.Text);
                    preceptor.ApellidoNombre = txtNombApellido.Text;
                    preceptor.CodigoCursos = Convert.ToInt16 (cbCursos.SelectedValue);
                    preceptor.Estado = Convert.ToBoolean(chbEstado.IsChecked);//<--para mostrar el estado en el DataGrid
                    preceptor.FechaNacimiento = Convert.ToDateTime(dpFechaNac.SelectedDate);

                    ListaPreceptor.Add(preceptor);

                }
                else
                {
                    preceptor.CodigoPreceptor = Convert.ToInt32(txtCodPreceptor.Text);
                    preceptor.DNI = Convert.ToInt64(txtdni.Text);
                    preceptor.ApellidoNombre = txtNombApellido.Text;
                    preceptor.CodigoCursos = Convert.ToInt16(cbCursos.SelectedValue);
                    preceptor.Estado = Convert.ToBoolean(chbEstado.IsChecked);//<--para mostrar el estado en el DataGrid
                    preceptor.FechaNacimiento = Convert.ToDateTime(dpFechaNac.SelectedDate);
                }
                dg1.ItemsSource = ListaPreceptor;
                dg1.Items.Refresh();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btnLeer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Preceptor preceptor = (Preceptor)dg1.SelectedItem;
                if (preceptor != null)
                {
                    txtCodPreceptor.Text = preceptor.CodigoPreceptor.ToString();
                    txtdni.Text = preceptor.DNI.ToString();
                    txtNombApellido.Text = preceptor.ApellidoNombre;
                    dpFechaNac.SelectedDate = preceptor.FechaNacimiento;
                    chbEstado.IsChecked = preceptor.Estado;
                    cbCursos.SelectedIndex = preceptor.CodigoCursos;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
