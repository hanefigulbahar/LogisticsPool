using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;
namespace Logistic.UILayer.Controllers
{
    public class ProfileController : Controller
    {
        DBLogisticEntities db=new DBLogisticEntities();
        public ActionResult Index()
        {
            var mail = Session["CustomerMail"].ToString();
            var values = db.TblCustomer.Where(x => x.CustomerMail == mail).FirstOrDefault();
            ViewBag.v1=values.CustomerName;
            ViewBag.v2=values.CustomerSurname;
            ViewBag.v3=values.CustomerMail;
            ViewBag.v4=values.CustomerPhone;
            return View(values);

        }
        [HttpGet]
        public ActionResult UpdateCustomer()
        {
            var mail = Session["CustomerMail"].ToString();
            var id = db.TblCustomer.Where(x => x.CustomerMail == mail).Select(y=>y.CustomerID).FirstOrDefault();
            var values = db.TblCustomer.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProfile(TblCustomer p)
        {
            var values = db.TblCustomer.Find(p.CustomerID);
            values.CustomerName = p.CustomerName;
            values.CustomerSurname = p.CustomerSurname;
            values.CustomerPhone = p.CustomerPhone;
            values.CustomerMail = p.CustomerMail;
            values.CustomerPassword = p.CustomerPassword;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}