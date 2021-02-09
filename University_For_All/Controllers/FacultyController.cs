using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_For_All.Models;
using System.Data.Entity;

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
        public ActionResult Edit(int? id)
        {
            var faculty = db.Faculty.SingleOrDefault(f => f.id == id);
            
            return View(faculty);
        }
        [HttpPost]
        public ActionResult Save(Faculty faculty,HttpPostedFileBase upload,int id)
        {
            var facultyEdited = db.Faculty.SingleOrDefault(f => f.id == id);
            var oldImg = facultyEdited.fc_logo.Substring(22);
            facultyEdited.fc_name = faculty.fc_name;
            facultyEdited.fc_description = faculty.fc_description;
            if (upload !=null)
            {
                System.IO.File.Delete(@"D:\abdo\FCI\my work\web\University_For_All\University_For_All\Upload\FacultyImage\" + oldImg);
                var path = Path.Combine(Server.MapPath("~/Upload/FacultyImage"), upload.FileName);
                upload.SaveAs(path);
                facultyEdited.fc_logo = "~/Upload/FacultyImage/" + upload.FileName;
            }
            db.SaveChanges();
            var student = db.Student.Where(s => s.FacultyId == id).ToList();
            if (student.Count!=0)
            {
                foreach (var st in student)
                {
                    st.Faculty.fc_name = facultyEdited.fc_name;
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var faculty = db.Faculty.SingleOrDefault(f => f.id == id);
            return View(faculty);
        }
        [HttpPost]
        public ActionResult Delete(Faculty faculty)
        {
            var studentInthisFaculty = db.Student.Where(s => s.FacultyId == faculty.id).ToList();
            var InstructorInthisFaculty = db.Instructors.Where(I => I.Facultyid == faculty.id).ToList();
            var oldImg = faculty.fc_logo.Substring(22);
            foreach (var student in studentInthisFaculty)
            {
                db.Takes.Remove(db.Takes.Single(t=>t.Studentid==student.id));
                db.SaveChanges();
            }
            foreach (var instructor in InstructorInthisFaculty)
            {
                db.Instructors.Remove(db.Instructors.Single(I => I.id == instructor.id));
                db.SaveChanges();
            }
            System.IO.File.Delete(@"D:\abdo\FCI\my work\web\University_For_All\University_For_All\Upload\FacultyImage\" + oldImg);
            db.Faculty.Remove(db.Faculty.Single(f => f.id == faculty.id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var faculty = db.Faculty.SingleOrDefault(f => f.id == id);
            ViewBag.id = id;
            return View(faculty);
        }
        [HttpGet]
        public ActionResult Staff(int id)
        {
            var staff = db.Instructors.Include(s => s.Faculty).Where(I=>I.Facultyid==id).ToList();
            ViewBag.id = id;
            return View("Staff",staff);
        }
        public ActionResult Departments(int id)
        {
            var department = db.Departments.Include(s => s.Faculty).Where(I => I.Facultyid == id).ToList();
            ViewBag.id = id;
            return View(department);
        }
        public ActionResult Courses(int id)
        {
            var course = db.Courses.Include(s => s.Faculty).Include(s=>s.Instructor).Where(I => I.Facultyid == id).ToList();
            ViewBag.id = id;
            return View(course);
        }
        public ActionResult Students(int id)
        {
            var student = db.Student.Include(s => s.Faculty).Where(I => I.FacultyId == id).ToList();
            ViewBag.id = id;
            return View(student);
        }
    }
}