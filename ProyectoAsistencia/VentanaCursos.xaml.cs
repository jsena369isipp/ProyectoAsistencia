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
    /// Lógica de interacción para Cursos.xaml
    /// </summary>
    public partial class VentanaCursos : Window
    {
        public VentanaCursos()
        {
            InitializeComponent();
            ClasesPublicas.leerArchivoCursos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 IDVariable = Convert.ToInt32(txtID.Text);
                Cursos objCursos = ClasesPublicas.listaCursos.Where(n => n.ID == IDVariable).FirstOrDefault();
                if (objCursos == null)
                {
                    objCursos = new Cursos();
                    objCursos.ID = Convert.ToInt32(txtID.Text);
                    objCursos.Estado = chbEstado.IsChecked.Value;
                    objCursos.CodigoPreceptor = cmbPreceptor.Text;
                    objCursos.CodigoCursos = Convert.ToInt32(txtCurso.Text);
                    
                    ClasesPublicas.listaCursos.Add(objCursos);
                }
                else
                {
                    objCursos.Estado = chbEstado.IsChecked.Value;
                    objCursos.CodigoPreceptor = cmbPreceptor.Text;
                    objCursos.CodigoCursos = Convert.ToInt32(txtCurso.Text);
                }
                dtgCursos.ItemsSource = ClasesPublicas.listaCursos;
                dtgCursos.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursos objetoCursos = (Cursos)dtgCursos.SelectedItem;
                if (objetoCursos != null)
                {
                    ClasesPublicas.listaCursos.Remove(objetoCursos);
                    dtgCursos.ItemsSource = ClasesPublicas.listaCursos;
                    dtgCursos.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void dtgCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Cursos objCursos = (Cursos)dtgCursos.SelectedItem;
                if (objCursos != null)
                {
                    txtID.Text = objCursos.ID.ToString();
                    txtCurso.Text = objCursos.CodigoCursos.ToString();
                    cmbPreceptor.Text = objCursos.CodigoPreceptor;
                    chbEstado.IsChecked = objCursos.Estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bttnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("Cursos.txt"))
                {
                    File.Delete("Cursos.txt");
                }
                string CursosConectando = "";
                foreach (Cursos objetoCursos in ClasesPublicas.listaCursos)
                {
                    CursosConectando = CursosConectando + "\r\n" + objetoCursos.ID + ";" + objetoCursos.Estado + ";" + objetoCursos.CodigoPreceptor + ";" + objetoCursos.CodigoCursos;
                }
                File.WriteAllText("Cursos.txt", CursosConectando);
                MessageBox.Show("Almacenado de forma correcta!!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }   
}
