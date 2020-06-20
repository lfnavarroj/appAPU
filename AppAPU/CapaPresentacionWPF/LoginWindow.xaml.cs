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

            Usuario1 usu = new Usuario1();
            usu.id_usuario = TextBoxUsername.Text;
            usu.contrasena = txtPassword.Password;
            bool rta= usu.iniciarsesion();
            if (rta)
            {
                MessageBox.Show ("Conectado");
            }
            else
            {
                MessageBox.Show ("Error");
            }
             

            //this.Hide();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
            //Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
