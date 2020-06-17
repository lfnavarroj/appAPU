using CapaLogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        ManageUsers gridD;

        public AddUserWindow(ManageUsers gr)
        {
            InitializeComponent();
            this.gridD = gr;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit without saving?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (id_TB.Text != "" && name_TB.Text != "" && surname_TB.Text != "" && telephone_TB.Text != "" && email_TB.Text != "" && password_TB.Password != "")
            {
                if (MessageBox.Show("Do you want to add this user?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    clsUsuarios nuevo_usuario = new clsUsuarios
                    {
                        Id_usuario = id_TB.Text,
                        Nombre_usuario = name_TB.Text,
                        Apellidos_usuario = surname_TB.Text,
                        Telefono_usuario = long.Parse(telephone_TB.Text),
                        Correo_usuario = email_TB.Text,
                        Contraseña = password_TB.Password,
                        Perfil = profile_CB.Text
                    };

                    gridD.UsersDataGrid.Items.Add(nuevo_usuario);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You must complete all the data!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
