using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriasController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            ML.Materias materia = new ML.Materias();

            materia.Materias1 = result.Objects;
            return View(materia);
        }

        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            if (idMateria != null)
            //Editar
            {
                ML.Result result = BL.Materia.GetById(idMateria.Value);
                ML.Materias materia = new ML.Materias();

                materia = (ML.Materias)result.Object;
                return View(materia);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Materias materias)
        {
            ML.Result result = new ML.Result();
            if (materias.IdMateria != null)
            {
                result = BL.Materia.Update(materias);
                ViewBag.Message = "Se ha Actualizado el registro";
                
            }
            else
            {
                result = BL.Materia.Add(materias);
                ViewBag.Message = "Se ha agregado el registro";
               
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }
        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido registrar el usuario" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }
    }
}