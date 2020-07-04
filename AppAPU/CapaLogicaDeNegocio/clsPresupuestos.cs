using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsPresupuestos
    {
        private int _fecha_realizacion;
        private string _descripcion_presupuesto;
        private string _estado_del_presupuesto;
        private int _id_presupuesto;

        public int Fecha_realizacion { get => _fecha_realizacion; set => _fecha_realizacion = value; }
        public string Descripcion_presupuesto { get => _descripcion_presupuesto; set => _descripcion_presupuesto = value; }
        public string Estado_del_presupuesto { get => _estado_del_presupuesto; set => _estado_del_presupuesto = value; }
        public int Id_presupuesto { get => _id_presupuesto; set => _id_presupuesto = value; }

        public DataTable CargarPresupuestos(int Id_proyecto)
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select id_presupuesto, descripcion_presupuesto, estado_presupuesto, id_proyecto_presupuesto ";
            sql += "from Presupuestos inner join Proyectos on Presupuestos.id_proyecto_presupuesto = Proyectos.id_proyecto";
            sql += " where id_proyecto =" + Id_proyecto;
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarPresupuesto(int Id_proyecto)
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Presupuestos(descripcion_presupuesto, estado_presupuesto, id_proyecto_presupuesto) Values ('";
            sql += Descripcion_presupuesto + "','" + Estado_del_presupuesto + "'," + Id_proyecto + ")";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarPresupuesto()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Presupuestos set descripcion_presupuesto ='" + Descripcion_presupuesto + "', estado_presupuesto = '" + Estado_del_presupuesto;
            sql += "' where id_presupuesto = " + Id_presupuesto;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarPresupuesto()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from Presupuestos ";
            sql += "where id_presupuesto = " + Id_presupuesto;
            obj.Ejecutar_sql(sql);
        }
    }
}
