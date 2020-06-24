using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsHerramientas
    {
        private float _valor_uso_herramienta;
        private string _unidad_herramienta;
        private string _descripcion_herramienta;
        private int _codigo_herramienta;

        public float Valor_uso_herramienta { get => _valor_uso_herramienta; set => _valor_uso_herramienta = value; }
        public string Unidad_herramienta { get => _unidad_herramienta; set => _unidad_herramienta = value; }
        public string Descripcion_herramienta { get => _descripcion_herramienta; set => _descripcion_herramienta = value; }
        public int Codigo_herramienta { get => _codigo_herramienta; set => _codigo_herramienta = value; }

        public DataTable CargarHerramientas()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select * ";
            sql += "from Herramientas";
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarHerramienta()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Herramientas(descripcion_herramienta, unidad_herramienta, valor_herramienta) Values ('";
            sql += Descripcion_herramienta + "','" + Unidad_herramienta + "'," + Valor_uso_herramienta + ")";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarHerramienta()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Herramientas set descripcion_herramienta ='" + Descripcion_herramienta + "', unidad_herramienta = '" + Unidad_herramienta;
            sql += "', valor_herramienta = " + Valor_uso_herramienta;
            sql += " where codigo_herramienta = " + Codigo_herramienta;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarHerramienta()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from Herramientas ";
            sql += "where codigo_herramienta = " + Codigo_herramienta;
            obj.Ejecutar_sql(sql);
        }
    }
}
