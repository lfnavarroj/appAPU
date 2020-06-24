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
    /// Lógica de interacción para ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : UserControl
    {
        bool edit;
        DataTable dt = new DataTable();
        int selRow;

        public ManageUsers()
        {
            InitializeComponent();

            clsUsuarios obj = new clsUsuarios();
            dt = obj.CargarUsuarios();

            dt.Columns[0].ColumnName = "USER ID";
            dt.Columns[1].ColumnName = "NAME";
            dt.Columns[2].ColumnName = "SURNAME";
            dt.Columns[3].ColumnName = "TELEPHONE";
            dt.Columns[4].ColumnName = "E-MAIL";
            dt.Columns[5].ColumnName = "PROFILE";
            dt.Columns[6].ColumnName = "PASSWORD";

            UsersDataGrid.ItemsSource = dt.DefaultView;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            edit = false;
            UserWindow userWindow = new UserWindow(edit, selRow);
            userWindow.ShowDialog();

            clsUsuarios obj = new clsUsuarios();
            dt = obj.CargarUsuarios();

            dt.Columns[0].ColumnName = "USER ID";
            dt.Columns[1].ColumnName = "NAME";
            dt.Columns[2].ColumnName = "SURNAME";
            dt.Columns[3].ColumnName = "TELEPHONE";
            dt.Columns[4].ColumnName = "E-MAIL";
            dt.Columns[5].ColumnName = "PROFILE";
            dt.Columns[6].ColumnName = "PASSWORD";

            UsersDataGrid.ItemsSource = dt.DefaultView;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                edit = true;
                selRow = UsersDataGrid.SelectedIndex;
                UserWindow userWindow = new UserWindow(edit, selRow);
                userWindow.ShowDialog();

                clsUsuarios obj = new clsUsuarios();
                dt = obj.CargarUsuarios();

                dt.Columns[0].ColumnName = "USER ID";
                dt.Columns[1].ColumnName = "NAME";
                dt.Columns[2].ColumnName = "SURNAME";
                dt.Columns[3].ColumnName = "TELEPHONE";
                dt.Columns[4].ColumnName = "E-MAIL";
                dt.Columns[5].ColumnName = "PROFILE";
                dt.Columns[6].ColumnName = "PASSWORD";

                UsersDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Do you want to remove this user?","",MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = UsersDataGrid.SelectedIndex;

                    clsUsuarios obj = new clsUsuarios
                    {
                        Id_usuario = dt.Rows[selRow].Field<long>(0)
                    };

                    obj.BorrarUsuario();

                    dt = obj.CargarUsuarios();

                    dt.Columns[0].ColumnName = "USER ID";
                    dt.Columns[1].ColumnName = "NAME";
                    dt.Columns[2].ColumnName = "SURNAME";
                    dt.Columns[3].ColumnName = "TELEPHONE";
                    dt.Columns[4].ColumnName = "E-MAIL";
                    dt.Columns[5].ColumnName = "PROFILE";
                    dt.Columns[6].ColumnName = "PASSWORD";

                    UsersDataGrid.ItemsSource = dt.DefaultView;
                }
            }
        }
    }
}
