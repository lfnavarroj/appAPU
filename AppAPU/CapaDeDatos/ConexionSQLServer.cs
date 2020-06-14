using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    public class ConexionSQLServer
    {

        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataAdapter Adaptador;
        DataTable dt = new DataTable();

        public void IniciarConexion()
        {
            //Data Source=nibiruserver.database.windows.net;Initial Catalog=bdnibiru;Persist Security Info=True;User ID=lfnavarroj;Password=felipe@1987
            conexion = new SqlConnection("Data Source=nibiruserver.database.windows.net;Initial Catalog=bdnibiru;Persist Security Info=True;User ID=lfnavarroj;Password=felipe@1987");
            //conexion = new SqlConnection("Data Source=DESKTOP-AR879QI;Initial Catalog=NibiruBD;Integrated Security=True");// Conexión Local
            //Data Source=DESKTOP-AR879QI;Initial Catalog=NibiruBD;Integrated Security=True
        }

        public static SqlConnection ObtenerConexion()
        {
            //Data Source=nibiruserver.database.windows.net;Initial Catalog=bdnibiru;Persist Security Info=True;User ID=lfnavarroj;Password=felipe@1987
            return new SqlConnection("Data Source=nibiruserver.database.windows.net;Initial Catalog=bdnibiru;Persist Security Info=True;User ID=lfnavarroj;Password=felipe@1987");
            //conexion = new SqlConnection("Data Source=DESKTOP-AR879QI;Initial Catalog=NibiruBD;Integrated Security=True");// Conexión Local
            //Data Source=DESKTOP-AR879QI;Initial Catalog=NibiruBD;Integrated Security=True
        }

        public DataTable EjecutarConsulta(string Consultasql)
        {
            Adaptador = new SqlDataAdapter(Consultasql, conexion);
            //Relleno el adaptador con los datos de la memoria
            dt.Clear(); // Se realiza para vaciar el Datatable durante el tiempo de ejecución y que la conslta no sea acumulativa
            Adaptador.Fill(dt);
            return dt;
        }

        public int Ejecutar_sql(string sql)
        {
            int i = 0;

            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            i = cmd.ExecuteNonQuery();
            conexion.Close();
            return i;
        }


        public void Ejecutar_Masivo_sql(DataTable MiTabla1)
        {
            int i = 0;

            conexion.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conexion))
            {
                bulkCopy.DestinationTableName = "Veredas";
                bulkCopy.WriteToServer(MiTabla1);
            }
            //SqlCommand cmd = new SqlCommand(sql, conexion);
            //i = cmd.ExecuteNonQuery();
            //conexion.Close();
            //return i;
        }

        // ******************************************************************************
        // RECOMENDACIONES IMPORTANTES PARA TENER PRESENTE
        // ******************************************************************************
        // Todo los ciclos de inserción de datos deber realizarse desde la capar más proxima a los datos.
        // Usar consultas parametrizadas es decir usar parametros
        // Abrir la conexión y cerrar posterior a todo el proceso de consultas

        // 1. Forma nivel 1
        //    Envolver datos en transacciones
        //    Bloques using para desechar las intrucciones la momento de cerrar

        //Uso de de clase SQLBulkCopy con tablas valores y parámetros (DataTable hasta 700mil filas con buen rendimiento)


        public void CargarDatosEstaticos(string[,] matriz, string NombreBaseDatos)

        {

            //BDSqlServer obj = new BDSqlServer();
            ////obj.RutasDeNombres();
            //obj.IniciarConexion();
            IniciarConexion();
            conexion.Open();

            // Esta es una de las tanta malas practicas que he realizado en mi vida de novato en la programación
            // Usar consultas parametrizadas es decir usar parametros
            // Abrir la conexión
            if (matriz.GetLength(0) > 1)
            {

                for (int y = 1; y < matriz.GetLength(0); y++)
                {

                    DataTable tabla = new DataTable();
                    //Adaptador = new SqlDataAdapter(Consultasql, conexion);
                    //Relleno el adaptador con los datos de la memoria
                    //dt.Clear(); // Se realiza para vaciar el Datatable durante el tiempo de ejecución y que la conslta no sea acumulativa
                    //Adaptador.Fill(dt);
                    //return dt;

                    int i = 0;
                    int a = matriz.GetLength(1);

                    string sql_c = "SELECT " + matriz[0, 0] + " FROM " + NombreBaseDatos + " WHERE " + matriz[0, 0] + " =" + matriz[y, 0];
                    Adaptador = new SqlDataAdapter(sql_c, conexion);
                    //DataTable tabla = obj.EjecutarConsulta(sql_c);
                    tabla.Clear();
                    Adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        string sql_x = "UPDATE " + NombreBaseDatos;
                        sql_x += " SET ";

                        for (int p = 0; p < matriz.GetLength(1); p++)
                        {
                            if (p > 0)
                            {
                                sql_x += ",";
                            }
                            sql_x += matriz[0, p] + " ='" + matriz[y, p] + "'";

                        }

                        sql_x += " WHERE " + matriz[0, 0] + " =" + matriz[y, 0];

                        SqlCommand cmd = new SqlCommand(sql_x, conexion);
                        i = cmd.ExecuteNonQuery();
                    }
                    else
                    {

                        string sql_x = "INSERT INTO " + NombreBaseDatos;
                        sql_x += " VALUES('";

                        for (int p = 0; p < matriz.GetLength(1); p++)
                        {
                            if (p > 0)
                            {
                                sql_x += ",'";
                            }
                            sql_x += matriz[y, p] + "'";
                        }

                        sql_x += ")";

                        SqlCommand cmd = new SqlCommand(sql_x, conexion);
                        i = cmd.ExecuteNonQuery();

                        //return i;

                    }
                }

                conexion.Close();

            }
        }
    }
}
