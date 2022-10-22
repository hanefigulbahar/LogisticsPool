using Logistic.UILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logistic.UILayer.Controllers
{
    public class DashboardController : Controller
    {
        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Index()
        {
            ViewBag.v1 = db.TblCategory.Count();
            ViewBag.v2 = db.TblCustomer.Count();
            ViewBag.v3 = db.TblCategory.Where(x => x.CategoryID == 1).Select(y => y.CategoryName).FirstOrDefault();
            ViewBag.v4 = db.TblCategory.Where(x => x.CategoryStatus == true).Count();


            return View();
        }
    }
}