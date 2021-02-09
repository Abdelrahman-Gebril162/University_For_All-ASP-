using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using University_For_All.Models;
using University_For_All.ViewModels;

namespace University_For_All.Controllers
{
    public class StaffController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> UserManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        private readonly RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //View Form For Adding new student
        [HttpGet]
        public ActionResult New()
        {
            var faculties = db.Faculty.ToList();
            var rank = db.Ranks.ToList();
            var staffRoleCheck = roleManager.FindByName("professor");
            if (staffRoleCheck ==null)
            {
                return Content("Role professor doesn't Exist Right Now;");
            }
            if (faculties.Count == 0)
            {
                return Content("Please add Faculty");
            }
            var newStaff = new NewStaffViewModels()
            {
                Faculties = faculties,
                Ranks = rank
            };
            return View(newStaff);
        }
        //Action for send new Student To DataBase
        [HttpPost]
        public ActionResult NewStaff(Instructor Instructor, HttpPostedFileBase upload)
        {
            var userWithSameEmail = db.Instructors.SingleOrDefault(s => s.ints_email == Instructor.ints_email);
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Upload/InstruactorImage"), upload.FileName);
                    upload.SaveAs(path);
                }

                if (userWithSameEmail == null)
                {
                    Instructor.inst_picture = upload == null ? "~/Upload/defaultImage/staff.png" : "~/Upload/InstruactorImage/" + upload.FileName;
                    db.Instructors.Add(Instructor);
                    db.SaveChanges();
                    ApplicationUser newUser = new ApplicationUser()
                    {
                        Email = Instructor.ints_email,
                        UserName = Instructor.ints_email,
                    };
                    var check = UserManeger.Create(newUser, Instructor.inst_password);
                    if (check.Succeeded)
                    {
                        UserManeger.AddToRole(newUser.Id, "professor");
                    }
                }
                else
                    return Content("<h2><span style='color:Blue'> Email</span></h2>");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var staffDetails = db.Instructors.Include(t => t.Faculty).Include(t => t.Rank)
                .SingleOrDefault(t => t.id == id);
            if (db.Courses.Where(c => c.Instructorid == staffDetails.id).ToList().Count==0)
            {
                @ViewBag.courses = 0;
            }
            else
            {
                @ViewBag.courses = db.Courses.Where(c => c.Instructorid == staffDetails.id).ToList();
            }
            return View(staffDetails);
        }
        [HttpGet]
        [Route ("Staff/Edit/{id?}/{routename?}")]
        public ActionResult Edit(int id, string routename)
        {
            ViewBag.ranks = db.Ranks.ToList();
            var staff = db.Instructors.Include(s => s.Rank).SingleOrDefault(s => s.id == id);
            if (routename == "changePassword")
            {
                return View("ChangePassword", staff);
            }
            if (routename == "changeEmail")
            {
                return View("ChangeEmail", staff);
            }

            return View(staff);
        }
        [HttpPost]
        public ActionResult Save(Instructor instructor, int id, string newPassword, HttpPostedFileBase upload, string confirmPassword, string oldPassword, string from)
        {

            var editedStaff = db.Instructors.SingleOrDefault(s => s.id == id);
            if (from == "changePassword")
            {
                if (oldPassword == editedStaff.inst_password)
                {
                    editedStaff.inst_password = newPassword;
                    editedStaff.inst_confirmPassword = confirmPassword;
                    db.SaveChanges();
                    var user = UserManeger.FindByEmail(editedStaff.ints_email);
                    Logout();

                }
            }
            else if (from == "changeEmail")
            {
                var user = UserManeger.FindByEmail(editedStaff.ints_email);
                user.UserName = instructor.ints_email;
                user.Email = instructor.ints_email;
                UserManeger.Update(user);
                editedStaff.ints_email = instructor.ints_email;
                db.SaveChanges();
                return Logout();
            }
            else if (from == "Edit")
            {

                editedStaff.ints_fname = instructor.ints_fname;
                editedStaff.ints_fname = instructor.ints_fname;
                editedStaff.Rankid = instructor.Rankid;
                var oldImg = editedStaff.inst_picture.Substring(22);

                if (upload != null)
                {
                    System.IO.File.Delete(@"D:\abdo\FCI\my work\web\University_For_All\University_For_All\Upload\InstruactorImage\" + oldImg);
                    var path = Path.Combine(Server.MapPath("~/Upload/InstruactorImage"), upload.FileName);
                    upload.SaveAs(path);
                    editedStaff.inst_picture = "~/Upload/InstruactorImage/" + upload.FileName;
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var staff = db.Instructors.SingleOrDefault(s => s.id == id);
            return View(staff);
        }
        [HttpPost]
        public ActionResult Delete(Instructor instructor)
        {
            var editedStaff = db.Instructors.SingleOrDefault(s => s.id == instructor.id);
            var CoursesByInstructor = db.Courses.Where(c => c.Instructorid == instructor.id).ToList();
            foreach (var course in CoursesByInstructor)
            {
                course.Instructorid = null;
            }
            var oldImg = editedStaff.inst_picture.Substring(22);
            System.IO.File.Delete(@"D:\abdo\FCI\my work\web\University_For_All\University_For_All\Upload\InstruactorImage\" + oldImg);
            db.SaveChanges();
            var user = UserManeger.FindByEmail(editedStaff.ints_email);
            UserManeger.Delete(user);
            db.Instructors.Remove(db.Instructors.Single(s => s.id == editedStaff.id));
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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