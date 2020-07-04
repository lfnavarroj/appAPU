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
    /// Lógica de interacción para UnitWindow.xaml
    /// </summary>
    public partial class UnitWindow : Window
    {
        clsUnitarios edit_unitario = new clsUnitarios();
        bool edit;
        int selRow;
        int index_capitulo;
        int quantity;

        float suma = 0;

        DataTable dt_materiales = new DataTable();
        DataTable dt_prestaciones = new DataTable();
        DataTable dt_equipos = new DataTable();
        DataTable dt_herramientas = new DataTable();

        DataTable dt_mat_unit = new DataTable();
        DataTable dt_pre_unit = new DataTable();
        DataTable dt_equ_unit = new DataTable();
        DataTable dt_her_unit = new DataTable();

        public UnitWindow(bool ed, int selr, int id_c)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;
            this.index_capitulo = id_c;

            clsMateriales obj_m = new clsMateriales();
            dt_materiales = obj_m.CargarMateriales();

            dt_materiales.Columns[0].ColumnName = "MATERIAL CODE";
            dt_materiales.Columns[1].ColumnName = "DESCRIPTION";
            dt_materiales.Columns[2].ColumnName = "UNIT";
            dt_materiales.Columns[3].ColumnName = "VALUE";

            MaterialsDataGrid.ItemsSource = dt_materiales.DefaultView;

            dt_mat_unit.Columns.Add("MATERIAL CODE", typeof(int));
            dt_mat_unit.Columns.Add("DESCRIPTION", typeof(string));
            dt_mat_unit.Columns.Add("UNIT", typeof(string));
            dt_mat_unit.Columns.Add("VALUE", typeof(float));
            dt_mat_unit.Columns.Add("QUANTITY", typeof(int));
            dt_mat_unit.Columns.Add("TOTAL", typeof(float));
            UnitMaterialsDataGrid.ItemsSource = dt_mat_unit.DefaultView;


            clsPrestaciones obj_p = new clsPrestaciones();
            dt_prestaciones = obj_p.CargarPrestaciones();

            dt_prestaciones.Columns[0].ColumnName = "SERVICE CODE";
            dt_prestaciones.Columns[1].ColumnName = "DESCRIPTION";
            dt_prestaciones.Columns[2].ColumnName = "UNIT";
            dt_prestaciones.Columns[3].ColumnName = "VALUE";

            ServicesDataGrid.ItemsSource = dt_prestaciones.DefaultView;

            dt_pre_unit.Columns.Add("SERVICE CODE", typeof(int));
            dt_pre_unit.Columns.Add("DESCRIPTION", typeof(string));
            dt_pre_unit.Columns.Add("UNIT", typeof(string));
            dt_pre_unit.Columns.Add("VALUE", typeof(float));
            dt_pre_unit.Columns.Add("QUANTITY", typeof(int));
            dt_pre_unit.Columns.Add("TOTAL", typeof(float));
            UnitServicesDataGrid.ItemsSource = dt_pre_unit.DefaultView;


            clsEquipos obj_e = new clsEquipos();
            dt_equipos = obj_e.CargarEquipos();

            dt_equipos.Columns[0].ColumnName = "SERIAL NUMBER";
            dt_equipos.Columns[1].ColumnName = "DESCRIPTION";
            dt_equipos.Columns[2].ColumnName = "UNIT";
            dt_equipos.Columns[3].ColumnName = "VALUE";

            EquipmentDataGrid.ItemsSource = dt_equipos.DefaultView;

            dt_equ_unit.Columns.Add("SERIAL NUMBER", typeof(int));
            dt_equ_unit.Columns.Add("DESCRIPTION", typeof(string));
            dt_equ_unit.Columns.Add("UNIT", typeof(string));
            dt_equ_unit.Columns.Add("VALUE", typeof(float));
            dt_equ_unit.Columns.Add("QUANTITY", typeof(int));
            dt_equ_unit.Columns.Add("TOTAL", typeof(float));
            UnitEquipmentDataGrid.ItemsSource = dt_equ_unit.DefaultView;


            clsHerramientas obj_h = new clsHerramientas();
            dt_herramientas = obj_h.CargarHerramientas();

            dt_herramientas.Columns[0].ColumnName = "TOOL CODE";
            dt_herramientas.Columns[1].ColumnName = "DESCRIPTION";
            dt_herramientas.Columns[2].ColumnName = "UNIT";
            dt_herramientas.Columns[3].ColumnName = "VALUE";

            ToolsDataGrid.ItemsSource = dt_herramientas.DefaultView;

            dt_her_unit.Columns.Add("TOOL CODE", typeof(int));
            dt_her_unit.Columns.Add("DESCRIPTION", typeof(string));
            dt_her_unit.Columns.Add("UNIT", typeof(string));
            dt_her_unit.Columns.Add("VALUE", typeof(float));
            dt_her_unit.Columns.Add("QUANTITY", typeof(int));
            dt_her_unit.Columns.Add("TOTAL", typeof(float));
            UnitToolsDataGrid.ItemsSource = dt_her_unit.DefaultView;
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
                //if (description_TB.Text != "")
                //{
                //    if (description_TB.Text == edit_capitulo.Descripcion_capitulo)
                //    {
                //        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                //    }
                //    else
                //    {
                //        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                //        {
                //            edit_capitulo.Descripcion_capitulo = description_TB.Text;

                //            edit_capitulo.ActualizarCapitulo();
                //            this.Close();
                //        }
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("You must complete all the data!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //}
            }
            else
            {
                if (description_TB.Text != "" && unit_TB.Text != "" && quantity_TB.Text != "" && value_TB.Text != "" && value_TB.Text != "0")
                {
                    if (MessageBox.Show("Do you want to add this item?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsUnitarios nuevo_unitario = new clsUnitarios
                        {
                            Descripcion_unitario = description_TB.Text,
                            Unidad_medida_unitario = unit_TB.Text,
                        };

                        quantity = int.Parse(quantity_TB.Text);

                        nuevo_unitario.AgregarUnitario(index_capitulo, quantity, dt_mat_unit, dt_pre_unit, dt_equ_unit, dt_her_unit);
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
                //description_TB.Text = edit_prestacion.Descripcion_prestacion;
                //unit_TB.Text = edit_prestacion.Unidad_prestacion;
                //value_TB.Text = edit_prestacion.Valor_prestacion.ToString();
            }
            else
            {
                description_TB.Text = "";
                quantity_TB.Text = "";
                value_TB.Text = "";

                material_quantity_TB.Text = "";
                service_quantity_TB.Text = "";
                equipment_quantity_TB.Text = "";
                tool_quantity_TB.Text = "";
                profile_CB.Text = "";

                dt_mat_unit.Rows.Clear();
                dt_pre_unit.Rows.Clear(); 
                dt_equ_unit.Rows.Clear(); 
                dt_her_unit.Rows.Clear();

                suma = 0;
            }
        }

        private void SelectMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem != null)
            {
                bool isNumeric = int.TryParse(material_quantity_TB.Text, out int n);

                if (isNumeric && n > 0)
                {
                    selRow = MaterialsDataGrid.SelectedIndex;

                    dt_mat_unit.Rows.Add();

                    dt_mat_unit.Rows[dt_mat_unit.Rows.Count - 1][0] = dt_materiales.Rows[selRow].Field<int>(0);
                    dt_mat_unit.Rows[dt_mat_unit.Rows.Count - 1][1] = dt_materiales.Rows[selRow].Field<string>(1);
                    dt_mat_unit.Rows[dt_mat_unit.Rows.Count - 1][2] = dt_materiales.Rows[selRow].Field<string>(2);
                    dt_mat_unit.Rows[dt_mat_unit.Rows.Count - 1][3] = (float)dt_materiales.Rows[selRow].Field<double>(3);
                    dt_mat_unit.Rows[dt_mat_unit.Rows.Count - 1][4] = n;
                    dt_mat_unit.Rows[dt_mat_unit.Rows.Count - 1][5] = n * (float)dt_materiales.Rows[selRow].Field<double>(3);

                    suma += (float)dt_mat_unit.Rows[dt_mat_unit.Rows.Count - 1][5];

                    value_TB.Text = suma.ToString();
                }
                else
                {
                    MessageBox.Show("Enter a valid quantity", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void RemoveMaterial_Click(object sender, RoutedEventArgs e)
        {
            selRow = UnitMaterialsDataGrid.SelectedIndex;

            if (UnitMaterialsDataGrid.SelectedItem != null)
            {
                suma -= (float)dt_mat_unit.Rows[selRow][5];
                value_TB.Text = suma.ToString();
                dt_mat_unit.Rows.Remove(dt_mat_unit.Rows[selRow]);
            }
        }

        private void SelectService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem != null)
            {
                bool isNumeric = int.TryParse(service_quantity_TB.Text, out int n);

                if (isNumeric && n > 0)
                {
                    selRow = ServicesDataGrid.SelectedIndex;

                    dt_pre_unit.Rows.Add();

                    dt_pre_unit.Rows[dt_pre_unit.Rows.Count - 1][0] = dt_prestaciones.Rows[selRow].Field<int>(0);
                    dt_pre_unit.Rows[dt_pre_unit.Rows.Count - 1][1] = dt_prestaciones.Rows[selRow].Field<string>(1);
                    dt_pre_unit.Rows[dt_pre_unit.Rows.Count - 1][2] = dt_prestaciones.Rows[selRow].Field<string>(2);
                    dt_pre_unit.Rows[dt_pre_unit.Rows.Count - 1][3] = (float)dt_prestaciones.Rows[selRow].Field<double>(3);
                    dt_pre_unit.Rows[dt_pre_unit.Rows.Count - 1][4] = n;
                    dt_pre_unit.Rows[dt_pre_unit.Rows.Count - 1][5] = n * (float)dt_prestaciones.Rows[selRow].Field<double>(3);

                    suma += (float)dt_pre_unit.Rows[dt_pre_unit.Rows.Count - 1][5];

                    value_TB.Text = suma.ToString();
                }
                else
                {
                    MessageBox.Show("Enter a valid quantity", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void RemoveService_Click(object sender, RoutedEventArgs e)
        {
            selRow = UnitServicesDataGrid.SelectedIndex;

            if (UnitServicesDataGrid.SelectedItem != null)
            {
                suma -= (float)dt_pre_unit.Rows[selRow][5];
                value_TB.Text = suma.ToString();
                dt_pre_unit.Rows.Remove(dt_pre_unit.Rows[selRow]);
            }
        }

        private void SelectEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem != null)
            {
                bool isNumeric = int.TryParse(equipment_quantity_TB.Text, out int n);

                if (isNumeric && n > 0)
                {
                    selRow = EquipmentDataGrid.SelectedIndex;

                    dt_equ_unit.Rows.Add();

                    dt_equ_unit.Rows[dt_equ_unit.Rows.Count - 1][0] = dt_equipos.Rows[selRow].Field<int>(0);
                    dt_equ_unit.Rows[dt_equ_unit.Rows.Count - 1][1] = dt_equipos.Rows[selRow].Field<string>(1);
                    dt_equ_unit.Rows[dt_equ_unit.Rows.Count - 1][2] = dt_equipos.Rows[selRow].Field<string>(2);
                    dt_equ_unit.Rows[dt_equ_unit.Rows.Count - 1][3] = (float)dt_equipos.Rows[selRow].Field<double>(3);
                    dt_equ_unit.Rows[dt_equ_unit.Rows.Count - 1][4] = n;
                    dt_equ_unit.Rows[dt_equ_unit.Rows.Count - 1][5] = n * (float)dt_equipos.Rows[selRow].Field<double>(3);

                    suma += (float)dt_equ_unit.Rows[dt_equ_unit.Rows.Count - 1][5];

                    value_TB.Text = suma.ToString();
                }
                else
                {
                    MessageBox.Show("Enter a valid quantity", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void RemoveEquipment_Click(object sender, RoutedEventArgs e)
        {
            selRow = UnitEquipmentDataGrid.SelectedIndex;

            if (UnitEquipmentDataGrid.SelectedItem != null)
            {
                suma -= (float)dt_equ_unit.Rows[selRow][5];
                value_TB.Text = suma.ToString();
                dt_equ_unit.Rows.Remove(dt_equ_unit.Rows[selRow]);
            }
        }

        private void SelectTool_Click(object sender, RoutedEventArgs e)
        {
            if (ToolsDataGrid.SelectedItem != null)
            {
                bool isNumeric = int.TryParse(tool_quantity_TB.Text, out int n);

                if (isNumeric && n > 0)
                {
                    selRow = ToolsDataGrid.SelectedIndex;

                    dt_her_unit.Rows.Add();

                    dt_her_unit.Rows[dt_her_unit.Rows.Count - 1][0] = dt_herramientas.Rows[selRow].Field<int>(0);
                    dt_her_unit.Rows[dt_her_unit.Rows.Count - 1][1] = dt_herramientas.Rows[selRow].Field<string>(1);
                    dt_her_unit.Rows[dt_her_unit.Rows.Count - 1][2] = dt_herramientas.Rows[selRow].Field<string>(2);
                    dt_her_unit.Rows[dt_her_unit.Rows.Count - 1][3] = (float)dt_herramientas.Rows[selRow].Field<double>(3);
                    dt_her_unit.Rows[dt_her_unit.Rows.Count - 1][4] = n;
                    dt_her_unit.Rows[dt_her_unit.Rows.Count - 1][5] = n * (float)dt_herramientas.Rows[selRow].Field<double>(3);

                    suma += (float)dt_her_unit.Rows[dt_her_unit.Rows.Count - 1][5];

                    value_TB.Text = suma.ToString();
                }
                else
                {
                    MessageBox.Show("Enter a valid quantity", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void RemoveTool_Click(object sender, RoutedEventArgs e)
        {
            selRow = UnitToolsDataGrid.SelectedIndex;

            if (UnitToolsDataGrid.SelectedItem != null)
            {
                suma -= (float)dt_her_unit.Rows[selRow][5];
                value_TB.Text = suma.ToString();
                dt_her_unit.Rows.Remove(dt_her_unit.Rows[selRow]);
            }
        }

        private void Clone_Click(object sender, RoutedEventArgs e)
        {
            if (profile_CB.Text == "Overhead line")
            {
                description_TB.Text = "Overhead line";
                unit_TB.Text = "m";
                quantity_TB.Text = "5";

                clsMateriales clon_mat = new clsMateriales();
                dt_mat_unit = clon_mat.ClonarMateriales();

                dt_mat_unit.Columns[0].ColumnName = "MATERIAL CODE";
                dt_mat_unit.Columns[1].ColumnName = "DESCRIPTION";
                dt_mat_unit.Columns[2].ColumnName = "UNIT";
                dt_mat_unit.Columns[3].ColumnName = "VALUE";
                dt_mat_unit.Columns.Add("QUANTITY", typeof(int));
                dt_mat_unit.Columns.Add("TOTAL", typeof(float));

                dt_mat_unit.Rows[0][4] = 5;
                dt_mat_unit.Rows[0][5] = 5 * (float)dt_mat_unit.Rows[0].Field<double>(3);

                UnitMaterialsDataGrid.ItemsSource = dt_mat_unit.DefaultView;

                clsPrestaciones clon_pre = new clsPrestaciones();
                dt_pre_unit = clon_pre.ClonarPrestaciones();

                dt_pre_unit.Columns[0].ColumnName = "SERVICE CODE";
                dt_pre_unit.Columns[1].ColumnName = "DESCRIPTION";
                dt_pre_unit.Columns[2].ColumnName = "UNIT";
                dt_pre_unit.Columns[3].ColumnName = "VALUE";
                dt_pre_unit.Columns.Add("QUANTITY", typeof(int));
                dt_pre_unit.Columns.Add("TOTAL", typeof(float));

                dt_pre_unit.Rows[0][4] = 1;
                dt_pre_unit.Rows[0][5] = 1 * (float)dt_pre_unit.Rows[0].Field<double>(3);

                UnitServicesDataGrid.ItemsSource = dt_pre_unit.DefaultView;

                suma = (float)dt_mat_unit.Compute("sum(TOTAL)", "") + (float)dt_pre_unit.Compute("sum(TOTAL)", "");
                value_TB.Text = suma.ToString();
            }
        }
    }
}
