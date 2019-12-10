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
    public class AdvVBsController : Controller
    {
        private StarkStateEntities db = new StarkStateEntities();

        // GET: AdvVBs
        public ActionResult Index()
        {
            return View(db.AdvVBs.ToList());
        }

        // GET: AdvVBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvVB advVB = db.AdvVBs.Find(id);
            if (advVB == null)
            {
                return HttpNotFound();
            }
            return View(advVB);
        }

        // GET: AdvVBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvVBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,projectname,description,studentname")] AdvVB advVB)
        {
            if (ModelState.IsValid)
            {
                db.AdvVBs.Add(advVB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advVB);
        }

        // GET: AdvVBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvVB advVB = db.AdvVBs.Find(id);
            if (advVB == null)
            {
                return HttpNotFound();
            }
            return View(advVB);
        }

        // POST: AdvVBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,projectname,description,studentname")] AdvVB advVB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advVB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advVB);
        }

        // GET: AdvVBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvVB advVB = db.AdvVBs.Find(id);
            if (advVB == null)
            {
                return HttpNotFound();
            }
            return View(advVB);
        }

        // POST: AdvVBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvVB advVB = db.AdvVBs.Find(id);
            db.AdvVBs.Remove(advVB);
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
