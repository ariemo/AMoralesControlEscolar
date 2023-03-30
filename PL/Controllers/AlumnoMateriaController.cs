using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.AlumnoMateria.GetAll();
            ML.Alumnos alumno = new ML.Alumnos();

            alumno.Alumnos1 = result.Objects;
            return View(alumno);
        }
        [HttpGet]
        public ActionResult SelectAlumnoMateria(int? IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.SelectAlumnoMateria(IdAlumno.Value);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            alumnomateria.AlumnoMaterias = result.Objects;
            return View(alumnomateria);
        }
    }
}