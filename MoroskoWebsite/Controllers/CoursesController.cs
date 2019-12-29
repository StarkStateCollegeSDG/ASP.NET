﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoroskoWebsite.Models;

namespace MoroskoWebsite.Controllers
{
    public class CoursesController : Controller
    {
        private EntitiesDBConn db = new EntitiesDBConn();

        // GET: Courses
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            //This linq query gives us only the courses registered by the user.
            var courses = from c in db.Courses
                          join u in db.UserCourses on c.Id equals u.courseId
                          where u.aspnetusersId == userID
                          select c;

            var AdminLogin = from user in db.AspNetUsers
                             join role in db.AspNetRoles on user.Id equals role.AspNetUserId
                             where role.Name == "Admin"
                             select user.Id;
            //Single gives us the single result of the
            //above query as a string value.
            string admin = AdminLogin.SingleOrDefault();
            if (admin == userID)
            {
                //If the admin is logged in
                //we will show everything.
                return View(db.Courses.ToList());
            }
            else
            {
                return View(courses.ToList());
            }
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
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
            return View(course);
        }

        [Authorize(Roles = "Admin")]
        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,coursename,coursegrade,finalId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname", course.finalId);
            return View(course);
        }

        [Authorize(Roles = "Admin")]
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
            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname", course.finalId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,coursename,coursegrade,finalId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.finalId = new SelectList(db.Finals, "Id", "finalname", course.finalId);
            return View(course);
        }

        [Authorize(Roles = "Admin")]
        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
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
