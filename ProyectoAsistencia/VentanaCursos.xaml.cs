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
        List<Cursos> ListaCursosBuscar;
        public VentanaCursos()
        {
            InitializeComponent();

            ClasesPublicas.LeerPreceptor();
            cmbPreceptor.ItemsSource = ClasesPublicas.ListaPreceptor;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String DescripcionVariable = Convert.ToString(txtDescripcion.Text);
                Cursos objCursos = ClasesPublicas.ListaCursos.Where(n => n.Descripcion == DescripcionVariable).FirstOrDefault();
                if (objCursos == null)
                {
                    objCursos = new Cursos();
                    objCursos.Descripcion = Convert.ToString(txtDescripcion.Text);
                    objCursos.Estado = chbEstado.IsChecked.Value;
                    objCursos.CodigoPreceptor = cmbPreceptor.SelectedIndex;
                    objCursos.CodigoCursos = Convert.ToInt32(txtCurso.Text);
                    
                    ClasesPublicas.ListaCursos.Add(objCursos);
                }
                else
                {
                    objCursos.Estado = chbEstado.IsChecked.Value;
                    objCursos.CodigoPreceptor = Convert.ToInt32(cmbPreceptor.Text);
                    objCursos.CodigoCursos = Convert.ToInt32(txtCurso.Text);
                }
                dtgCursos.ItemsSource = ClasesPublicas.ListaCursos;
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
                    ClasesPublicas.ListaCursos.Remove(objetoCursos);
                    dtgCursos.ItemsSource = ClasesPublicas.ListaCursos;
                    dtgCursos.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Cursos objCursos = (Cursos)dtgCursos.SelectedItem;
                if (objCursos != null)
                {
                    txtDescripcion.Text = objCursos.Descripcion.ToString();
                    txtCurso.Text = objCursos.CodigoCursos.ToString();
                    cmbPreceptor.Text = objCursos.CodigoPreceptor.ToString();
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
                foreach (Cursos objetoCursos in ClasesPublicas.ListaCursos)
                {
                    CursosConectando = CursosConectando + "\r\n" + objetoCursos.Descripcion + ";" + objetoCursos.Estado + ";" + objetoCursos.CodigoPreceptor + ";" + objetoCursos.CodigoCursos;
                }
                File.WriteAllText("Cursos.txt", CursosConectando);
                MessageBox.Show("Almacenado de forma correcta!!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListaCursosBuscar = ClasesPublicas.ListaCursos;
                if (chkCodCursos.IsChecked == true)
                {
                    int codDesde = Convert.ToInt32(txtDesde.Text);
                    int codHasta = Convert.ToInt32(txtHasta.Text);
                    ListaCursosBuscar = ListaCursosBuscar.Where(n => n.CodigoCursos >= codDesde && n.CodigoCursos <= codHasta).ToList();
                }
                if (chkDescripcion.IsChecked == true)
                {
                    int codDescripcion = Convert.ToInt32(txtDescripcion2.Text);
                    ListaCursosBuscar = ListaCursosBuscar.Where(n => n.Descripcion.Contains(txtDescripcion2.Text)).ToList();
                }
                if (chkEstado.IsChecked == true)
                {
                    bool codEstado = Convert.ToBoolean(chkEstado);
                    ListaCursosBuscar = ListaCursosBuscar.Where(n => n.Estado == codEstado).ToList();
                }
               
                dtgBuscador.ItemsSource = ListaCursosBuscar;
                dtgBuscador.Items.Refresh();
                LblCant.Content = "Registros encontrados: " + ListaCursosBuscar.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtDesde.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtHasta_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtHasta.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bttnLeer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClasesPublicas.LeerArchivoCursos();
                dtgCursos.ItemsSource = ClasesPublicas.ListaCursos;
                dtgCursos.Items.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtCurso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtCurso.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDescripcion_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDescripcion.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDescripcion2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDescripcion2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDesde_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtDesde.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtHasta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtHasta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }   
}
