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
    /// Lógica de interacción para ToolWindow.xaml
    /// </summary>
    public partial class ToolWindow : Window
    {
        clsHerramientas edit_herramienta = new clsHerramientas();
        bool edit;
        int selRow;
        DataTable dt = new DataTable();

        public ToolWindow(bool ed, int selr)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;

            if (edit == true)
            {
                clsHerramientas obj = new clsHerramientas();
                dt = obj.CargarHerramientas();

                this.edit_herramienta.Codigo_herramienta = dt.Rows[selRow].Field<int>(0);
                this.edit_herramienta.Descripcion_herramienta = dt.Rows[selRow].Field<string>(1);
                this.edit_herramienta.Unidad_herramienta = dt.Rows[selRow].Field<string>(2);
                this.edit_herramienta.Valor_uso_herramienta = (float)dt.Rows[selRow].Field<double>(3);

                description_TB.Text = edit_herramienta.Descripcion_herramienta;
                unit_TB.Text = edit_herramienta.Unidad_herramienta;
                value_TB.Text = edit_herramienta.Valor_uso_herramienta.ToString();

                titleLabel.Content = "Edit tool";
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
            if (edit == true)
            {
                if (description_TB.Text != "" && unit_TB.Text != "" && value_TB.Text != "")
                {
                    if (description_TB.Text == edit_herramienta.Descripcion_herramienta && unit_TB.Text == edit_herramienta.Unidad_herramienta && value_TB.Text == edit_herramienta.Valor_uso_herramienta.ToString())
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_herramienta.Descripcion_herramienta = description_TB.Text;
                            edit_herramienta.Unidad_herramienta = unit_TB.Text;
                            edit_herramienta.Valor_uso_herramienta = float.Parse(value_TB.Text);

                            edit_herramienta.ActualizarHerramienta();
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
                if (description_TB.Text != "" && unit_TB.Text != "" && value_TB.Text != "")
                {
                    if (MessageBox.Show("Do you want to add this tool?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsHerramientas nueva_herramienta = new clsHerramientas
                        {
                            Descripcion_herramienta = description_TB.Text,
                            Unidad_herramienta = unit_TB.Text,
                            Valor_uso_herramienta = float.Parse(value_TB.Text)
                        };

                        nueva_herramienta.AgregarHerramienta();
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
            if (edit == true)
            {
                description_TB.Text = edit_herramienta.Descripcion_herramienta;
                unit_TB.Text = edit_herramienta.Unidad_herramienta;
                value_TB.Text = edit_herramienta.Valor_uso_herramienta.ToString();
            }
            else
            {
                description_TB.Text = "";
                unit_TB.Text = "";
                value_TB.Text = "";
            }
        }
    }
}