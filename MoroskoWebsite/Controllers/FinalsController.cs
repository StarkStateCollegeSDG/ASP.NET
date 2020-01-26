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
    public class FinalsController : Controller
    {
        private EntitiesDBConn db = new EntitiesDBConn();

        // GET: Finals
        public ActionResult Index()
        {
            //TempData allows us to use values across sessions.
            if (TempData["deleteFinal"] == null)
            {
                TempData["deleteFinal"] = false;
            }
            if ((bool)TempData["deleteFinal"])
            {
                ViewBag.AlertFinal = true;
            }
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
            return View(final);
        }

        // GET: Finals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Finals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,finalname,finaldescription")] Final final)
        {
            if (ModelState.IsValid)
            {
                db.Finals.Add(final);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(final);
        }

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
        public ActionResult Edit([Bind(Include = "Id,finalname,finaldescription")] Final final)
        {
            if (ModelState.IsValid)
            {
                db.Entry(final).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(final);
        }

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
            try
            {
                Final final = db.Finals.Find(id);
                db.Finals.Remove(final);
                db.SaveChanges();
            }
            catch (Exception)
            {
                //Happens when admin deletes a final referenced in a usercourse.
                //Must delete usercourse before deleting final.
                TempData["deleteFinal"] = true;
            }
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
