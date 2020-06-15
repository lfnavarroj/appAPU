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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
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
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(new ManageResources());
                    break;

                case 2:
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(new ManageUsers());
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
                    Close();
                    break;

                default:
                    break;
            }                
        }
    }
}
