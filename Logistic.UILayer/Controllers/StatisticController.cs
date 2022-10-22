using Logistic.UILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logistic.UILayer.Controllers
{
    public class StatisticController : Controller
    {
        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Index()
        {
            int id = db.TblCity.Where(x => x.CityName == "Ankara").Select(y => y.CityID).FirstOrDefault();

            ViewBag.v1 = db.TblOrder.Count();
            ViewBag.v2 = db.TblOrder.Where(x => x.OrderCustomer == 1).Count();
            ViewBag.v3 = db.TblCity.Where(x => x.CityName == "Ankara").Select(y => y.CityID).FirstOrDefault();
            ViewBag.v4 = db.TblOrder.Where(x => x.FromCity == id).Count();
            ViewBag.v5 = db.TblOrder.Sum(x => x.OrderPrice);
            ViewBag.v6=db.TblOrder.Average(x => x.OrderPrice);
            ViewBag.v7 = db.TblOrder.Where(x => x.OrderProduct == "Book").Sum(y => y.OrderPrice);
            return View();
        }
    }
}