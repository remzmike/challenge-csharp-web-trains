using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MkTrainSchedule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Title = "Home Page";

            // avoid first json request by sending current train data with view            
            ViewBag.Trains = HttpContext.Application["TrainData"];

            return View();
        }
    }
}
