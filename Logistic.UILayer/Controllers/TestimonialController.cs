using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    public class TestimonialController : Controller
    {
        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial p)
        {
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            var values = db.TblTestimonial.Find(p.TestimonialID);
            values.NameSurname = p.NameSurname;
            values.Image = p.Image;
            values.TestimonialContent = p.TestimonialContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}