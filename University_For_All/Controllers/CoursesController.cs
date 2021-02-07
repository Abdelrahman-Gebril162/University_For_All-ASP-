using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University_For_All.Models;

namespace University_For_All.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Faculty).Include(c => c.Instructor);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Include(c=>c.Faculty).Include(c=>c.Instructor).SingleOrDefault(c=>c.id==id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.Facultyid = new SelectList(db.Faculty, "id", "fc_name");
            ViewBag.Instructorid = new SelectList(db.Instructors, "id", "ints_fname");
            if (db.Courses.Count()==0 && db.Faculty.Count()==0)
            {
                return Content("Please add Faculty and Staff First");
            }
            return View();
        }
        public JsonResult GetStaffList(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var staffList = db.Instructors.Where(d => d.Facultyid == id).ToList();
            return Json(staffList, JsonRequestBehavior.AllowGet);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cr_title,cr_credit_hours,cr_term,cr_level,Facultyid,Instructorid")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Facultyid = new SelectList(db.Faculty, "id", "fc_name", course.Facultyid);
            ViewBag.Instructorid = new SelectList(db.Instructors, "id", "ints_fname", course.Instructorid);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.Facultyid = new SelectList(db.Faculty, "id", "fc_name", course.Facultyid);
            ViewBag.Instructorid = new SelectList(db.Instructors, "id", "ints_fname", course.Instructorid);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cr_title,cr_credit_hours,cr_term,cr_level,Facultyid,Instructorid")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Facultyid = new SelectList(db.Faculty, "id", "fc_name", course.Facultyid);
            ViewBag.Instructorid = new SelectList(db.Instructors, "id", "ints_fname", course.Instructorid);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Include(c => c.Faculty).Include(c => c.Instructor).SingleOrDefault(c => c.id == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
