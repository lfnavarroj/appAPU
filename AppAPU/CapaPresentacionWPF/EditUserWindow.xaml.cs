using CapaLogicaDeNegocio;
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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para RemoveUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        ManageUsers gridD;
        clsUsuarios edit_usuario;
        int index;

        public EditUserWindow(ManageUsers gr)
        {
            InitializeComponent();
            this.gridD = gr;

            this.edit_usuario = gridD.UsersDataGrid.SelectedItem as clsUsuarios;

            id_TB.Text = edit_usuario.Id_usuario;
            name_TB.Text = edit_usuario.Nombre_usuario;
            surname_TB.Text = edit_usuario.Apellidos_usuario;
            telephone_TB.Text = edit_usuario.Telefono_usuario.ToString();
            email_TB.Text = edit_usuario.Correo_usuario;
            password_TB.Password = edit_usuario.Contraseña;

            this.index = gridD.UsersDataGrid.SelectedIndex;
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
            if (telephone_TB.Text != "" && email_TB.Text != "" && password_TB.Password != "")
            {
                if (telephone_TB.Text == edit_usuario.Telefono_usuario.ToString() && email_TB.Text == edit_usuario.Correo_usuario && password_TB.Password == edit_usuario.Contraseña)
                {
                    MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        edit_usuario.Telefono_usuario = long.Parse(telephone_TB.Text);
                        edit_usuario.Correo_usuario = email_TB.Text;
                        edit_usuario.Contraseña = password_TB.Password;

                        gridD.UsersDataGrid.Items.RemoveAt(index);
                        gridD.UsersDataGrid.Items.Insert(index, edit_usuario);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("You must complete all the data!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}