using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;
namespace Logistic.UILayer.Controllers
{
    public class CategoryController : Controller
    {
        DBLogisticEntities dB = new DBLogisticEntities();
        public ActionResult Index()
        {
            var valeus = dB.TblCategory.ToList();

            return View(valeus);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCategory(TblCategory p)
        {
            dB.TblCategory.Add(p);
            dB.SaveChanges();
            return RedirectToAction("Index","NewCategory");
        }
    }
}