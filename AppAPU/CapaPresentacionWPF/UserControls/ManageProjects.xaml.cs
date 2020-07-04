using CapaPresentacionWPF.Add_Edit_Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaLogicaDeNegocio;

using System.Data;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para ManageProjects.xaml
    /// </summary>
    public partial class ManageProjects : UserControl
    {
        bool edit;
        DataTable dt_proyectos = new DataTable();
        DataTable dt_presupuestos = new DataTable();
        DataTable dt_capitulos = new DataTable();
        DataTable dt_unitarios = new DataTable();
        int selRow;

        int index_proyecto;
        int index_presupuesto;
        int index_capitulo;

        public ManageProjects()
        {
            InitializeComponent();

            clsProyectos obj = new clsProyectos();
            dt_proyectos = obj.CargarProyectos();

            dt_proyectos.Columns[0].ColumnName = "PROJECT ID";
            dt_proyectos.Columns[1].ColumnName = "NAME";
            dt_proyectos.Columns[2].ColumnName = "DESCRIPTION";

            ProjectsDataGrid.ItemsSource = dt_proyectos.DefaultView;
        }

        private void ButtonAddProject_Click(object sender, RoutedEventArgs e)
        {
            this.edit = false;
            ProjectWindow projectWindow = new ProjectWindow(edit, selRow);
            projectWindow.ShowDialog();

            clsProyectos obj = new clsProyectos();
            dt_proyectos = obj.CargarProyectos();

            dt_proyectos.Columns[0].ColumnName = "PROJECT ID";
            dt_proyectos.Columns[1].ColumnName = "NAME";
            dt_proyectos.Columns[2].ColumnName = "DESCRIPTION";

            ProjectsDataGrid.ItemsSource = dt_proyectos.DefaultView;
        }

        private void ButtonEditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsDataGrid.SelectedItem != null && ProjectsDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                edit = true;
                selRow = ProjectsDataGrid.SelectedIndex;
                ProjectWindow projectWindow = new ProjectWindow(edit, selRow);
                projectWindow.ShowDialog();

                clsProyectos obj = new clsProyectos();
                dt_proyectos = obj.CargarProyectos();

                dt_proyectos.Columns[0].ColumnName = "PROJECT ID";
                dt_proyectos.Columns[1].ColumnName = "NAME";
                dt_proyectos.Columns[2].ColumnName = "DESCRIPTION";

                ProjectsDataGrid.ItemsSource = dt_proyectos.DefaultView;
            }
        }

        private void ButtonRemoveProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsDataGrid.SelectedItem != null && ProjectsDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                if (MessageBox.Show("Do you want to remove this project?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = ProjectsDataGrid.SelectedIndex;

                    clsProyectos obj = new clsProyectos()
                    {
                        Id_proyecto = dt_proyectos.Rows[selRow].Field<int>(0)
                    };

                    obj.BorrarProyecto();

                    dt_proyectos = obj.CargarProyectos();

                    dt_proyectos.Columns[0].ColumnName = "PROJECT ID";
                    dt_proyectos.Columns[1].ColumnName = "NAME";
                    dt_proyectos.Columns[2].ColumnName = "DESCRIPTION";

                    ProjectsDataGrid.ItemsSource = dt_proyectos.DefaultView;
                }
            }
        }

        private void ButtonAddBudget_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsDataGrid.SelectedItem != null && ProjectsDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                this.edit = false;
                BudgetWindow budgetWindow = new BudgetWindow(edit, selRow, index_proyecto);
                budgetWindow.ShowDialog();

                clsPresupuestos obj = new clsPresupuestos();
                dt_presupuestos = obj.CargarPresupuestos(index_proyecto);

                dt_presupuestos.Columns[0].ColumnName = "BUDGET ID";
                dt_presupuestos.Columns[1].ColumnName = "DESCRIPTION";
                dt_presupuestos.Columns[2].ColumnName = "STATE";
                dt_presupuestos.Columns[3].ColumnName = "PROJECT ID";

                BudgetsDataGrid.ItemsSource = dt_presupuestos.DefaultView;
            }
        }

        private void ButtonEditBudget_Click(object sender, RoutedEventArgs e)
        {
            if (BudgetsDataGrid.SelectedItem != null && BudgetsDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                edit = true;
                selRow = BudgetsDataGrid.SelectedIndex;
                BudgetWindow budgetWindow = new BudgetWindow(edit, selRow, index_proyecto);
                budgetWindow.ShowDialog();

                clsPresupuestos obj = new clsPresupuestos();
                dt_presupuestos = obj.CargarPresupuestos(index_proyecto);

                dt_presupuestos.Columns[0].ColumnName = "BUDGET ID";
                dt_presupuestos.Columns[1].ColumnName = "DESCRIPTION";
                dt_presupuestos.Columns[2].ColumnName = "STATE";
                dt_presupuestos.Columns[3].ColumnName = "PROJECT ID";

                BudgetsDataGrid.ItemsSource = dt_presupuestos.DefaultView;
            }
        }

        private void ButtonRemoveBudget_Click(object sender, RoutedEventArgs e)
        {
            if (BudgetsDataGrid.SelectedItem != null && BudgetsDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                if (MessageBox.Show("Do you want to remove this budget?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = BudgetsDataGrid.SelectedIndex;

                    clsPresupuestos obj = new clsPresupuestos()
                    {
                        Id_presupuesto = dt_presupuestos.Rows[selRow].Field<int>(0)
                    };

                    obj.BorrarPresupuesto();

                    dt_presupuestos = obj.CargarPresupuestos(index_proyecto);

                    dt_presupuestos.Columns[0].ColumnName = "BUDGET ID";
                    dt_presupuestos.Columns[1].ColumnName = "DESCRIPTION";
                    dt_presupuestos.Columns[2].ColumnName = "STATE";
                    dt_presupuestos.Columns[3].ColumnName = "PROJECT ID";

                    BudgetsDataGrid.ItemsSource = dt_presupuestos.DefaultView;
                }
            }
        }

        private void ButtonAddChapter_Click(object sender, RoutedEventArgs e)
        {
            if (BudgetsDataGrid.SelectedItem != null && BudgetsDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                this.edit = false;
                ChapterWindow chapterWindow = new ChapterWindow(edit, selRow, index_presupuesto);
                chapterWindow.ShowDialog();

                clsCapitulos obj = new clsCapitulos();
                dt_capitulos = obj.CargarCapitulos(index_presupuesto);

                dt_capitulos.Columns[0].ColumnName = "CHAPTER ID";
                dt_capitulos.Columns[1].ColumnName = "DESCRIPTION";
                dt_capitulos.Columns[2].ColumnName = "BUDGET ID";

                ChaptersDataGrid.ItemsSource = dt_capitulos.DefaultView;
            }
        }

        private void ButtonEditChapter_Click(object sender, RoutedEventArgs e)
        {
            if (ChaptersDataGrid.SelectedItem != null && ChaptersDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                edit = true;
                selRow = ChaptersDataGrid.SelectedIndex;
                ChapterWindow chapterWindow = new ChapterWindow(edit, selRow, index_presupuesto);
                chapterWindow.ShowDialog();

                clsCapitulos obj = new clsCapitulos();
                dt_capitulos = obj.CargarCapitulos(index_presupuesto);

                dt_capitulos.Columns[0].ColumnName = "CHAPTER ID";
                dt_capitulos.Columns[1].ColumnName = "DESCRIPTION";
                dt_capitulos.Columns[2].ColumnName = "BUDGET ID";

                ChaptersDataGrid.ItemsSource = dt_capitulos.DefaultView;
            }
        }

        private void ButtonRemoveChapter_Click(object sender, RoutedEventArgs e)
        {
            if (ChaptersDataGrid.SelectedItem != null && ChaptersDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                if (MessageBox.Show("Do you want to remove this chapter?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    selRow = ChaptersDataGrid.SelectedIndex;

                    clsCapitulos obj = new clsCapitulos()
                    {
                        Id_capitulo = dt_capitulos.Rows[selRow].Field<int>(0)
                    };

                    obj.BorrarCapitulo(index_presupuesto);

                    dt_capitulos = obj.CargarCapitulos(index_presupuesto);

                    dt_capitulos.Columns[0].ColumnName = "CHAPTER ID";
                    dt_capitulos.Columns[1].ColumnName = "DESCRIPTION";
                    dt_capitulos.Columns[2].ColumnName = "BUDGET ID";

                    ChaptersDataGrid.ItemsSource = dt_capitulos.DefaultView;
                }
            }
        }

        private void ButtonAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (ChaptersDataGrid.SelectedItem != null && ChaptersDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                this.edit = false;
                UnitWindow unitWindow = new UnitWindow(edit, selRow, index_capitulo);
                unitWindow.ShowDialog();

                clsUnitarios obj = new clsUnitarios();
                dt_unitarios = obj.CargarUnitarios(index_capitulo);

                dt_unitarios.Columns[0].ColumnName = "ITEM ID";
                dt_unitarios.Columns[1].ColumnName = "DESCRIPTION";
                dt_unitarios.Columns[2].ColumnName = "UNIT";
                dt_unitarios.Columns[3].ColumnName = "QUANTITY";
                dt_unitarios.Columns[4].ColumnName = "CHAPTER ID";

                ItemsDataGrid.ItemsSource = dt_unitarios.DefaultView;
            }
        }

        private void ButtonEditItem_Click(object sender, RoutedEventArgs e)
        {
            if (ChaptersDataGrid.SelectedItem != null && ChaptersDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                //edit = true;
                //selRow = ChaptersDataGrid.SelectedIndex;
                //ChapterWindow chapterWindow = new ChapterWindow(edit, selRow, index_presupuesto);
                //chapterWindow.ShowDialog();

                //clsUnitarios obj = new clsUnitarios();
                //dt_unitarios = obj.CargarUnitarios(index_capitulo);

                //dt_unitarios.Columns[0].ColumnName = "ITEM ID";
                //dt_unitarios.Columns[1].ColumnName = "DESCRIPTION";
                //dt_unitarios.Columns[2].ColumnName = "UNIT";
                //dt_unitarios.Columns[3].ColumnName = "QUANTITY";
                //dt_unitarios.Columns[4].ColumnName = "CHAPTER ID";

                //ItemsDataGrid.ItemsSource = dt_unitarios.DefaultView;
            }
        }

        private void ButtonRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (ChaptersDataGrid.SelectedItem != null && ChaptersDataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                if (MessageBox.Show("Do you want to remove this chapter?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    //selRow = ChaptersDataGrid.SelectedIndex;

                    //clsUnitarios obj = new clsUnitarios()
                    //{
                    //    Id_capitulo = dt_capitulos.Rows[selRow].Field<int>(0)
                    //};

                    //obj.BorrarUnitario(index_presupuesto);

                    //dt_unitarios = obj.CargarUnitarios(index_capitulo);

                    //dt_unitarios.Columns[0].ColumnName = "ITEM ID";
                    //dt_unitarios.Columns[1].ColumnName = "DESCRIPTION";
                    //dt_unitarios.Columns[2].ColumnName = "UNIT";
                    //dt_unitarios.Columns[3].ColumnName = "QUANTITY";
                    //dt_unitarios.Columns[4].ColumnName = "CHAPTER ID";

                    //ItemsDataGrid.ItemsSource = dt_unitarios.DefaultView;
                }
            }
        }

        private void ProjectsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selRow = ProjectsDataGrid.SelectedIndex;

            if (selRow < dt_proyectos.Rows.Count && selRow != -1)
            {
                index_proyecto = dt_proyectos.Rows[selRow].Field<int>(0);

                clsPresupuestos obj = new clsPresupuestos();
                dt_presupuestos = obj.CargarPresupuestos(index_proyecto);

                dt_presupuestos.Columns[0].ColumnName = "BUDGET ID";
                dt_presupuestos.Columns[1].ColumnName = "DESCRIPTION";
                dt_presupuestos.Columns[2].ColumnName = "STATE";
                dt_presupuestos.Columns[3].ColumnName = "PROJECT ID";

                BudgetsDataGrid.ItemsSource = dt_presupuestos.DefaultView;
            }
            else
            {
                dt_presupuestos.Rows.Clear();
                dt_capitulos.Rows.Clear();
                dt_unitarios.Rows.Clear();
            }
        }

        private void BudgetsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selRow = BudgetsDataGrid.SelectedIndex;

            if (selRow < dt_presupuestos.Rows.Count && selRow != -1)
            {
                index_presupuesto = dt_presupuestos.Rows[selRow].Field<int>(0);

                clsCapitulos obj = new clsCapitulos();
                dt_capitulos = obj.CargarCapitulos(index_presupuesto);

                dt_capitulos.Columns[0].ColumnName = "CHAPTER ID";
                dt_capitulos.Columns[1].ColumnName = "DESCRIPTION";
                dt_capitulos.Columns[2].ColumnName = "BUDGET ID";

                ChaptersDataGrid.ItemsSource = dt_capitulos.DefaultView;
            }
            else
            {
                dt_capitulos.Rows.Clear();
                dt_unitarios.Rows.Clear();
            }
        }

        private void ChaptersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selRow = ChaptersDataGrid.SelectedIndex;

            if (selRow < dt_capitulos.Rows.Count && selRow != -1)
            {
                index_capitulo = dt_capitulos.Rows[selRow].Field<int>(0);

                clsUnitarios obj = new clsUnitarios();
                dt_unitarios = obj.CargarUnitarios(index_capitulo);

                dt_unitarios.Columns[0].ColumnName = "ITEM ID";
                dt_unitarios.Columns[1].ColumnName = "DESCRIPTION";
                dt_unitarios.Columns[2].ColumnName = "UNIT";
                dt_unitarios.Columns[3].ColumnName = "QUANTITY";
                dt_unitarios.Columns[4].ColumnName = "CHAPTER ID";

                ItemsDataGrid.ItemsSource = dt_unitarios.DefaultView;
            }
            else
            {
                dt_unitarios.Rows.Clear();
            }
        }
    }
}
