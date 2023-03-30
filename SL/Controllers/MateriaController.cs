using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SL.Controllers
{
    public class MateriaController : ApiController
    {
        [HttpGet]
        [Route("api/Materia/GetAll")]
        // GET: Materia
        public IHttpActionResult GetAll()
        {
            ML.Materias materias = new ML.Materias();
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
               
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}