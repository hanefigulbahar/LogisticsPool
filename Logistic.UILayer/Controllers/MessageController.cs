using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;
namespace Logistic.UILayer.Controllers
{
    public class MessageController : Controller
    {
        DBLogisticEntities db=new DBLogisticEntities();
        
        public ActionResult Inbox()
        {
            var mail = Session["CustomerMail"].ToString();
            var values = db.TblMessage.Where(x => x.MessageReceiver == mail).ToList();
            return View(values);
        }
        public ActionResult Outbox()
        {
            var mail = Session["CustomerMail"].ToString();
            var values =db.TblMessage.Where(x => x.MessageSender == mail).ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage p)
        {
            var mail = Session["CustomerMail"].ToString();
            string messageSender = db.TblCustomer.Where(x => x.CustomerMail == mail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            string messageReceiver = db.TblCustomer.Where(x => x.CustomerMail == p.MessageReceiver).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            p.MessageSender = mail;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderName = messageSender;
            p.ReceiverName = messageReceiver;
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Outbox");
        }

        public ActionResult MessageDetails(int id)
        {
            var values = db.TblMessage.Find(id);
            return View(values);
        }
    }
}