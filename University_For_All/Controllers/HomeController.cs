﻿using System;
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
            var result = true;
            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new WebClient())
                    using (client.OpenRead("http://google.com/generate_204"))
                        result = false;
                }
                catch
                {
                    ViewBag.error = "check Internet Connection";
                }

                
            }
            if (!result)
            {
                var mail = new MailMessage();
                var loginInfo = new NetworkCredential("University.MyHome@gmail.com", "U123456_U");
                mail.From = new MailAddress(contactUs.Email);
                mail.To.Add(new MailAddress("abdo.gebril2000@gmail.com"));
                mail.To.Add("University.MyHome@gmail.com");
                mail.Body = "sender Email : " + contactUs.Email + "\n" +
                            "sender Message : " + contactUs.Message;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(mail);
                ViewBag.error = "";
                return RedirectToAction("Index", "Faculty");
            }
            return View("Index");
        }
    }
}
