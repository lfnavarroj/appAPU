using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsUsuarios
    {
        private string _correo_usuario;
        private long _telefono_usuario;
        private long _id_usuario;
        private string _nombre_usuario;
        private string _apellidos_usuario;
        private string _contraseña;
        private string _perfil;

        public string Correo_usuario { get => _correo_usuario; set => _correo_usuario = value; }
        public long Telefono_usuario { get => _telefono_usuario; set => _telefono_usuario = value; }
        public long Id_usuario { get => _id_usuario; set => _id_usuario = value; }
        public string Nombre_usuario { get => _nombre_usuario; set => _nombre_usuario = value; }
        public string Apellidos_usuario { get => _apellidos_usuario; set => _apellidos_usuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Perfil { get => _perfil; set => _perfil = value; }

        ConexionSQLServer bd = new ConexionSQLServer();

        public bool sesion { get; set; }
        public bool IniciarSesion()
        {
            try
            { 
                bd.IniciarConexion();
                string sql = "select contra = convert(varchar, decryptbypassphrase('mi_llave', contrasena_usuario)) ";
                sql += "from Usuarios where id_usuario = " + Id_usuario;
                
                DataTable datos = bd.EjecutarConsulta(sql);

                if (datos.Rows.Count == 0)
                {
                    sesion = false;
                }
                else
                {
                    if (Contraseña == datos.Rows[0]["contra"].ToString())
                    {
                        sesion = true;
                    }
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sesion;
        }

        public string PerfilActual()
        {
            string perfil;
            try
            {
                bd.IniciarConexion();
                string sql = "select nombre_perfil ";
                sql += "from Usuarios inner join Perfiles on Usuarios.id_perfil_usuario = Perfiles.id_perfil where id_usuario = " + Id_usuario;

                DataTable datos = bd.EjecutarConsulta(sql);
                perfil = datos.Rows[0]["nombre_perfil"].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return perfil;
        }

        public DataTable CargarUsuarios()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select id_usuario, nombre_usuario, apellido_usuario, telefono_usuario, correo_usuario, nombre_perfil, convert(varchar, decryptbypassphrase('mi_llave',contrasena_usuario)) ";
            sql += "from Usuarios inner join Perfiles on Usuarios.id_perfil_usuario = Perfiles.id_perfil";
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarUsuario()
        {
            int id_perfil = 1;

            switch(Perfil)
            {
                case "Administrator":
                    id_perfil = 1;
                    break;

                case "Engineer":
                    id_perfil = 2;
                    break;
            }
          
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Usuarios Values (" + Id_usuario + ",'" + Nombre_usuario + "','" + Apellidos_usuario + "',";
            sql += "encryptbypassphrase('mi_llave', '" + Contraseña + "')," + Telefono_usuario + ",'" + Correo_usuario + "'," + id_perfil + ", null)";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarUsuario()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Usuarios set telefono_usuario =" + Telefono_usuario + ", correo_usuario = '" + Correo_usuario;
            sql += "', contrasena_usuario = encryptbypassphrase('mi_llave', '" + Contraseña + "')";
            sql += "where id_usuario = " + Id_usuario;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarUsuario()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from Usuarios ";
            sql += "where id_usuario = " + Id_usuario;
            obj.Ejecutar_sql(sql);
        }
    }
}
