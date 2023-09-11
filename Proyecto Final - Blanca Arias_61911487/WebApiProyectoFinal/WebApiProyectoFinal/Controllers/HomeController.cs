using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Applicacion.CentrosAsistencia.QueriesAsistencia.GetAllAttendanceQuery;

namespace WebApiProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            if (Auth.isAuth) return View(Auth.currentAuth);
            var model = new LoginViewModel();

            var getAllAsistenciaQuery = new GetAllAsistenciaQuery();
            /*model.centrosAsistencia = getAllAsistenciaQuery.Execute().Select(centro => new CentroAsistencia
            {
                Id_Asistencia = centro.Id_Asistencia,
                Descripcion = centro.Descripcion
            }).ToList();*/

            List<CentroAsistencia> list = new List<CentroAsistencia>
        {
            new CentroAsistencia { Id_Asistencia = 1, Descripcion = "Base Naval" },
            new CentroAsistencia { Id_Asistencia = 2, Descripcion = "Centro de salud" }
          
        };
            model.centrosAsistencia = list;

            return View("Login", model);
        }

        public ActionResult Digitador()
        {
            return View("Digitador");
        }


     


       

    }
}
