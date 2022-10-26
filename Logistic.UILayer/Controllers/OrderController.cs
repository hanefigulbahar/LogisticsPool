using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    
    public class OrderController : Controller
    {
        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Index()
        {
            var values = db.TblOrder.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(TblOrder p)
        {
            
            
          
            db.TblOrder.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteOrder(int id)
        {
            var values = db.TblOrder.Find(id);
            db.TblOrder.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateOrder(int id)
        {
            var values = db.TblOrder.Find(id);
            return View(values);
            
        }

        [HttpPost]
        public ActionResult UpdateOrder(TblOrder p)
        {
            var values = db.TblOrder.Find(p.OrderID);
            values.OrderCustomer = p.OrderCustomer;
            values.FromCity = p.FromCity;
            values.ToCity = p.ToCity;
            values.OrderProduct = p.OrderProduct;
            values.OrderSize = p.OrderSize;
            values.OrderPrice = p.OrderPrice;
            values.OrderDate = p.OrderDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}