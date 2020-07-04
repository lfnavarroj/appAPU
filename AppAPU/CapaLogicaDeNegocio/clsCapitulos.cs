using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsCapitulos
    {
        private int _id_capitulo;
        private string _descripcion_capitulo;

        public int Id_capitulo { get => _id_capitulo; set => _id_capitulo = value; }
        public string Descripcion_capitulo { get => _descripcion_capitulo; set => _descripcion_capitulo = value; }

        public DataTable CargarCapitulos(int Id_presupuesto)
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select id_capitulo, descripcion_capitulo, id_presupuesto_capitulo ";
            sql += "from Capitulos inner join CapitulosPresupuestos on Capitulos.id_capitulo = CapitulosPresupuestos.id_capitulo_presupuesto ";
            sql += "where id_presupuesto_capitulo = " + Id_presupuesto;

            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarCapitulo(int Id_presupuesto)
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Capitulos(descripcion_capitulo) Values ('";
            sql += Descripcion_capitulo + "');";
            sql += "insert into CapitulosPresupuestos Values (";
            sql += Id_presupuesto + ", (Select max(id_capitulo) from Capitulos))";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarCapitulo()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Capitulos set descripcion_capitulo ='" + Descripcion_capitulo;
            sql += "' where id_capitulo = " + Id_capitulo;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarCapitulo(int Id_presupuesto)
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from CapitulosPresupuestos ";
            sql += "where id_presupuesto_capitulo = " + Id_presupuesto + " and id_capitulo_presupuesto = " + Id_capitulo;
            obj.Ejecutar_sql(sql);
        }
    }
}
