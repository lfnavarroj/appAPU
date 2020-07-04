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
using System.Data;

namespace CapaPresentacionWPF.Add_Edit_Windows
{
    /// <summary>
    /// Lógica de interacción para ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        clsProyectos edit_proyecto = new clsProyectos();
        bool edit;
        int selRow;
        DataTable dt = new DataTable();

        public ProjectWindow(bool ed, int selr)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;

            if (edit)
            {
                clsProyectos obj = new clsProyectos();
                dt = obj.CargarProyectos();

                this.edit_proyecto.Id_proyecto = dt.Rows[selRow].Field<int>(0);
                this.edit_proyecto.Nombre_proyecto = dt.Rows[selRow].Field<string>(1);
                this.edit_proyecto.Descripcion_proyecto = dt.Rows[selRow].Field<string>(2);

                name_TB.Text = edit_proyecto.Nombre_proyecto;
                description_TB.Text = edit_proyecto.Descripcion_proyecto;

                titleLabel.Content = "Edit project";
            }
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
            if (edit)
            {
                if (name_TB.Text != "" && description_TB.Text != "")
                {
                    if (name_TB.Text == edit_proyecto.Nombre_proyecto && description_TB.Text == edit_proyecto.Descripcion_proyecto)
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_proyecto.Nombre_proyecto = name_TB.Text;
                            edit_proyecto.Descripcion_proyecto = description_TB.Text;

                            edit_proyecto.ActualizarProyecto();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You must complete all the data!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                if (name_TB.Text != "" && description_TB.Text != "")
                {
                    if (MessageBox.Show("Do you want to add this project?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsProyectos nuevo_proyecto = new clsProyectos
                        {
                            Nombre_proyecto = name_TB.Text,
                            Descripcion_proyecto = description_TB.Text
                        };

                        nuevo_proyecto.AgregarProyecto();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("You must complete all the data!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                name_TB.Text = edit_proyecto.Nombre_proyecto;
                description_TB.Text = edit_proyecto.Descripcion_proyecto;
            }
            else
            {
                name_TB.Text = "";
                description_TB.Text = "";
            }
        }
    }
}
