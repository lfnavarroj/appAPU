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
    /// Lógica de interacción para ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        ManageResources gridD;
        clsPrestaciones edit_prestacion;
        bool edit;
        int index;

        public ServiceWindow(ManageResources gr, bool ed)
        {
            InitializeComponent();
            this.gridD = gr;
            this.edit = ed;

            if (edit == true)
            {
                this.edit_prestacion = gridD.ServicesDataGrid.SelectedItem as clsPrestaciones;

                description_TB.Text = edit_prestacion.Descripcion_prestacion;
                unit_TB.Text = edit_prestacion.Unidad_prestacion;
                value_TB.Text = edit_prestacion.Valor_prestacion.ToString();

                this.index = gridD.ServicesDataGrid.SelectedIndex;

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

                            gridD.ServicesDataGrid.Items.RemoveAt(index);
                            gridD.ServicesDataGrid.Items.Insert(index, edit_prestacion);
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
                        clsPrestaciones nuevo_servicio = new clsPrestaciones
                        {
                            Descripcion_prestacion = description_TB.Text,
                            Unidad_prestacion = unit_TB.Text,
                            Valor_prestacion = float.Parse(value_TB.Text)
                        };

                        gridD.ServicesDataGrid.Items.Add(nuevo_servicio);
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
