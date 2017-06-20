using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// additional Imports
using System.Data;//SQLSERVER
using System.Data.SqlClient;//SQLSERVER
using System.Configuration;

namespace Platform.Object
{
    public class ClsConexion
    {

        String cadena;
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataAdapter adaptador;
        protected DataSet dataset;


        public bool ejecutar(String sql)
        {
            cadena = ConfigurationManager.ConnectionStrings["conexionBD"].ToString();

            conexion = new SqlConnection(cadena);
            comando = new SqlCommand(sql, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            desconectar();
            return true;
        }

        public void desconectar()
        {

            conexion.Close();

        }

        public bool ejecutarRetorno(String sql)
        {
            cadena = ConfigurationManager.ConnectionStrings["conexionBD"].ToString();
            conexion = new SqlConnection(cadena);
            conexion.Open();
            // difference respect to before method
            adaptador = new SqlDataAdapter(sql, conexion);
            dataset = new DataSet();
            adaptador.Fill(dataset);
            desconectar();
            return true;
        }

















    }
}
