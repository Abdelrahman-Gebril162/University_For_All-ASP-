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

namespace University_For_All.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db =new ApplicationDbContext();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactUs contact)
        {
            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("abdo.gebril2000@gmail.com", "abdo162giprelwork");
            mail.From =new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("abdo.gebril2000@gmail.com"));
            mail.Body = "sender Email : " + contact.Email +"\n"+ 
                "sender Message : " +contact.Message;
            var smtpClient =new SmtpClient("smtp.gmail.com",587);
            smtpClient.EnableSsl = true;
            
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);
            return View("Index");
        }
    }
}