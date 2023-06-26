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
    /// Lógica de interacción para VentanaReportes.xaml
    /// </summary>
    public partial class VentanaReportes : Window
    {
        public VentanaReportes(Microsoft.Reporting.WinForms.ReportViewer reportViewer)
        {
            InitializeComponent();
            myWindowsFormsHost.Child = reportViewer;
        }
    }
}
