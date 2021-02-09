using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_For_All.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using University_For_All.ViewModels;
using System.IO;
using System.Net;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Reporting.WebForms;

namespace University_For_All.Controllers
{
    public class StudentController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> UserManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        private readonly RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        [HttpGet]
        public ActionResult Index()
        {
            var Students = db.Student.Include(s => s.Faculty).ToList();
            return View(Students);
        }
        //View Form For Adding new student
        [HttpGet]
        public ActionResult New()
        {
            var departments = db.Departments.ToList();
            var faculties = db.Faculty.ToList();
            var studentRoleCheck = roleManager.FindByName("student");
            if (studentRoleCheck == null)
            {
                return Content("Student Role doesn't Exist Right Now");
            }
            if (faculties.Count==0 | departments.Count==0)
            {
                return Content("Please add Faculty And Department first");
            }
            var newStudent = new StudentNewStudentViewModels()
            {
                Departments = departments,
                Faculties = faculties
            };
            ViewBag.Faculty = new SelectList(faculties,"id","fc_name");
            return View(newStudent);
        }
        //Action for send new Student To DataBase
        [HttpPost]
        public ActionResult New(Student student,HttpPostedFileBase upload)
        {
            var userWithSameEmail = db.Student.SingleOrDefault(s => s.st_email == student.st_email);
            var userWithSamephone = db.Student.SingleOrDefault(s => s.st_phone == student.st_phone);
            if (ModelState.IsValid)
            {
                if (upload!=null)
                {
                    var path = Path.Combine(Server.MapPath("~/Upload/StudentImage"), upload.FileName);
                    upload.SaveAs(path);
                }

                if (userWithSameEmail==null && userWithSamephone==null)
                {
                    student.st_picture = upload == null ? "~/images/male-student-icon-png_251938.jpg" : "~/Upload/StudentImage/" + upload.FileName;
                    student.enroll_date = DateTime.Now;
                    db.Student.Add(student);
                    db.SaveChanges();
                    ApplicationUser newUser = new ApplicationUser()
                    {
                        Email = student.st_email,
                        UserName = student.st_email,
                    };
                    var check = UserManeger.Create(newUser, student.st_password);
                    if (check.Succeeded)
                    {
                        UserManeger.AddToRole(newUser.Id, "student");
                    }
                }
                else
                    return Content("<h2>Thers is User With The same <span style='color:red'> Phone Number</span> | <span style='color:Blue'> Email</span></h2>");
            }
            return RedirectToAction("Index","Home");
        }
        public JsonResult GetDepartmentList(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var departmetnList = db.Departments.Where(d => d.Facultyid == id).ToList();
            return Json(departmetnList,JsonRequestBehavior.AllowGet);
        }
        // GET: Student
       
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var studentDetails = db.Takes.Include(t=>t.Student.Department).Include(t=>t.Course.Instructor).Include(t => t.Student).Include(t => t.Course).Include(t => t.Grade).ToList()
                .Where(t => t.Studentid == id);
            if (studentDetails.Count()==0)
            {
                var studentDetails2 = db.Student.Include(s=>s.Department).Include(s=>s.Faculty).SingleOrDefault(s => s.id == id);
                @ViewBag.Studentid = studentDetails2.id;
                return View("JustStudent",studentDetails2);
            }
            var courseNum = studentDetails.Count();
            var totalGrade = 0;
            foreach (var course in studentDetails)
            {
                if (course.Gradeid !=null)
                {
                    totalGrade += course.Course.cr_credit_hours + course.Grade.points;
                }
                
            }
            ViewBag.gpa = totalGrade / courseNum;
            ViewBag.faculty = db.Faculty.Find(studentDetails.First().Student.FacultyId).fc_name;
            @ViewBag.Studentid = studentDetails.First().Studentid;
            return View(studentDetails);
        }
        [HttpGet]
        [Route("Student/Edit/{id}/{routename?}")]
        public ActionResult Edit(int id,string routename)
        {
            var student = db.Student.Include(s => s.Faculty).Include(s => s.Department).SingleOrDefault(s => s.id == id);
            if (routename== "change Password")
            {
                return View("ChangePassword", student);
            }
            else if (routename== "change Email")
            {
                return View("ChangeEmail",student);
            }
            
            return View(student);
        }
        [HttpPost]
        public ActionResult Save(Student student,int id,string newPassword,HttpPostedFileBase upload, string confirmPassword,string oldPassword, string from)
        {
            
            var editedstudent = db.Student.SingleOrDefault(s => s.id == id);
            if (from== "changePassword")
            {
                if (oldPassword == editedstudent.st_password)
                {
                    editedstudent.st_password = newPassword;
                    editedstudent.st_confirmPassword = confirmPassword;
                    db.SaveChanges();
                    var user = UserManeger.FindByEmail(editedstudent.st_email);
                    Logout();

                }
            }
            else if (from== "changeEmail")
            {
                var user = UserManeger.FindByEmail(editedstudent.st_email);
                user.UserName = student.st_email;
                user.Email = student.st_email;
                UserManeger.Update(user);
                editedstudent.st_email = student.st_email;
                db.SaveChanges();
                return Logout();
            }
            else if (from=="Edit")
            {

                editedstudent.st_address = student.st_address;
                editedstudent.st_city = student.st_city;
                editedstudent.st_phone = student.st_phone;
                var oldImg = editedstudent.st_picture.Substring(22);
                
                if (upload != null)
                {
                    System.IO.File.Delete(@"D:\abdo\FCI\my work\web\University_For_All\University_For_All\Upload\StudentImage\" + oldImg);
                    var path = Path.Combine(Server.MapPath("~/Upload/StudentImage"), upload.FileName);
                    upload.SaveAs(path);
                    editedstudent.st_picture = "~/Upload/StudentImage/" + upload.FileName;
                }
                db.SaveChanges();
            }
               
            return RedirectToAction("Index","Home");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = db.Student.SingleOrDefault(s => s.id == id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            var editedstudent = db.Student.SingleOrDefault(s => s.id == student.id);
            var studentEnroll = db.Takes.Where(t => t.Studentid == student.id).ToList();
            var oldImg = editedstudent.st_picture.Substring(22);
            System.IO.File.Delete(@"D:\abdo\FCI\my work\web\University_For_All\University_For_All\Upload\StudentImage\" + oldImg);
            db.Takes.RemoveRange(studentEnroll);
            db.SaveChanges();
            var user = UserManeger.FindByEmail(editedstudent.st_email);
            UserManeger.Delete(user);
            db.Student.Remove(db.Student.Single(s => s.id ==editedstudent.id));
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Report(int id)
        {
            var student = db.Student.SingleOrDefault(st => st.id == id);
            LocalReport localReport =new LocalReport();
            string p = Path.Combine(Server.MapPath("~/RPTReports"), "studentReport.rdlc");
            localReport.ReportPath = p;

            List<Student> students =new List<Student>();
            students.Add(student);

            ReportDataSource reportDataSource = new ReportDataSource("StudentDataset",students);
            localReport.DataSources.Add(reportDataSource);
            localReport.ReportEmbeddedResource = student.st_picture;
            string mt, enc, f;
            string[] s;
            Warning[] w;

            byte[] b = localReport.Render("PDF", null, out mt, out enc, out f, out s, out w);

            return File(b, mt);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("login", "Account");
        }

    }
}