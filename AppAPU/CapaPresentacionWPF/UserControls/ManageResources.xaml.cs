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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para ManageResources.xaml
    /// </summary>
    public partial class ManageResources : UserControl
    {
        bool edit;

        public ManageResources()
        {
            InitializeComponent();
        }

        private void ButtonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            MaterialWindow materialWindow = new MaterialWindow(this, edit);
            materialWindow.ShowDialog();
        }

        private void ButtonEditMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem != null)
            {
                edit = true;
                MaterialWindow materialWindow = new MaterialWindow(this, edit);
                materialWindow.ShowDialog();
            }
        }

        private void ButtonRemoveMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this material?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                    MaterialsDataGrid.Items.Remove(MaterialsDataGrid.SelectedItem);
            }
        }

        private void ButtonAddService_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            ServiceWindow serviceWindow = new ServiceWindow(this, edit);
            serviceWindow.ShowDialog();
        }

        private void ButtonEditService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem != null)
            {
                edit = true;
                ServiceWindow serviceWindow = new ServiceWindow(this, edit);
                serviceWindow.ShowDialog();
            }
        }

        private void ButtonRemoveService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this service?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                    ServicesDataGrid.Items.Remove(ServicesDataGrid.SelectedItem);
            }
        }

        private void ButtonAddEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            EquipmentWindow equipmentWindow = new EquipmentWindow(this, edit);
            equipmentWindow.ShowDialog();
        }

        private void ButtonEditEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem != null)
            {
                edit = true;
                EquipmentWindow equipmentWindow = new EquipmentWindow(this, edit);
                equipmentWindow.ShowDialog();
            }
        }

        private void ButtonRemoveEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this piece of equipment?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                    EquipmentDataGrid.Items.Remove(EquipmentDataGrid.SelectedItem);
            }
        }

        private void ButtonAddTool_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            ToolWindow toolWindow = new ToolWindow(this, edit);
            toolWindow.ShowDialog();
        }

        private void ButtonEditTool_Click(object sender, RoutedEventArgs e)
        {
            if (ToolsDataGrid.SelectedItem != null)
            {
                edit = true;
                ToolWindow toolWindow = new ToolWindow(this, edit);
                toolWindow.ShowDialog();
            }
        }

        private void ButtonRemoveTool_Click(object sender, RoutedEventArgs e)
        {
            if (ToolsDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this tool?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                    ToolsDataGrid.Items.Remove(ToolsDataGrid.SelectedItem);
            }
        }
    }
}