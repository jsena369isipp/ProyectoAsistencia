using System;
using System.Collections.Generic;
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
        List<Clases2023.Materia> ListaMaterias = new List<Clases2023.Materia>();
        public Materias()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 IDVariable = Convert.ToInt32(txtBoxID.Text);
                Clases2023.Materia ObjetoMateria = ListaMaterias.Where(n => n.IdMateria == IDVariable).FirstOrDefault();
                if (ObjetoMateria == null)
                {
                    ObjetoMateria = new Clases2023.Materia();
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
    }
}
