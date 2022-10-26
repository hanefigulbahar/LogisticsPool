using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;
namespace Logistic.UILayer.Controllers
{
    
    public class CustomerController : Controller
    {
        DBLogisticEntities db = new DBLogisticEntities();

        public ActionResult Index()
        {
            var values = db.TblCustomer.ToList();
            return View(values);
            
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(TblCustomer p)
        {
            db.TblCustomer.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCustomer(int id)
        {
            var values = db.TblCustomer.Find(id);
            db.TblCustomer.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var values = db.TblCustomer.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(TblCustomer p)
        {
            var values = db.TblCustomer.Find(p.CustomerID);
            values.CustomerName  = p.CustomerName;
            values.CustomerSurname  = p.CustomerSurname;
            values.CustomerPhone  = p.CustomerPhone;
            values.CustomerMail  = p.CustomerMail;
            values.CustomerPassword  = p.CustomerPassword;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}