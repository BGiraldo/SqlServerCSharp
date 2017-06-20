using Platform.Object;
using Platform.Object.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service.Serviceios
{
   public class DAOEstudiante : ClsConexion
    {

        ClsEstudiante estudiante = new ClsEstudiante();

        public bool guardarEstudiante(ClsEstudiante estudiante)
        {
            String consulta = "exec guardarEstdudiante'" + estudiante.Codigo
                + "','" + estudiante.Nombre + "','" + estudiante.Apellido + "',"
                + estudiante.Edad + ",'" + estudiante.Carrera + "'," + estudiante.Semestre + ";";
            return ejecutar(consulta);
        }

        public ClsEstudiante buscarEstudiante(String codigo)
        {
            String consulta = "exec buscarEstudiante '" + codigo + "';";
            ejecutarRetorno(consulta);

            if (dataset.Tables[0].Rows.Count == 0)
            {
                dataset.Dispose();
            }
            else
            {
                estudiante.Codigo = dataset.Tables[0].Rows[0]["codigo"].ToString();
                estudiante.Nombre = dataset.Tables[0].Rows[0]["nombre"].ToString();
                estudiante.Apellido = dataset.Tables[0].Rows[0]["apellido"].ToString();
                estudiante.Edad = Convert.ToInt32(dataset.Tables[0].Rows[0]["edad"].ToString());
                estudiante.Carrera = dataset.Tables[0].Rows[0]["carrera"].ToString();
                estudiante.Semestre = Convert.ToInt32(dataset.Tables[0].Rows[0]["semestre"].ToString());
                dataset.Dispose();
            }


            return estudiante;
        }

        public bool editarEstudiante(ClsEstudiante estudiante)
        {
            String consulta = "";
          return  ejecutar(consulta);
        }


    }
}
