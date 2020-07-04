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

using CapaLogicaDeNegocio;

namespace CapaPresentacionWPF.Add_Edit_Windows
{
    /// <summary>
    /// Lógica de interacción para ChapterWindow.xaml
    /// </summary>
    public partial class ChapterWindow : Window
    {
        clsCapitulos edit_capitulo = new clsCapitulos();
        bool edit;
        int selRow;
        int index_presupuesto;
        DataTable dt = new DataTable();

        public ChapterWindow(bool ed, int selr, int id_p)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;
            this.index_presupuesto = id_p;

            if (edit)
            {
                clsCapitulos obj = new clsCapitulos();
                dt = obj.CargarCapitulos(index_presupuesto);

                this.edit_capitulo.Id_capitulo = dt.Rows[selRow].Field<int>(0);
                this.edit_capitulo.Descripcion_capitulo = dt.Rows[selRow].Field<string>(1);

                description_TB.Text = edit_capitulo.Descripcion_capitulo;

                titleLabel.Content = "Edit chapter";
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                if (description_TB.Text != "")
                {
                    if (description_TB.Text == edit_capitulo.Descripcion_capitulo)
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_capitulo.Descripcion_capitulo = description_TB.Text;

                            edit_capitulo.ActualizarCapitulo();
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
                if (description_TB.Text != "")
                {
                    if (MessageBox.Show("Do you want to add this chapter?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsCapitulos nuevo_capitulo = new clsCapitulos
                        {
                            Descripcion_capitulo = description_TB.Text,
                        };

                        nuevo_capitulo.AgregarCapitulo(index_presupuesto);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("You must complete all the data!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit without saving?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                this.Close();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                description_TB.Text = edit_capitulo.Descripcion_capitulo;
            }
            else
            {
                description_TB.Text = "";
            }
        }
    }
}
