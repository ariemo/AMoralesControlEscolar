using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materias materias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.AMoralesControlEscolarEntities context = new DL.AMoralesControlEscolarEntities())
                {
                    int query = context.MateriaAdd(materias.Nombre, materias.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Materias materias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.AMoralesControlEscolarEntities context = new DL.AMoralesControlEscolarEntities())
                {
                    var query = context.MateriaUpdate(materias.IdMateria, materias.Nombre, materias.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage=ex.Message;
                result.Ex=ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result =new ML.Result();
            try
            {
                using(DL.AMoralesControlEscolarEntities context = new DL.AMoralesControlEscolarEntities())
                {
                    var query =context.MateriaDelete(IdMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                      
                    }
                    
                }
            } catch (Exception ex)
            {
                result.Correct = false; 
                result.ErrorMessage = ex.Message;
            }
            return result ;
        }

        public static ML.Result GetAll()
        {
            ML.Result result =new ML.Result();
            try
            {
                using (DL.AMoralesControlEscolarEntities context = new DL.AMoralesControlEscolarEntities())
                {
                    var materias = context.MateriaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (materias != null)
                    {
                        foreach (var obj in materias)
                        {
                            ML.Materias materia = new ML.Materias();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = (decimal)obj.Costo;
                            result.Objects.Add(materia);
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
                result.Correct= false;
                result.ErrorMessage= ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int Idmateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.AMoralesControlEscolarEntities context = new DL.AMoralesControlEscolarEntities())
                {
                    var obj = context.MateriaGetById(Idmateria).FirstOrDefault();
                    
                    if (obj != null)
                    {
                        ML.Materias materia = new ML.Materias();
                        materia.IdMateria = obj.IdMateria;
                        materia.Nombre = obj.Nombre;
                        materia.Costo = (decimal)obj.Costo;
                        result.Object = materia;
                       
                       
                    }
                    result.Correct = true;
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
