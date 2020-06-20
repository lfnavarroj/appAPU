using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class Usuario1
    {
        public string id_usuario { get; set; }
        public string contrasena { get; set; }

        ConexionSQLServer bd = new ConexionSQLServer();

        public bool sesion { get; set; }
        public bool iniciarsesion()
        {
            try
            {


                //bd.rutasdenombres();
                bd.IniciarConexion();
                //string sql = "select id_perfil_usuario, nombre_usuario, apellido_usuario, cedula_usuario,contra=convert(varchar(200),decryptbypassphrase('mi_llave',contrasena_usuarios)) ";
                //sql += "from usuarios ";
                //sql += "inner join perfilesusuarios ";
                //sql += "on perfilesusuarios.id_usuario_perfil = usuarios.cedula_usuario where cedula_usuario=" + cedula + " and id_perfil_usuario=" + id_perfil;


                string sql = "select * from usuarios1 where id_usuario=" + id_usuario;

                DataTable datos = bd.EjecutarConsulta(sql);


                if (datos.Rows.Count == 0)
                {
                    sesion = false;
                }
                else
                {
                    if (contrasena == datos.Rows[0]["contrasena_usuario"].ToString())
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
    }
}
