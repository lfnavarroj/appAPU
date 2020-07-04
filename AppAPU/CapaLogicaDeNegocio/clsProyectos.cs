using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsProyectos
    {
        private int _id_proyecto;
        private string _nombre_proyecto;
        private string _descripcion_proyecto;

        public int Id_proyecto { get => _id_proyecto; set => _id_proyecto = value; }
        public string Nombre_proyecto { get => _nombre_proyecto; set => _nombre_proyecto = value; }
        public string Descripcion_proyecto { get => _descripcion_proyecto; set => _descripcion_proyecto = value; }

        public DataTable CargarProyectos()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select * ";
            sql += "from Proyectos";
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarProyecto()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Proyectos(nombre_proyecto, descripcion_proyecto) Values ('";
            sql += Nombre_proyecto + "','" + Descripcion_proyecto + "')";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarProyecto()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Proyectos set nombre_proyecto ='" + Nombre_proyecto + "', descripcion_proyecto = '" + Descripcion_proyecto;
            sql += "' where id_proyecto = " + Id_proyecto;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarProyecto()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from Proyectos ";
            sql += "where id_proyecto = " + Id_proyecto;
            obj.Ejecutar_sql(sql);
        }
    }
}
