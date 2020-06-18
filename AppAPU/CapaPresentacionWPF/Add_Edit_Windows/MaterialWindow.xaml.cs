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
    /// Lógica de interacción para AddMaterialWindow.xaml
    /// </summary>
    public partial class MaterialWindow : Window
    {
        ManageResources gridD;
        clsMateriales edit_material;
        bool edit;
        int index;

        public MaterialWindow(ManageResources gr, bool ed)
        {
            InitializeComponent();
            this.gridD = gr;
            this.edit = ed;

            if (edit == true)
            {
                this.edit_material = gridD.MaterialsDataGrid.SelectedItem as clsMateriales;

                name_TB.Text = edit_material.Nombre_material;
                value_TB.Text = edit_material.Precio_material.ToString();

                this.index = gridD.MaterialsDataGrid.SelectedIndex;

                titleLabel.Content = "Edit material";
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
                if (name_TB.Text != "" && value_TB.Text != "")
                {
                    if (name_TB.Text != edit_material.Nombre_material && value_TB.Text == edit_material.Precio_material.ToString())
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_material.Nombre_material = name_TB.Text;
                            edit_material.Precio_material = float.Parse(value_TB.Text);

                            gridD.MaterialsDataGrid.Items.RemoveAt(index);
                            gridD.MaterialsDataGrid.Items.Insert(index, edit_material);
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
                if (name_TB.Text != "" && value_TB.Text != "")
                {
                    if (MessageBox.Show("Do you want to add this material?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsMateriales nuevo_material = new clsMateriales
                        {
                            Nombre_material = name_TB.Text,
                            Precio_material = float.Parse(value_TB.Text)
                        };

                        gridD.MaterialsDataGrid.Items.Add(nuevo_material);
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
                name_TB.Text = edit_material.Nombre_material;
                value_TB.Text = edit_material.Precio_material.ToString();
            }
            else
            {
                name_TB.Text = "";
                value_TB.Text = "";
            }
        }
    }
}
