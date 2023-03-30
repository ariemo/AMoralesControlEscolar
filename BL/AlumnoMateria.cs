using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AMoralesControlEscolarEntities context = new DL.AMoralesControlEscolarEntities())
                {
                    var alumnos = context.AlumnosGetAll().ToList();
                    result.Objects = new List<object>();
                    if (alumnos != null)
                    {
                        foreach (var obj in alumnos)
                        {
                            ML.Alumnos alumno = new ML.Alumnos();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result SelectAlumnoMateria(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.AMoralesControlEscolarEntities context = new DL.AMoralesControlEscolarEntities())
                {
                    var select = context.SelectAlumnoMateria(IdAlumno).ToList();
                    result.Objects = new List<object>();
                    if (select != null)
                    {
                        foreach (var obj in select)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                            alumnoMateria.Alumnos = new ML.Alumnos();
                            alumnoMateria.Alumnos.IdAlumno = (int)obj.IdAlumno;
                            alumnoMateria.Alumnos.Nombre = obj.Nombre;
                            alumnoMateria.Alumnos.ApellidoPaterno = obj.ApellidoPaterno;
                            alumnoMateria.Alumnos.ApellidoMaterno = obj.ApellidoMaterno;
                            alumnoMateria.Materias = new ML.Materias();
                            alumnoMateria.Materias.IdMateria = (int)obj.IdMateria;
                            alumnoMateria.Materias.Nombre = obj.Nombre1;
                            alumnoMateria.Materias.Costo = (decimal)obj.Costo;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
