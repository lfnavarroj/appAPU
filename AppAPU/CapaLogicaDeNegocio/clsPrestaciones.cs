using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsPrestaciones
    {

        private int _codigo_prestacion;
        private string _descripcion_prestacion;
        private string _unidad_prestacion;
        private float _valor_prestacion;

        public int Codigo_prestacion { get => _codigo_prestacion; set => _codigo_prestacion = value; }
        public string Descripcion_prestacion { get => _descripcion_prestacion; set => _descripcion_prestacion = value; }
        public string Unidad_prestacion { get => _unidad_prestacion; set => _unidad_prestacion = value; }
        public float Valor_prestacion { get => _valor_prestacion; set => _valor_prestacion = value; }


        public DataTable CargarPrestaciones()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select * ";
            sql += "from Prestaciones";
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarPrestacion()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Prestaciones(descripcion_prestacion, unidad_prestacion, valor_prestacion) Values ('";
            sql += Descripcion_prestacion + "','" + Unidad_prestacion + "'," + Valor_prestacion + ")";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarPrestacion()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Prestaciones set descripcion_prestacion ='" + Descripcion_prestacion + "', unidad_prestacion = '" + Unidad_prestacion;
            sql += "', valor_prestacion = " + Valor_prestacion;
            sql += " where codigo_prestacion = " + Codigo_prestacion;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarPrestacion()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from Prestaciones ";
            sql += "where codigo_prestacion = " + Codigo_prestacion;
            obj.Ejecutar_sql(sql);
        }
    }
}
