using Assoc.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UMS_Sp22_AEntities db = new UMS_Sp22_AEntities();
            var dept = (from d in db.Departments where d.Id == 1 select d).FirstOrDefault();
            return View(dept);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}