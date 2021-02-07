using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University_For_All.Models;
using WebGrease.Css.Extensions;

namespace University_For_All.Controllers
{
    public class TakesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Takes
        public ActionResult Index()
        {
            var takes = db.Takes.Include(t => t.Course).Include(t => t.Grade).Include(t => t.Student);
            
            return View(takes.ToList());
        }

        // GET: Takes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Take take = db.Takes.Find(id);
            if (take == null)
            {
                return HttpNotFound();
            }
            return View(take);
        }

        // GET: Takes/Create
        public ActionResult Create(string flash)
        {
            ViewBag.Courseid = new SelectList(db.Courses, "id", "cr_title");
            ViewBag.Gradeid = new SelectList(db.Grades, "id", "Latter");
            ViewBag.Studentid = new SelectList(db.Student, "id", "st_fname");
            if (flash == "1")
                ViewBag.error = "This student Take This Course Before Or There isn't Courses In his/her level Yet";
            return View();
        }

        // POST: Takes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Studentid,Courseid,Gradeid")] Take take)
        {
            if (ModelState.IsValid)
            {
                db.Takes.Add(take);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return Create("1");
                }
                return RedirectToAction("Index");
            }

            
            ViewBag.Courseid = new SelectList(db.Courses, "id", "cr_title", take.Courseid);
            ViewBag.Gradeid = new SelectList(db.Grades, "id", "Latter", take.Gradeid);
            ViewBag.Studentid = new SelectList(db.Student, "id", "st_fname", take.Studentid);
            return View(take);
        }

        // GET: Takes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Take take = db.Takes.Find(id);
            if (take == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courseid = new SelectList(db.Courses, "id", "cr_title", take.Courseid);
            ViewBag.Gradeid = new SelectList(db.Grades, "id", "Latter", take.Gradeid);
            ViewBag.Studentid = new SelectList(db.Student, "id", "st_fname", take.Studentid);
            return View(take);
        }

        // POST: Takes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Studentid,Courseid,Gradeid")] Take take)
        {
            if (ModelState.IsValid)
            {
                db.Entry(take).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courseid = new SelectList(db.Courses, "id", "cr_title", take.Courseid);
            ViewBag.Gradeid = new SelectList(db.Grades, "id", "Latter", take.Gradeid);
            ViewBag.Studentid = new SelectList(db.Student, "id", "st_fname", take.Studentid);
            return View(take);
        }

        // GET: Takes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Take take = db.Takes.Find(id);
            if (take == null)
            {
                return HttpNotFound();
            }
            return View(take);
        }

        // POST: Takes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Take take = db.Takes.Find(id);
            db.Takes.Remove(take);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCoursesList(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var faculty = db.Student.Single(c=>c.id==id).FacultyId;
            var level = db.Student.Single(c => c.id == id).st_level;
            var courseList = db.Courses.Where(c => c.Facultyid == faculty).Where(c=>c.cr_level==level).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
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
