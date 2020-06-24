using CapaPresentacionWPF.Add_Edit_Windows;
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
using System.Data;

using CapaLogicaDeNegocio;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para ManageResources.xaml
    /// </summary>
    public partial class ManageResources : UserControl
    {
        bool edit;
        DataTable dt_materiales = new DataTable();
        DataTable dt_prestaciones = new DataTable();
        DataTable dt_equipos = new DataTable();
        DataTable dt_herramientas = new DataTable();
        int selRow;

        public ManageResources()
        {
            InitializeComponent();

            clsMateriales obj_m = new clsMateriales();
            dt_materiales = obj_m.CargarMateriales();

            dt_materiales.Columns[0].ColumnName = "MATERIAL CODE";
            dt_materiales.Columns[1].ColumnName = "DESCRIPTION";
            dt_materiales.Columns[2].ColumnName = "UNIT";
            dt_materiales.Columns[3].ColumnName = "VALUE";

            MaterialsDataGrid.ItemsSource = dt_materiales.DefaultView;


            clsPrestaciones obj_p = new clsPrestaciones();
            dt_prestaciones = obj_p.CargarPrestaciones();

            dt_prestaciones.Columns[0].ColumnName = "SERVICE CODE";
            dt_prestaciones.Columns[1].ColumnName = "DESCRIPTION";
            dt_prestaciones.Columns[2].ColumnName = "UNIT";
            dt_prestaciones.Columns[3].ColumnName = "VALUE";

            ServicesDataGrid.ItemsSource = dt_prestaciones.DefaultView;


            clsEquipos obj_e = new clsEquipos();
            dt_equipos = obj_e.CargarEquipos();

            dt_equipos.Columns[0].ColumnName = "SERIAL NUMBER";
            dt_equipos.Columns[1].ColumnName = "DESCRIPTION";
            dt_equipos.Columns[2].ColumnName = "UNIT";
            dt_equipos.Columns[3].ColumnName = "VALUE";

            EquipmentDataGrid.ItemsSource = dt_equipos.DefaultView;


            clsHerramientas obj_h = new clsHerramientas();
            dt_herramientas = obj_h.CargarHerramientas();

            dt_herramientas.Columns[0].ColumnName = "TOOL CODE";
            dt_herramientas.Columns[1].ColumnName = "DESCRIPTION";
            dt_herramientas.Columns[2].ColumnName = "UNIT";
            dt_herramientas.Columns[3].ColumnName = "VALUE";

            ToolsDataGrid.ItemsSource = dt_herramientas.DefaultView;
        }

        private void ButtonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            MaterialWindow materialWindow = new MaterialWindow(edit, selRow);
            materialWindow.ShowDialog();

            clsMateriales obj = new clsMateriales();
            dt_materiales = obj.CargarMateriales();

            dt_materiales.Columns[0].ColumnName = "MATERIAL CODE";
            dt_materiales.Columns[1].ColumnName = "DESCRIPTION";
            dt_materiales.Columns[2].ColumnName = "UNIT";
            dt_materiales.Columns[3].ColumnName = "VALUE";

            MaterialsDataGrid.ItemsSource = dt_materiales.DefaultView;
        }

        private void ButtonEditMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem != null)
            {
                edit = true;
                selRow = MaterialsDataGrid.SelectedIndex;
                MaterialWindow materialWindow = new MaterialWindow(edit, selRow);
                materialWindow.ShowDialog();

                clsMateriales obj = new clsMateriales();
                dt_materiales = obj.CargarMateriales();

                dt_materiales.Columns[0].ColumnName = "MATERIAL CODE";
                dt_materiales.Columns[1].ColumnName = "DESCRIPTION";
                dt_materiales.Columns[2].ColumnName = "UNIT";
                dt_materiales.Columns[3].ColumnName = "VALUE";

                MaterialsDataGrid.ItemsSource = dt_materiales.DefaultView;
            }
        }

        private void ButtonRemoveMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this material?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = MaterialsDataGrid.SelectedIndex;

                    clsMateriales obj = new clsMateriales
                    {
                        Cod_material = dt_materiales.Rows[selRow].Field<int>(0)
                    };

                    obj.BorrarMaterial();

                    dt_materiales = obj.CargarMateriales();

                    dt_materiales.Columns[0].ColumnName = "MATERIAL CODE";
                    dt_materiales.Columns[1].ColumnName = "DESCRIPTION";
                    dt_materiales.Columns[2].ColumnName = "UNIT";
                    dt_materiales.Columns[3].ColumnName = "VALUE";

                    MaterialsDataGrid.ItemsSource = dt_materiales.DefaultView;
                }
            }
        }

        private void ButtonAddService_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            ServiceWindow serviceWindow = new ServiceWindow(edit, selRow);
            serviceWindow.ShowDialog();

            clsPrestaciones obj_p = new clsPrestaciones();
            dt_prestaciones = obj_p.CargarPrestaciones();

            dt_prestaciones.Columns[0].ColumnName = "SERVICE CODE";
            dt_prestaciones.Columns[1].ColumnName = "DESCRIPTION";
            dt_prestaciones.Columns[2].ColumnName = "UNIT";
            dt_prestaciones.Columns[3].ColumnName = "VALUE";

            ServicesDataGrid.ItemsSource = dt_prestaciones.DefaultView;
        }

        private void ButtonEditService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem != null)
            {
                edit = true;
                selRow = ServicesDataGrid.SelectedIndex;
                ServiceWindow serviceWindow = new ServiceWindow(edit, selRow);
                serviceWindow.ShowDialog();

                clsPrestaciones obj_p = new clsPrestaciones();
                dt_prestaciones = obj_p.CargarPrestaciones();

                dt_prestaciones.Columns[0].ColumnName = "SERVICE CODE";
                dt_prestaciones.Columns[1].ColumnName = "DESCRIPTION";
                dt_prestaciones.Columns[2].ColumnName = "UNIT";
                dt_prestaciones.Columns[3].ColumnName = "VALUE";

                ServicesDataGrid.ItemsSource = dt_prestaciones.DefaultView;
            }
        }

        private void ButtonRemoveService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this service?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = ServicesDataGrid.SelectedIndex;

                    clsPrestaciones obj_p = new clsPrestaciones()
                    {
                        Codigo_prestacion  = dt_prestaciones.Rows[selRow].Field<int>(0)
                    };

                    obj_p.BorrarPrestacion();

                    dt_prestaciones = obj_p.CargarPrestaciones();

                    dt_prestaciones.Columns[0].ColumnName = "SERVICE CODE";
                    dt_prestaciones.Columns[1].ColumnName = "DESCRIPTION";
                    dt_prestaciones.Columns[2].ColumnName = "UNIT";
                    dt_prestaciones.Columns[3].ColumnName = "VALUE";

                    ServicesDataGrid.ItemsSource = dt_prestaciones.DefaultView;
                }
            }
        }


        private void ButtonAddEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            EquipmentWindow equipmentWindow = new EquipmentWindow(edit, selRow);
            equipmentWindow.ShowDialog();

            clsEquipos obj_e = new clsEquipos();
            dt_equipos = obj_e.CargarEquipos();

            dt_equipos.Columns[0].ColumnName = "SERIAL NUMBER";
            dt_equipos.Columns[1].ColumnName = "DESCRIPTION";
            dt_equipos.Columns[2].ColumnName = "UNIT";
            dt_equipos.Columns[3].ColumnName = "VALUE";

            EquipmentDataGrid.ItemsSource = dt_equipos.DefaultView;
        }

        private void ButtonEditEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem != null)
            {
                edit = true;
                selRow = EquipmentDataGrid.SelectedIndex;
                EquipmentWindow equipmentWindow = new EquipmentWindow(edit, selRow);
                equipmentWindow.ShowDialog();

                clsEquipos obj_e = new clsEquipos();
                dt_equipos = obj_e.CargarEquipos();

                dt_equipos.Columns[0].ColumnName = "SERIAL NUMBER";
                dt_equipos.Columns[1].ColumnName = "DESCRIPTION";
                dt_equipos.Columns[2].ColumnName = "UNIT";
                dt_equipos.Columns[3].ColumnName = "VALUE";

                EquipmentDataGrid.ItemsSource = dt_equipos.DefaultView;
            }
        }

        private void ButtonRemoveEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this piece of equipment?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = EquipmentDataGrid.SelectedIndex;

                    clsEquipos obj_e = new clsEquipos()
                    {
                        Numero_de_serie = dt_equipos.Rows[selRow].Field<int>(0)
                    };

                    obj_e.BorrarEquipo();

                    dt_equipos = obj_e.CargarEquipos();

                    dt_equipos.Columns[0].ColumnName = "SERIAL NUMBER";
                    dt_equipos.Columns[1].ColumnName = "DESCRIPTION";
                    dt_equipos.Columns[2].ColumnName = "UNIT";
                    dt_equipos.Columns[3].ColumnName = "VALUE";

                    EquipmentDataGrid.ItemsSource = dt_equipos.DefaultView;
                }
            }
        }

        private void ButtonAddTool_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            ToolWindow toolWindow = new ToolWindow(edit, selRow);
            toolWindow.ShowDialog();

            clsHerramientas obj_h = new clsHerramientas();
            dt_herramientas = obj_h.CargarHerramientas();

            dt_herramientas.Columns[0].ColumnName = "TOOL CODE";
            dt_herramientas.Columns[1].ColumnName = "DESCRIPTION";
            dt_herramientas.Columns[2].ColumnName = "UNIT";
            dt_herramientas.Columns[3].ColumnName = "VALUE";

            ToolsDataGrid.ItemsSource = dt_herramientas.DefaultView;
        }

        private void ButtonEditTool_Click(object sender, RoutedEventArgs e)
        {
            if (ToolsDataGrid.SelectedItem != null)
            {
                edit = true;
                selRow = ToolsDataGrid.SelectedIndex;
                ToolWindow toolWindow = new ToolWindow(edit, selRow);
                toolWindow.ShowDialog();

                clsHerramientas obj_h = new clsHerramientas();
                dt_herramientas = obj_h.CargarHerramientas();

                dt_herramientas.Columns[0].ColumnName = "TOOL CODE";
                dt_herramientas.Columns[1].ColumnName = "DESCRIPTION";
                dt_herramientas.Columns[2].ColumnName = "UNIT";
                dt_herramientas.Columns[3].ColumnName = "VALUE";

                ToolsDataGrid.ItemsSource = dt_herramientas.DefaultView;
            }
        }

        private void ButtonRemoveTool_Click(object sender, RoutedEventArgs e)
        {
            if (ToolsDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this tool?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = ToolsDataGrid.SelectedIndex;

                    clsHerramientas obj_h = new clsHerramientas()
                    {
                        Codigo_herramienta = dt_herramientas.Rows[selRow].Field<int>(0)
                    };

                    obj_h.BorrarHerramienta();

                    dt_herramientas = obj_h.CargarHerramientas();

                    dt_herramientas.Columns[0].ColumnName = "TOOL CODE";
                    dt_herramientas.Columns[1].ColumnName = "DESCRIPTION";
                    dt_herramientas.Columns[2].ColumnName = "UNIT";
                    dt_herramientas.Columns[3].ColumnName = "VALUE";

                    ToolsDataGrid.ItemsSource = dt_herramientas.DefaultView;
                }
            }
        }
    }
}