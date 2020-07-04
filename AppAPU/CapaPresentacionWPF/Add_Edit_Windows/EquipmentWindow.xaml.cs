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
    /// Lógica de interacción para EquipmentWindow.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        clsEquipos edit_equipo = new clsEquipos();
        bool edit;
        int selRow;
        DataTable dt = new DataTable();

        public EquipmentWindow(bool ed, int selr)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;

            if (edit == true)
            {
                clsEquipos obj = new clsEquipos();
                dt = obj.CargarEquipos();

                this.edit_equipo.Numero_de_serie = dt.Rows[selRow].Field<int>(0);
                this.edit_equipo.Descripcion_equipo = dt.Rows[selRow].Field<string>(1);
                this.edit_equipo.Unidad_equipo = dt.Rows[selRow].Field<string>(2);
                this.edit_equipo.Valor_uso_equipo = (float)dt.Rows[selRow].Field<double>(3);

                serial_TB.Text = edit_equipo.Numero_de_serie.ToString();
                description_TB.Text = edit_equipo.Descripcion_equipo;
                unit_TB.Text = edit_equipo.Unidad_equipo;
                value_TB.Text = edit_equipo.Valor_uso_equipo.ToString();

                titleLabel.Content = "Edit equipment";

                serial_TB.IsReadOnly = true;
                serial_TB.Foreground = new SolidColorBrush(Colors.Black);
                serial_TB.Background = new SolidColorBrush(Colors.Transparent);
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
                    if (description_TB.Text == edit_equipo.Descripcion_equipo && unit_TB.Text == edit_equipo.Unidad_equipo && value_TB.Text == edit_equipo.Valor_uso_equipo.ToString())
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_equipo.Descripcion_equipo = description_TB.Text;
                            edit_equipo.Unidad_equipo = unit_TB.Text;
                            edit_equipo.Valor_uso_equipo = float.Parse(value_TB.Text);

                            edit_equipo.ActualizarEquipo();
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
                    if (MessageBox.Show("Do you want to add this piece of equipment?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsEquipos nuevo_equipo = new clsEquipos
                        {
                            Numero_de_serie = int.Parse(serial_TB.Text),
                            Descripcion_equipo = description_TB.Text,
                            Unidad_equipo = unit_TB.Text,
                            Valor_uso_equipo = float.Parse(value_TB.Text)
                        };

                        nuevo_equipo.AgregarEquipo();
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
                description_TB.Text = edit_equipo.Descripcion_equipo;
                unit_TB.Text = edit_equipo.Unidad_equipo;
                value_TB.Text = edit_equipo.Valor_uso_equipo.ToString();
            }
            else
            {
                serial_TB.Text = "";
                description_TB.Text = "";
                unit_TB.Text = "";
                value_TB.Text = "";
            }
        }
    }
}