using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsUnitarios
    {
        private int _id_unitario;
        private string _descripcion_unitario;
        private string _unidad_medida_unitario;

        public int Id_unitario { get => _id_unitario; set => _id_unitario = value; }
        public string Descripcion_unitario { get => _descripcion_unitario; set => _descripcion_unitario = value; }
        public string Unidad_medida_unitario { get => _unidad_medida_unitario; set => _unidad_medida_unitario = value; }

        public DataTable CargarUnitarios(int Id_capitulo)
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select id_unitario, descripcion_unitario, unidad_medida_unitario, cantidad_unitarios_presupuestado, id_CapituloUnitario ";
            sql += "from Unitarios inner join UnitariosCapitulos on Unitarios.id_unitario = UnitariosCapitulos.id_UnitarioCapitulo ";
            sql += "where id_CapituloUnitario = " + Id_capitulo;

            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarUnitario(int Id_capitulo, int cantidad, DataTable materiales, DataTable prestaciones, DataTable equipos, DataTable herramientas)
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Unitarios(descripcion_unitario, unidad_medida_unitario) Values ('";
            sql += Descripcion_unitario + "','" + Unidad_medida_unitario + "')";
            obj.Ejecutar_sql(sql);

            string sql2 = "insert into UnitariosCapitulos(cantidad_unitarios_presupuestado, id_CapituloUnitario, id_UnitarioCapitulo) Values (";
            sql2 += cantidad + "," + Id_capitulo + ", (Select max(id_unitario) from Unitarios))";
            obj.Ejecutar_sql(sql2);

            for (int i = 0; i < materiales.Rows.Count; i++)
            {
                string sql3 = "insert into MaterialesUnitarios Values (";
                sql3 += materiales.Rows[i].Field<int>(4) + "," + materiales.Rows[i].Field<int>(0) + ", (Select max(id_unitario) from Unitarios))";
                obj.Ejecutar_sql(sql3);
            }

            for (int i = 0; i < prestaciones.Rows.Count; i++)
            {
                string sql4 = "insert into PrestacionesUnitarios Values (";
                sql4 += prestaciones.Rows[i].Field<int>(4) + "," + prestaciones.Rows[i].Field<int>(0) + ", (Select max(id_unitario) from Unitarios))";
                obj.Ejecutar_sql(sql4);
            }

            for (int i = 0; i < equipos.Rows.Count; i++)
            {
                string sql5 = "insert into EquiposUnitarios Values (";
                sql5 += equipos.Rows[i].Field<int>(4) + "," + equipos.Rows[i].Field<int>(0) + ", (Select max(id_unitario) from Unitarios))";
                obj.Ejecutar_sql(sql5);
            }

            for (int i = 0; i < herramientas.Rows.Count; i++)
            {
                string sql6 = "insert into HerramientasUnitarios Values (";
                sql6 += herramientas.Rows[i].Field<int>(4) + "," + herramientas.Rows[i].Field<int>(0) + ", (Select max(id_unitario) from Unitarios))";
                obj.Ejecutar_sql(sql6);
            }
        }

        public void ActualizarUnitario()
        {
            //ConexionSQLServer obj = new ConexionSQLServer();
            //obj.IniciarConexion();
            //string sql = "update Capitulos set descripcion_capitulo ='" + Descripcion_capitulo;
            //sql += "' where id_capitulo = " + Id_capitulo;
            //obj.Ejecutar_sql(sql);
        }

        public void BorrarUnitario(int Id_capitulo)
        {
            //ConexionSQLServer obj = new ConexionSQLServer();
            //obj.IniciarConexion();
            //string sql = "delete from CapitulosPresupuestos ";
            //sql += "where id_presupuesto_capitulo = " + Id_presupuesto + " and id_capitulo_presupuesto = " + Id_capitulo;
            //obj.Ejecutar_sql(sql);
        }

        public void ClonarUnitario()
        {

        }
    }
}
