using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoroskoWebsite.Models;

namespace MoroskoWebsite.Controllers
{
    public class UserCoursesController : Controller
    {
        private EntitiesDBConn db = new EntitiesDBConn();

        // GET: UserCourses
        public ActionResult Index()
        {
            var userCourses = db.UserCourses.Include(u => u.AspNetUser).Include(u => u.Course).Include(u => u.Final);
            return View(userCourses.ToList());
        }

        // GET: UserCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCourse userCourse = db.UserCourses.Find(id);
            if (userCourse == null)
            {
                return HttpNotFound();
            }
            return View(userCourse);
        }

        // GET: UserCourses/Create
        public ActionResult Create()
        {
            ViewBag.aspnetusersId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.courseId = new SelectList(db.Courses, "Id", "coursename");
            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname");
            return View();
        }

        // POST: UserCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,aspnetusersId,courseId,finalId,coursegrade,finalgrade")] UserCourse userCourse)
        {
            if (ModelState.IsValid)
            {
                db.UserCourses.Add(userCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aspnetusersId = new SelectList(db.AspNetUsers, "Id", "Email", userCourse.aspnetusersId);
            ViewBag.courseId = new SelectList(db.Courses, "Id", "coursename", userCourse.courseId);
            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname", userCourse.finalId);
            return View(userCourse);
        }

        // GET: UserCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCourse userCourse = db.UserCourses.Find(id);
            if (userCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.aspnetusersId = new SelectList(db.AspNetUsers, "Id", "Email", userCourse.aspnetusersId);
            ViewBag.courseId = new SelectList(db.Courses, "Id", "coursename", userCourse.courseId);
            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname", userCourse.finalId);
            return View(userCourse);
        }

        // POST: UserCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,aspnetusersId,courseId,finalId,coursegrade,finalgrade")] UserCourse userCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aspnetusersId = new SelectList(db.AspNetUsers, "Id", "Email", userCourse.aspnetusersId);
            ViewBag.courseId = new SelectList(db.Courses, "Id", "coursename", userCourse.courseId);
            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname", userCourse.finalId);
            return View(userCourse);
        }

        // GET: UserCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCourse userCourse = db.UserCourses.Find(id);
            if (userCourse == null)
            {
                return HttpNotFound();
            }
            return View(userCourse);
        }

        // POST: UserCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCourse userCourse = db.UserCourses.Find(id);
            db.UserCourses.Remove(userCourse);
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
