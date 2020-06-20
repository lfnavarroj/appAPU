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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaLogicaDeNegocio;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para ManageProjects.xaml
    /// </summary>
    public partial class ManageProjects : UserControl
    {
        public ManageProjects()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clsProyectos proyecto1 = new clsProyectos();

            proyecto1.Id_proyecto = 1;
            proyecto1.Nombre_proyecto = "Proyecto de prueba";
            proyecto1.Descripcion_proyecto = "Este proyecto fue creado para realizar una prueba sobre el datagrid de proyectos.";

            ProjectsDataGrid.Items.Add(proyecto1);
        }
    }
}
