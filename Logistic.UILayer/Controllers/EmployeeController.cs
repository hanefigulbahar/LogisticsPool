using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        DBLogisticEntities db= new DBLogisticEntities();
        public ActionResult Index()
        {
            var values=db.TblEmployee.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(TblEmployee p)
        {
            db.TblEmployee.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            var values = db.TblEmployee.Find(id);
            db.TblEmployee.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var values = db.TblEmployee.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(TblEmployee p)
        {
            var values = db.TblEmployee.Find(p.EmployeeID);
            values.EmployeeNameSurname = p.EmployeeNameSurname;
            values.EmployeeImage = p.EmployeeImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}