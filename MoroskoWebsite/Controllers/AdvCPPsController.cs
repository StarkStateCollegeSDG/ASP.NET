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
    public class AdvCPPsController : Controller
    {
        private EntitiesDBConn db = new EntitiesDBConn();

        // GET: AdvCPPs
        public ActionResult Index()
        {
            return View(db.AdvCPPs.ToList());
        }

        // GET: AdvCPPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvCPP advCPP = db.AdvCPPs.Find(id);
            if (advCPP == null)
            {
                return HttpNotFound();
            }
            return View(advCPP);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdvCPPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvCPPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,projectname,description,studentname")] AdvCPP advCPP)
        {
            if (ModelState.IsValid)
            {
                db.AdvCPPs.Add(advCPP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advCPP);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdvCPPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvCPP advCPP = db.AdvCPPs.Find(id);
            if (advCPP == null)
            {
                return HttpNotFound();
            }
            return View(advCPP);
        }

        // POST: AdvCPPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,projectname,description,studentname")] AdvCPP advCPP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advCPP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advCPP);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdvCPPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvCPP advCPP = db.AdvCPPs.Find(id);
            if (advCPP == null)
            {
                return HttpNotFound();
            }
            return View(advCPP);
        }

        // POST: AdvCPPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvCPP advCPP = db.AdvCPPs.Find(id);
            db.AdvCPPs.Remove(advCPP);
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
