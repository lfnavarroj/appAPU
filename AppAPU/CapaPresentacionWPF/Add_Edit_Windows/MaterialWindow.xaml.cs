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
    /// Lógica de interacción para AddMaterialWindow.xaml
    /// </summary>
    public partial class MaterialWindow : Window
    {
        clsMateriales edit_material = new clsMateriales();
        bool edit;
        int selRow;
        DataTable dt = new DataTable();

        public MaterialWindow(bool ed, int selr)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;

            if (edit == true)
            {
                clsMateriales obj = new clsMateriales();
                dt = obj.CargarMateriales();

                this.edit_material.Cod_material = dt.Rows[selRow].Field<int>(0);
                this.edit_material.Descripcion_material = dt.Rows[selRow].Field<string>(1);
                this.edit_material.Unidad_material = dt.Rows[selRow].Field<string>(2);
                this.edit_material.Precio_material = (float)dt.Rows[selRow].Field<double>(3);

                description_TB.Text = edit_material.Descripcion_material;
                unit_TB.Text = edit_material.Unidad_material;
                value_TB.Text = edit_material.Precio_material.ToString();

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
                if (description_TB.Text != "" && unit_TB.Text != "" && value_TB.Text != "")
                {
                    if (description_TB.Text == edit_material.Descripcion_material && unit_TB.Text == edit_material.Unidad_material && value_TB.Text == edit_material.Precio_material.ToString())
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_material.Descripcion_material = description_TB.Text;
                            edit_material.Unidad_material = unit_TB.Text;
                            edit_material.Precio_material = float.Parse(value_TB.Text);

                            edit_material.ActualizarMaterial();
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
                    if (MessageBox.Show("Do you want to add this material?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsMateriales nuevo_material = new clsMateriales
                        {
                            Descripcion_material = description_TB.Text,
                            Unidad_material = unit_TB.Text,
                            Precio_material = float.Parse(value_TB.Text)
                        };

                        nuevo_material.AgregarMaterial();
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
                description_TB.Text = edit_material.Descripcion_material;
                unit_TB.Text = edit_material.Unidad_material;
                value_TB.Text = edit_material.Precio_material.ToString();
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
