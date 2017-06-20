using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Object.Model
{
   public class ClsEstudiante
    {

        private String codigo;

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private String apellido;

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        private String carrera;

        public String Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

        private int semestre;

        public int Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }


        public ClsEstudiante(String codigo, String nombre, String apellido, int edad,
             String carrera, int semestre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.carrera = carrera;
            this.semestre = semestre;
        }

        public ClsEstudiante()
        {

        }


    }
}
