using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using University_For_All.Models;
using University_For_All.ViewModels;

namespace University_For_All.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db =new ApplicationDbContext();
        public ActionResult Index()
        {
            var contactUsAndStudent = new ContactUsAndStudent();
            
            return View(contactUsAndStudent);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contacts(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                var loginInfo = new NetworkCredential("abdo.gebril2000@gmail.com", "abdo162giprelwork");
                mail.From = new MailAddress(contactUs.Email);
                mail.To.Add(new MailAddress("abdo.gebril2000@gmail.com"));
                mail.Body = "sender Email : " + contactUs.Email + "\n" +
                            "sender Message : " + contactUs.Message;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(mail);
                return RedirectToAction("Index", "Faculty");
            }
            
            return View("Index");
        }
    }
}