﻿using System;
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
    [Authorize(Roles = "Admin")]
    public class FinalsController : Controller
    {
        private EntitiesDBConn db = new EntitiesDBConn();

        // GET: Finals
        public ActionResult Index()
        {
            return View(db.Finals.ToList());
        }

        // GET: Finals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Final final = db.Finals.Find(id);
            if (final == null)
            {
                return HttpNotFound();
            }
            #region comment for ViewBag.AspNetUser_Id
            //This view bag needs to be named exactly AspNetUser_Id to match the foreign
            //key in the table. This is for a drop down list that will assign the Id
            //from the AspNetUsers table to the data row being created/edited, 
            //however we will display the email and not the actual Id when using 
            //the drop down.
            #endregion
            ViewBag.AspNetUser_Id = new SelectList(db.UserCourses, "Id", "aspnetusersId");
            return View(final);
        }

        [Authorize(Roles = "Admin")]
        // GET: Finals/Create
        public ActionResult Create()
        {
            #region comment for ViewBag.AspNetUser_Id
            //This view bag needs to be named exactly AspNetUser_Id to match the foreign
            //key in the table. This is for a drop down list that will assign the Id
            //from the AspNetUsers table to the data row being created/edited, 
            //however we will display the email and not the actual Id when using 
            //the drop down.
            #endregion
            ViewBag.AspNetUser_Id = new SelectList(db.UserCourses, "Id", "aspnetusersId");
            return View();
        }

        // POST: Finals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,finalname,finalgrade")] Final final)
        {
            if (ModelState.IsValid)
            {
                db.Finals.Add(final);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            #region comment for ViewBag.AspNetUser_Id
            //This view bag needs to be named exactly AspNetUser_Id to match the foreign
            //key in the table. This is for a drop down list that will assign the Id
            //from the AspNetUsers table to the data row being created/edited, 
            //however we will display the email and not the actual Id when using 
            //the drop down.
            #endregion
            ViewBag.AspNetUser_Id = new SelectList(db.UserCourses, "Id", "aspnetusersId");

            return View(final);
        }

        [Authorize(Roles = "Admin")]
        // GET: Finals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Final final = db.Finals.Find(id);
            if (final == null)
            {
                return HttpNotFound();
            }
            return View(final);
        }

        // POST: Finals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,finalname,finalgrade")] Final final)
        {
            if (ModelState.IsValid)
            {
                db.Entry(final).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(final);
        }

        [Authorize(Roles = "Admin")]
        // GET: Finals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Final final = db.Finals.Find(id);
            if (final == null)
            {
                return HttpNotFound();
            }
            return View(final);
        }

        // POST: Finals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Final final = db.Finals.Find(id);
            db.Finals.Remove(final);
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
