using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumnos.GetAll();
            ML.Alumnos alumno = new ML.Alumnos();

            alumno.Alumnos1 = result.Objects;
            return View(alumno);
        }
        

        [HttpPost]
        public ActionResult Form(ML.Alumnos alumno)
        {
            ML.Result result = BL.Alumnos.Add(alumno);
            if (result.Correct)
            {
                ViewBag.Message = "Fue registrado con exito";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Hubo un Error";
                return PartialView("Modal");
            }
        }
    }
}