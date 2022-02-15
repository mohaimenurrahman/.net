using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsApp.Models.Database;

namespace ProductsApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products

        public ActionResult Index()
        {
            DBEntities db = new DBEntities();
            var data = db.productsdetails.Tolist();
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(ProductsApp.Models.Database.productsdetails n)
        {
            if (ModelState.IsValid)
            {
                DBEntities db = new DBEntities();
                db.ProductsApp.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}