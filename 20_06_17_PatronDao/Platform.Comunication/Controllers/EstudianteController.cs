using Platform.Object.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Platform.Service.Serviceios;

namespace Platform.Comunication.Controllers
{
   public class EstudianteController
    {

       private DAOEstudiante dao = new DAOEstudiante();

        public bool solicitudGuardar(String codigo, String nombre, String apellido, int edad
            , String carrera, int semestre)
        {
            ClsEstudiante estudiante = new ClsEstudiante(codigo, nombre, apellido, edad, carrera
                , semestre );

            return dao.guardarEstudiante(estudiante);
        }

        public ClsEstudiante solicitudBuscar(String codigo)
        {
            return dao.buscarEstudiante(codigo);
        }


        public bool solicitudEditar(ClsEstudiante estudiante)
        { 
            return dao.editarEstudiante(estudiante);
        }

    }
}
