using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Use this application to record your weight over time and view charts.";

            return View();
        }
        public ActionResult Weights()
        {
            ViewData["Message"] = "Record your weight here";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
