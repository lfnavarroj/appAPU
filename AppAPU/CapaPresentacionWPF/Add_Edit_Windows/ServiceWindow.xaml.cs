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
    /// Lógica de interacción para ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        clsPrestaciones edit_prestacion = new clsPrestaciones();
        bool edit;
        int selRow;
        DataTable dt = new DataTable();

        public ServiceWindow(bool ed, int selr)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;

            if (edit == true)
            {
                clsPrestaciones obj = new clsPrestaciones();
                dt = obj.CargarPrestaciones();

                this.edit_prestacion.Codigo_prestacion = dt.Rows[selRow].Field<int>(0);
                this.edit_prestacion.Descripcion_prestacion = dt.Rows[selRow].Field<string>(1);
                this.edit_prestacion.Unidad_prestacion = dt.Rows[selRow].Field<string>(2);
                this.edit_prestacion.Valor_prestacion = (float)dt.Rows[selRow].Field<double>(3);

                description_TB.Text = edit_prestacion.Descripcion_prestacion;
                unit_TB.Text = edit_prestacion.Unidad_prestacion;
                value_TB.Text = edit_prestacion.Valor_prestacion.ToString();

                titleLabel.Content = "Edit service";
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
                    if (description_TB.Text == edit_prestacion.Descripcion_prestacion && unit_TB.Text == edit_prestacion.Unidad_prestacion && value_TB.Text == edit_prestacion.Valor_prestacion.ToString())
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_prestacion.Descripcion_prestacion = description_TB.Text;
                            edit_prestacion.Unidad_prestacion = unit_TB.Text;
                            edit_prestacion.Valor_prestacion = float.Parse(value_TB.Text);

                            edit_prestacion.ActualizarPrestacion();
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
                    if (MessageBox.Show("Do you want to add this service?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsPrestaciones nueva_prestacion = new clsPrestaciones
                        {
                            Descripcion_prestacion = description_TB.Text,
                            Unidad_prestacion = unit_TB.Text,
                            Valor_prestacion = float.Parse(value_TB.Text)
                        };

                        nueva_prestacion.AgregarPrestacion();
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
                description_TB.Text = edit_prestacion.Descripcion_prestacion;
                unit_TB.Text = edit_prestacion.Unidad_prestacion;
                value_TB.Text = edit_prestacion.Valor_prestacion.ToString();
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
