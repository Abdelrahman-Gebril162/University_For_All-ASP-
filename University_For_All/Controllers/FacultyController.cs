using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_For_All.Models;

namespace University_For_All.Controllers
{
    public class FacultyController : Controller
    {
        private ApplicationDbContext db =new ApplicationDbContext();
        // GET: Faculty
        [HttpGet]
        public ActionResult Index()
        {
            var facutlies = db.Faculty.ToList();
            return View(facutlies);
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Faculty faculty, HttpPostedFileBase upload)
        {
            var equalFaculty = db.Faculty.SingleOrDefault(f => f.fc_name == faculty.fc_name);
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Upload/FacultyImage"), upload.FileName);
                    upload.SaveAs(path);
                }

                if (equalFaculty ==null)
                {
                    faculty.fc_logo = upload == null ? "~/Upload/Faculty_default.png" : "~/Upload/FacultyImage/" + upload.FileName;
                    db.Faculty.Add(faculty);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Faculty/Details/{id?}")]
        public ActionResult Details(int? id)
        {
            var faculty = db.Faculty.SingleOrDefault(f => f.id == id);
            
            return View(faculty);
        }
    }
}