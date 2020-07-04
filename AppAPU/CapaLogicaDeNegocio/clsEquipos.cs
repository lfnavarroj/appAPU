using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsEquipos
    {
        private int _numero_de_serie;
        private string _descripcion_equipo;
        private string _unidad_equipo;
        private float _valor_uso_equipo;

        public int Numero_de_serie { get => _numero_de_serie; set => _numero_de_serie = value; }
        public string Descripcion_equipo { get => _descripcion_equipo; set => _descripcion_equipo = value; }
        public string Unidad_equipo { get => _unidad_equipo; set => _unidad_equipo = value; }
        public float Valor_uso_equipo { get => _valor_uso_equipo; set => _valor_uso_equipo = value; }

        public DataTable CargarEquipos()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "select * ";
            sql += "from Equipos";
            DataTable datos = obj.EjecutarConsulta(sql);
            return datos;
        }

        public void AgregarEquipo()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "insert into Equipos Values (";
            sql += Numero_de_serie + ",'" + Descripcion_equipo + "','" + Unidad_equipo + "'," + Valor_uso_equipo + ")";
            obj.Ejecutar_sql(sql);
        }

        public void ActualizarEquipo()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "update Equipos set descripcion_equipo ='" + Descripcion_equipo + "', unidad_equipo = '" + Unidad_equipo;
            sql += "', valor_uso_equipo = " + Valor_uso_equipo;
            sql += " where no_serie = " + Numero_de_serie;
            obj.Ejecutar_sql(sql);
        }

        public void BorrarEquipo()
        {
            ConexionSQLServer obj = new ConexionSQLServer();
            obj.IniciarConexion();
            string sql = "delete from Equipos ";
            sql += "where no_serie = " + Numero_de_serie;
            obj.Ejecutar_sql(sql);
        }
    }
}
