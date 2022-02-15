using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models.Database;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            DBEntities db = new DBEntities();
            var data = db.News;
            return View(data.ToList());
        }

        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(News.Models.Database.News n)
        {
            if(ModelState.IsValid)
            {
                DBEntities db = new DBEntities();
                db.News.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(n);
        }

        public ActionResult Edit()
        {

            return View();
        }
    }
}