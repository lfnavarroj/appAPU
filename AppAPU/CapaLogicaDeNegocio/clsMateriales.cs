using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
// Referencias a las otras capas
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsMateriales
    {
        //Atributos
        private int _cod_material;
        private string _descripcion_material;
        private string _unidad_material;
        private float _precio_material;

        //Propiedades
        public int Cod_material { get => _cod_material; set => _cod_material = value; }
        public string Descripcion_material { get => _descripcion_material; set => _descripcion_material = value; }
        public float Precio_material { get => _precio_material; set => _precio_material = value; }
        public string Unidad_material { get => _unidad_material; set => _unidad_material = value; }

        public DataTable CargarMateriales()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select codigo_material, descripcion_material, unidad_material, valor_material ";
            sql += "from Materiales";
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarMaterial()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Materiales(descripcion_material, unidad_material, valor_material, fecha_actualizacion, nit_proveedor_material) Values ('";
            sql += Descripcion_material + "','" + Unidad_material + "'," + Precio_material + ", null, null)";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarMaterial()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Materiales set descripcion_material ='" + Descripcion_material + "', unidad_material = '" + Unidad_material;
            sql += "', valor_material = " + Precio_material;
            sql += " where codigo_material = " + Cod_material;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarMaterial()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from Materiales ";
            sql += "where codigo_material = " + Cod_material;
            obj.Ejecutar_sql(sql);
        }
        public DataTable ClonarMateriales()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select codigo_material, descripcion_material, unidad_material, valor_material ";
            sql += "from Materiales where codigo_material = 1";
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }
    }
}
