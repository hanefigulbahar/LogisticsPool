using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {
            return PartialView();
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCounter()
        {
            ViewBag.v1 = db.TblCity.Count();
            ViewBag.v2 = db.TblCategory.Count();
            ViewBag.v3 = db.TblOrder.Count();
            ViewBag.v4 = db.TblCustomer.Count();

            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}