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

            var menuProjects = new List<MenuSubitem>
            {
                new MenuSubitem("Create project"),
                new MenuSubitem("Find project"),
                new MenuSubitem("List projects")
            };

            var item1 = new MenuItem("Manage projects", menuProjects, PackIconKind.Register);

            var menuResources = new List<MenuSubitem>
            {
                new MenuSubitem("Create resource"),
                new MenuSubitem("Find resource"),
                new MenuSubitem("List resources")
            };

            var item2 = new MenuItem("Register", menuProjects, PackIconKind.Register);

            var menuUsers = new List<MenuSubitem>
            {
                new MenuSubitem("Create user"),
                new MenuSubitem("Find user"),
                new MenuSubitem("List users")
            };

            var item3 = new MenuItem("Register", menuProjects, PackIconKind.Register);

            var item0 = new MenuItem("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0));
            Menu.Children.Add(new UserControlMenuItem(item1));
            Menu.Children.Add(new UserControlMenuItem(item2));
            Menu.Children.Add(new UserControlMenuItem(item3));



            /*
            List<MenuItem> menu = new List<MenuItem>
            {
                new MenuItem("Manage projects", PackIconKind.BriefcaseEdit),

                new MenuItem("Create project", PackIconKind.CreateNewFolder),
                new MenuItem("Find project", PackIconKind.FolderSearch),
                new MenuItem("List projects", PackIconKind.FolderMultiple),

                new MenuItem("Manage resources", PackIconKind.DatabaseEdit),

                new MenuItem("Create resource", PackIconKind.DatabaseAdd),
                new MenuItem("Find resource", PackIconKind.DatabaseSearch),
                new MenuItem("List resources", PackIconKind.ViewList),

                new MenuItem("Manage users", PackIconKind.UserEdit),

                new MenuItem("Create user", PackIconKind.UserAdd),
                new MenuItem("Find user", PackIconKind.UserSearch),
                new MenuItem("List users", PackIconKind.UserMultiple),

                new MenuItem("Settings", PackIconKind.Settings),
                new MenuItem("Help", PackIconKind.Help),
                new MenuItem("Exit", PackIconKind.ExitToApp)
            };

            ListViewMenu.ItemsSource = menu;*/
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
    }
}
