using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsUsuarios
    {
        //private string _correo_usuario;
        //private int _telefono_usuario;
        //private string _id_usuario;
        //private string _nombre_usuario;
        //private string _apellidos_usuario;
        //private string _contraseña;


        //public string Correo_usuario { get => _correo_usuario; set => _correo_usuario = value; }
        //public int Telefono_usuario { get => _telefono_usuario; set => _telefono_usuario = value; }
        //public string Id_usuario { get => _id_usuario; set => _id_usuario = value; }
        //public string Nombre_usuario { get => _nombre_usuario; set => _nombre_usuario = value; }
        //public string Apellidos_usuario { get => _apellidos_usuario; set => _apellidos_usuario = value; }
        //public string Contraseña { get => _contraseña; set => _contraseña = value; }

        public string id_usuario { get; set; }
        public string contrasena { get; set; }


        ConexionSQLServer bd = new ConexionSQLServer();

        public bool Sesion { get; set; }
        //public bool IniciarSesion()
        //{
        //    try
        //    {


        //        //bd.RutasDeNombres();
        //        bd.IniciarConexion();
        //        //string sql = "select id_perfil_usuario, nombre_usuario, apellido_usuario, cedula_usuario,contra=convert(varchar(200),DecryptByPassPhrase('Mi_llave',contrasena_usuarios)) ";
        //        //sql += "from Usuarios ";
        //        //sql += "inner join PerfilesUsuarios ";
        //        //sql += "on PerfilesUsuarios.id_usuario_perfil = Usuarios.cedula_usuario WHERE cedula_usuario=" + Cedula + " and id_perfil_usuario=" + id_perfil;


        //        string sql = "select * from Usuarios1 where id_usuario="+ id_usuario;

        //        DataTable datos = bd.EjecutarConsulta(sql);


        //        if (datos.Rows.Count == 0)
        //        {
        //            Sesion = false;
        //        }
        //        else
        //        {
        //            if (contrasena == datos.Rows[0]["contrasena_usuario"].ToString())
        //            {
        //                Sesion = true;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {


        //        throw ex;
        //    }

        //    return Sesion;

        //}
    }
}
