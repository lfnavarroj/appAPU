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
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isNumeric = long.TryParse(TextBoxUsername.Text, out long n);

            if (isNumeric)
            {
                clsUsuarios obj = new clsUsuarios
                {
                    Id_usuario = n,
                    Contraseña = txtPassword.Password,
                };

                bool inicio = obj.IniciarSesion();

                if (inicio)
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow(obj.Id_usuario);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("The username must be numeric", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
