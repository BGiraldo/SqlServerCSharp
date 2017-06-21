using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importacion Adicional
using Platform.Model.Entity;
// RECORDAR PONER LA DEPENDENCIA DE Data entity en el proyecto de negocio

namespace Platform.Model.DAO
{
    public class ClsEstudiante
    {

        EntidadEstudianteDataContext db;

        #region constructor

        public ClsEstudiante()
        {
            db = new EntidadEstudianteDataContext();
        }

        #endregion

        #region funciones LINQ con procedimientos almacenados

        public bool guardar(String codigo, String nombre, String apellido,
            int edad, String carrera, int semestre)
        {

            try
            {
                db.guardarEstudiante(codigo, nombre, apellido, edad, carrera, semestre);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        #endregion


        #region Metodo Buscar por procedimiento

        public Dictionary<String, Object> buscar(String codigo)
        {
            // single para traer un solo registro, sin el puedo traer varios registros

            try
            {



                var p = db.buscarEstudiante(codigo).Single();

                Dictionary<String, Object> d = new Dictionary<String, Object>();

                d.Add("codigo", p.codigo);
                d.Add("nombre", p.nombre);
                d.Add("apellido", p.apellido);
                d.Add("edad", p.edad);
                d.Add("carrera", p.carrera);
                d.Add("semestre", p.semestre);

                return d;

            }
            catch (Exception e)
            {
                return null;
            }
        }




        #endregion


        #region Metodo guardar solo con el linq

        public bool guardarLINQ(String codigo, String nombre, String apellido,
            int edad, String carrera, int semestre)
        {

            try
            {

                estudiante stu = new estudiante();

                stu.codigo = codigo;
                stu.nombre = nombre;
                stu.apellido = apellido;
                stu.edad = edad;
                stu.carrera = carrera;
                stu.semestre = semestre + "";

                db.estudiantes.InsertOnSubmit(stu);
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }


        #endregion


        #region metodo buscar con LINQ

        public Dictionary<String, Object> buscarLINQ(String codigo)
        {

            Dictionary<String, Object> d = new Dictionary<string, object>();

            /* linq puro */
            try
            {
                var consulta = from x in db.estudiantes
                               where x.codigo == codigo
                               select x;

                consulta.First();

                foreach (var p in consulta)
                {
                    d.Add("codigo", p.codigo);
                    d.Add("nombre", p.nombre);
                    d.Add("apellido", p.apellido);
                    d.Add("edad", p.edad);
                    d.Add("carrera", p.carrera);
                    d.Add("semestre", p.semestre);
                }

                return d;

            }
            catch (Exception e)
            {
                return null;
            }

        }

        #endregion


        #region metodo buscar con Lambda

        public Dictionary<String, Object> buscarLAMBDA(String codigo)
        {

            try
            {

                Dictionary<String, Object> d = new Dictionary<string, object>();

                /* Expresion Lambda */

                var consulta = db.estudiantes.Where(p => p.codigo == codigo);

                consulta.First();

                foreach (var p in consulta)
                {
                    d.Add("codigo", p.codigo);
                    d.Add("nombre", p.nombre);
                    d.Add("apellido", p.apellido);
                    d.Add("edad", p.edad);
                    d.Add("carrera", p.carrera);
                    d.Add("semestre", p.semestre);
                }

                return d;

            }
            catch (Exception e)
            {
                return null;
            }

        }

        #endregion


        #region metodo Editar con Linq

        public bool editarLinq(String codigo, String nombre, String apellido,
            int edad, String carrera, int semestre)
        {

            try
            {

                /* Expresion Linq */

                var consulta = from x in db.estudiantes where x.codigo == codigo select x;

                consulta.First();

                foreach (estudiante est in consulta)
                {
                    est.codigo = codigo;
                    est.nombre = nombre;
                    est.apellido = apellido;
                    est.edad = edad;
                    est.carrera = carrera;
                    est.semestre = semestre + "";
                }

                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion

        #region metodo Editar con procedimiento

        public bool editarPorProcedimiento(String codigo, String nombre, String apellido,
            int edad, String carrera, int semestre)
        {

            try
            {

                db.editarEstudiante(codigo, nombre, apellido, edad,
                   carrera, semestre);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion


        #region metodo Eliminar con Linq

        public bool eliminarLinq(String codigo)
        {

            try
            {

                /* Expresion Linq */

                var consulta = from x in db.estudiantes where x.codigo == codigo select x;

                consulta.First();

                // el foreach no es necesario ya que solo es uno
                foreach (estudiante e in consulta)
                {
                    db.estudiantes.DeleteOnSubmit(e);
                }
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion


        #region metodo Eliminar con Procedimiento

        public bool eliminarConProcedimiento(String codigo)
        {
            try
            {
                db.eliminarEstudiante(codigo);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion



    }
}
