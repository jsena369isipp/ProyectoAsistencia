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
        public Materias()
        {
            InitializeComponent();
            ClasesPublicas.LeerArchivoMateria();
            dtgMaterias.ItemsSource = ClasesPublicas.ListaMaterias;
            ClasesPublicas.LeerArchivoCursos();
            cboBoxCurso.ItemsSource = ClasesPublicas.ListaCursos;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 IDVariable = Convert.ToInt32(txtBoxID.Text);
                Materia ObjetoMateria = ListaMaterias.Where(n => n.IdMateria == IDVariable).FirstOrDefault();
                if (ObjetoMateria == null)
                {
                    ObjetoMateria = new Materia();
                    ObjetoMateria.IdMateria = Convert.ToInt32(txtBoxID.Text);
                    ObjetoMateria.NombreMateria = txtBoxMateria.Text;
                    ObjetoMateria.IdProfesor = cboBoxProfesor.SelectedIndex;
                    ObjetoMateria.IdCurso = cboBoxCurso.SelectedIndex;
                    ObjetoMateria.HsCatedra = Convert.ToInt32(txtBoxHs.Text);

                    ListaMaterias.Add(ObjetoMateria);
                }
                else
                {
                    ObjetoMateria.IdMateria = Convert.ToInt32(txtBoxID.Text);
                    ObjetoMateria.NombreMateria = txtBoxMateria.Text;
                    ObjetoMateria.IdProfesor = cboBoxProfesor.SelectedIndex;
                    ObjetoMateria.IdCurso = cboBoxCurso.SelectedIndex;
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
                    MateriaConcatenado = MateriaConcatenado + "\n" + ObjetoMateria.IdMateria + ";" + ObjetoMateria.NombreMateria + ";" +
                        ObjetoMateria.IdProfesor + ";" + ObjetoMateria.IdCurso + ";" + ObjetoMateria.HsCatedra;
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
                    txtBoxID.Text = ObjetoMateria.IdMateria.ToString();
                    txtBoxMateria.Text = ObjetoMateria.NombreMateria;
                    cboBoxProfesor.SelectedIndex = ObjetoMateria.IdProfesor;
                    cboBoxCurso.SelectedIndex = ObjetoMateria.IdCurso;
                    txtBoxHs.Text = ObjetoMateria.HsCatedra.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
