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
    /// Lógica de interacción para Materias.xaml
    /// </summary>
    public partial class Materias : Window
    {
        List<Materia> ListaMaterias = new List<Materia>();
        List<Materia> listaMateriasBuscar;
        public Materias()
        {
            InitializeComponent();
            txtBoxID.Focus();
            ClasesPublicas.LeerArchivoMateria();
            ClasesPublicas.LeerArchivoProfesores();
            cboBoxProfesor.ItemsSource = ClasesPublicas.ListaProfesores;
            ClasesPublicas.LeerArchivoCursos();
            cboBoxCurso.ItemsSource = ClasesPublicas.ListaCursos;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 IDVariable = Convert.ToInt32(txtBoxID.Text);
                Materia ObjetoMateria = ListaMaterias.Where(n => n.CodigoMateria == IDVariable).FirstOrDefault();
                if (ObjetoMateria == null)
                {
                    ObjetoMateria = new Materia();
                    ObjetoMateria.CodigoMateria = Convert.ToInt32(txtBoxID.Text);
                    ObjetoMateria.NombreMateria = txtBoxMateria.Text;
                    ObjetoMateria.IDProfesor = Convert.ToInt32(cboBoxProfesor.SelectedValue);
                    ObjetoMateria.CodigoCursos = Convert.ToInt32(cboBoxCurso.SelectedValue);
                    ObjetoMateria.HsCatedra = Convert.ToInt32(txtBoxHs.Text);

                    ListaMaterias.Add(ObjetoMateria);
                }
                else
                {
                    ObjetoMateria.CodigoMateria = Convert.ToInt32(txtBoxID.Text);
                    ObjetoMateria.NombreMateria = txtBoxMateria.Text;
                    ObjetoMateria.IDProfesor = Convert.ToInt32(cboBoxProfesor.SelectedValue);
                    ObjetoMateria.CodigoCursos = Convert.ToInt32(cboBoxCurso.SelectedValue);
                    ObjetoMateria.HsCatedra = Convert.ToInt32(txtBoxHs.Text);
                }
                dtgMaterias.ItemsSource = ListaMaterias;
                dtgMaterias.Items.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("Materias.txt"))
                {
                    File.Delete("Materias.txt");
                }
                string MateriaConcatenado = "";
                foreach (Materia ObjetoMateria in ListaMaterias)
                {
                    MateriaConcatenado = MateriaConcatenado + "\n" + ObjetoMateria.CodigoMateria + ";" + ObjetoMateria.NombreMateria + ";" +
                    ObjetoMateria.IDProfesor + ";" + ObjetoMateria.CodigoCursos + ";" + ObjetoMateria.HsCatedra;
                }
                File.WriteAllText("Materias.txt", MateriaConcatenado);
                MessageBox.Show("Almacenado exitosamente!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al guardar: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Materia ObjetoMateria = (Materia)dtgMaterias.SelectedItem;
                if (ObjetoMateria != null)
                {
                    ListaMaterias.Remove(ObjetoMateria);
                    dtgMaterias.ItemsSource = ListaMaterias;
                    dtgMaterias.Items.Refresh();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Materia ObjetoMateria = (Materia)dtgMaterias.SelectedItem;
                if (ObjetoMateria != null)
                {
                    txtBoxID.Text = ObjetoMateria.CodigoMateria.ToString();
                    txtBoxMateria.Text = ObjetoMateria.NombreMateria;
                    cboBoxProfesor.SelectedIndex = ObjetoMateria.IDProfesor;
                    cboBoxCurso.SelectedIndex = ObjetoMateria.CodigoCursos;
                    txtBoxHs.Text = ObjetoMateria.HsCatedra.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listaMateriasBuscar = ClasesPublicas.ListaMaterias;
                if (chkCodMat.IsChecked == true)
                {
                    int codDesde = Convert.ToInt32(txtDesde.Text);
                    int codHasta = Convert.ToInt32(txtHasta.Text);
                    listaMateriasBuscar = listaMateriasBuscar.Where(n => n.CodigoMateria >= codDesde && n.CodigoMateria <= codHasta).ToList();
                }
                if (chkNombMat.IsChecked == true)
                {
                    listaMateriasBuscar = listaMateriasBuscar.Where(n => n.NombreMateria.Contains(txtNombMat.Text)).ToList();
                }
                if (chkCodProfe.IsChecked == true)
                {
                    int codProfe = Convert.ToInt32(txtCodProfe.Text);
                    listaMateriasBuscar = listaMateriasBuscar.Where(n => n.IDProfesor == codProfe).ToList();
                }
                if (chkCodCurso.IsChecked == true)
                {
                    int codCurso = Convert.ToInt32(txtCodCurso.Text);
                    listaMateriasBuscar = listaMateriasBuscar.Where(n => n.CodigoCursos == codCurso).ToList();
                }
                dtgBuscMat.ItemsSource = listaMateriasBuscar;
                dtgBuscMat.Items.Refresh();
                lblReg.Content = "Registros encontrados: " + listaMateriasBuscar.Count;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void dtgBuscMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Materia ObjetoMateria = (Materia)dtgBuscMat.SelectedItem;
                if (ObjetoMateria != null)
                {
                    txtBoxID.Text = ObjetoMateria.CodigoMateria.ToString();
                    txtBoxMateria.Text = ObjetoMateria.NombreMateria;
                    cboBoxProfesor.SelectedIndex = ObjetoMateria.IDProfesor;
                    cboBoxCurso.SelectedIndex = ObjetoMateria.CodigoCursos;
                    txtBoxHs.Text = ObjetoMateria.HsCatedra.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtBoxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtBoxMateria.Focus();
            }
        }

        private void txtBoxMateria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cboBoxProfesor.Focus();
            }
        }

        private void cboBoxProfesor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cboBoxProfesor.IsDropDownOpen = true;
                e.Handled = true;
            }
        }

        private void cboBoxProfesor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                cboBoxCurso.Focus();
            }
        }

        private void cboBoxCurso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cboBoxCurso.IsDropDownOpen = true;
                e.Handled = true;
            }
        }

        private void cboBoxCurso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                txtBoxHs.Focus();
            }
        }

        private void txtBoxHs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnAgregar.Focus();
            }
        }
    }
}
