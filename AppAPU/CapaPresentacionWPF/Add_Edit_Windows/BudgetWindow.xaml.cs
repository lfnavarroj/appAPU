using CapaLogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para BudgetWindow.xaml
    /// </summary>
    public partial class BudgetWindow : Window
    {
        clsPresupuestos edit_presupuesto = new clsPresupuestos();
        bool edit;
        int selRow;
        int index_proyecto;
        DataTable dt = new DataTable();

        public BudgetWindow(bool ed, int selr, int id_p)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;
            this.index_proyecto = id_p;

            if (edit)
            {
                clsPresupuestos obj = new clsPresupuestos();
                dt = obj.CargarPresupuestos(index_proyecto);

                this.edit_presupuesto.Id_presupuesto = dt.Rows[selRow].Field<int>(0);
                this.edit_presupuesto.Descripcion_presupuesto = dt.Rows[selRow].Field<string>(1);
                this.edit_presupuesto.Estado_del_presupuesto = dt.Rows[selRow].Field<string>(2);

                description_TB.Text = edit_presupuesto.Descripcion_presupuesto;
                state_TB.Text = edit_presupuesto.Estado_del_presupuesto;

                titleLabel.Content = "Edit budget";
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
                if (description_TB.Text != "" && state_TB.Text != "")
                {
                    if (description_TB.Text == edit_presupuesto.Descripcion_presupuesto && state_TB.Text == edit_presupuesto.Estado_del_presupuesto)
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_presupuesto.Descripcion_presupuesto = description_TB.Text;
                            edit_presupuesto.Estado_del_presupuesto = state_TB.Text;

                            edit_presupuesto.ActualizarPresupuesto();
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
                if (description_TB.Text != "" && state_TB.Text != "")
                {
                    if (MessageBox.Show("Do you want to add this budget?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsPresupuestos nuevo_presupuesto = new clsPresupuestos
                        {
                            Descripcion_presupuesto = description_TB.Text,
                            Estado_del_presupuesto = state_TB.Text
                        };

                        nuevo_presupuesto.AgregarPresupuesto(index_proyecto);
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
                description_TB.Text = edit_presupuesto.Descripcion_presupuesto;
                state_TB.Text = edit_presupuesto.Estado_del_presupuesto;
            }
            else
            {
                description_TB.Text = "";
                state_TB.Text = "";
            }
        }
    }
}
