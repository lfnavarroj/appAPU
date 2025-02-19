﻿using CapaLogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        clsUsuarios edit_usuario = new clsUsuarios();
        bool edit;
        int selRow;
        DataTable dt = new DataTable();

        public UserWindow(bool ed, int selr)
        {
            InitializeComponent();
            this.edit = ed;
            this.selRow = selr;

            if(edit == true)
            {
                clsUsuarios obj = new clsUsuarios();
                dt = obj.CargarUsuarios();

                this.edit_usuario.Id_usuario = dt.Rows[selRow].Field<long>(0);
                this.edit_usuario.Nombre_usuario = dt.Rows[selRow].Field<string>(1);
                this.edit_usuario.Apellidos_usuario = dt.Rows[selRow].Field<string>(2);
                this.edit_usuario.Telefono_usuario = dt.Rows[selRow].Field<long>(3);
                this.edit_usuario.Correo_usuario = dt.Rows[selRow].Field<string>(4);
                this.edit_usuario.Perfil = dt.Rows[selRow].Field<string>(5);
                this.edit_usuario.Contraseña = dt.Rows[selRow].Field<string>(6);

                id_TB.Text = edit_usuario.Id_usuario.ToString();
                name_TB.Text = edit_usuario.Nombre_usuario;
                surname_TB.Text = edit_usuario.Apellidos_usuario;
                telephone_TB.Text = edit_usuario.Telefono_usuario.ToString();
                email_TB.Text = edit_usuario.Correo_usuario;
                password_TB.Password = edit_usuario.Contraseña;

                titleLabel.Content = "Edit user";

                id_TB.IsReadOnly = true;
                name_TB.IsReadOnly = true;
                surname_TB.IsReadOnly = true;
                profile_CB.IsEnabled = false;

                id_TB.Foreground = new SolidColorBrush(Colors.Black);
                name_TB.Foreground = new SolidColorBrush(Colors.Black);
                surname_TB.Foreground = new SolidColorBrush(Colors.Black);
                profile_CB.Foreground = new SolidColorBrush(Colors.Black);

                id_TB.Background = new SolidColorBrush(Colors.Transparent);
                name_TB.Background = new SolidColorBrush(Colors.Transparent);
                surname_TB.Background = new SolidColorBrush(Colors.Transparent);
                profile_CB.Background = new SolidColorBrush(Colors.Transparent);
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
                if (telephone_TB.Text != "" && email_TB.Text != "" && password_TB.Password != "")
                {
                    if (telephone_TB.Text == edit_usuario.Telefono_usuario.ToString() && email_TB.Text == edit_usuario.Correo_usuario && password_TB.Password == edit_usuario.Contraseña)
                    {
                        MessageBox.Show("No changes have been made", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            edit_usuario.Telefono_usuario = long.Parse(telephone_TB.Text);
                            edit_usuario.Correo_usuario = email_TB.Text;
                            edit_usuario.Contraseña = password_TB.Password;

                            edit_usuario.ActualizarUsuario();
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
                if (id_TB.Text != "" && name_TB.Text != "" && surname_TB.Text != "" && telephone_TB.Text != "" && email_TB.Text != "" && password_TB.Password != "")
                {
                    if (MessageBox.Show("Do you want to add this user?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        clsUsuarios nuevo_usuario = new clsUsuarios
                        {
                            Id_usuario = long.Parse(id_TB.Text),
                            Nombre_usuario = name_TB.Text,
                            Apellidos_usuario = surname_TB.Text,
                            Telefono_usuario = long.Parse(telephone_TB.Text),
                            Correo_usuario = email_TB.Text,
                            Contraseña = password_TB.Password,
                            Perfil = profile_CB.Text
                        };

                        nuevo_usuario.AgregarUsuario();
                        
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
                telephone_TB.Text = edit_usuario.Telefono_usuario.ToString();
                email_TB.Text = edit_usuario.Correo_usuario;
                password_TB.Password = edit_usuario.Contraseña;
            }
            else
            {
                id_TB.Text = "";
                name_TB.Text = "";
                surname_TB.Text = "";
                telephone_TB.Text = "";
                email_TB.Text = "";
                password_TB.Password = "";
                profile_CB.Text = "Engineer";
            }
        }
    }
}
