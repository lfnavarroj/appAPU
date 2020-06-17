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
    public partial class UserWindow : Window
    {
        ManageUsers gridD;

        public UserWindow(ManageUsers gr)
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
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            clsUsuarios nuevo_usuario = new clsUsuarios
            {
                Id_usuario = id_TB.Text,
                Nombre_usuario = name_TB.Text,
                Apellidos_usuario = surname_TB.Text,
                Telefono_usuario = long.Parse(telephone_TB.Text),
                Correo_usuario = email_TB.Text,
                Contraseña = password_TB.Password
            };

            gridD.UsersDataGrid.Items.Add(nuevo_usuario);
            this.Close();
        }
    }
}
