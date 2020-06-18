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

namespace CapaPresentacionWPF.Add_Edit_Windows
{
    /// <summary>
    /// Lógica de interacción para EquipmentWindow.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        ManageResources gridD;
        clsEquipos edit_equipo;
        bool edit;
        int index;

        public EquipmentWindow(ManageResources gr, bool ed)
        {
            InitializeComponent();
            this.gridD = gr;
            this.edit = ed;

            if (edit == true)
            {
                this.edit_equipo = gridD.EquipmentDataGrid.SelectedItem as clsEquipos;

                serial_TB.Text = edit_equipo.Numero_de_serie.ToString();
                description_TB.Text = edit_equipo.Descripcion_equipo;
                unit_TB.Text = edit_equipo.Unidad_equipo;
                value_TB.Text = edit_equipo.Valor_uso_equipo.ToString();

                this.index = gridD.EquipmentDataGrid.SelectedIndex;

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

                            gridD.EquipmentDataGrid.Items.RemoveAt(index);
                            gridD.EquipmentDataGrid.Items.Insert(index, edit_equipo);
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
                            Numero_de_serie = long.Parse(serial_TB.Text),
                            Descripcion_equipo = description_TB.Text,
                            Unidad_equipo = unit_TB.Text,
                            Valor_uso_equipo = float.Parse(value_TB.Text)
                        };

                        gridD.EquipmentDataGrid.Items.Add(nuevo_equipo);
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