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
    /// Lógica de interacción para ManageUsers.xaml
    /// </summary>
    public partial class ManageMaterials : UserControl
    {
        bool edit;

        public ManageMaterials()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            edit = false;
            UserWindow userWindow = new UserWindow(this, edit);
            userWindow.ShowDialog();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem != null)
            {
                edit = true;
                UserWindow userWindow = new UserWindow(this, edit);
                userWindow.ShowDialog();
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this user?","",MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                    MaterialsDataGrid.Items.Remove(MaterialsDataGrid.SelectedItem);
            }
        }
    }
}
