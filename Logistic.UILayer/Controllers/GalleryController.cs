using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    public class GalleryController : Controller
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
        public PartialViewResult PartialBanner()
        {
            return PartialView();
        }

        public PartialViewResult PartialPortfolio()
        {
            var values = db.TblCategory.ToList();
            return PartialView(values);
        }
        
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}