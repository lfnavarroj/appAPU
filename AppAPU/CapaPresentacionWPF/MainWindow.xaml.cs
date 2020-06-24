using CapaPresentacionWPF.UserControls;
using MaterialDesignThemes.Wpf;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string perfil;
        
        public MainWindow(long id_user)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            clsUsuarios usuario_actual = new clsUsuarios();
            usuario_actual.Id_usuario = id_user;
            usuario_actual.Perfil = usuario_actual.PerfilActual();

            this.perfil = usuario_actual.Perfil;

            current_user.Text = "Current user: " + usuario_actual.Id_usuario.ToString() + ". Role: " + usuario_actual.Perfil;

            List<MenuItem> menu = new List<MenuItem>
            {
                new MenuItem("Manage projects", PackIconKind.BriefcaseEdit),
                new MenuItem("Manage resources", PackIconKind.DatabaseEdit),
                new MenuItem("Manage users", PackIconKind.UserEdit),
                new MenuItem("Settings", PackIconKind.Settings),
                new MenuItem("Help", PackIconKind.Help),
                new MenuItem("Exit", PackIconKind.ExitToApp)
            };

            ListViewMenu.ItemsSource = menu;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private bool maximized = true;
        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (!maximized)
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                this.WindowState = WindowState.Maximized;
                maximized = true;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                maximized = false;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(new ManageProjects());
                    break;

                case 1:
                    if (perfil == "Administrator")
                    {
                        MainGrid.Children.Clear();
                        MainGrid.Children.Add(new ManageResources());
                    }
                    break;

                case 2:
                    if (perfil == "Administrator")
                    {
                        MainGrid.Children.Clear();
                        MainGrid.Children.Add(new ManageUsers());
                    }
                    break;

                case 3:
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(new Settings());
                    break;

                case 4:
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(new Help());
                    break;

                case 5:
                    this.Close();
                    break;

                default:
                    break;
            }                
        }
    }
}
