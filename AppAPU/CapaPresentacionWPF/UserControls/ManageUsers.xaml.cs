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
    public partial class ManageUsers : UserControl
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow userWindow = new AddUserWindow(this);
            userWindow.ShowDialog();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                EditUserWindow userWindow = new EditUserWindow(this);
                userWindow.ShowDialog();
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this user?","",MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                    UsersDataGrid.Items.Remove(UsersDataGrid.SelectedItem);
            }
        }
    }
}
