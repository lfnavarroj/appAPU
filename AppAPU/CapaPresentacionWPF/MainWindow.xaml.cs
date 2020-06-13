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
                new MenuItem("Create project", PackIconKind.CreateNewFolder),
                new MenuItem("Find project", PackIconKind.FileFind),
                new MenuItem("List projects", PackIconKind.ViewList),
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
    }
}
