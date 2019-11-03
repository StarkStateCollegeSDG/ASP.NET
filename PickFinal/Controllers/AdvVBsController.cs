using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PickFinal;

namespace PickFinal.Controllers
{
    public class AdvVBsController : Controller
    {
        private FinalEntities db = new FinalEntities();

        // GET: AdvVBs
        [Authorize]
        public ActionResult Index()
        {
            //return View(db.AdvVBs.ToList());
            return View(db.AdvVBs.OrderBy(d => d.projectname).Where(d => d.studentname == null).ToList());
        }
        [Authorize]
        public ActionResult ViewTopics()
        {
            //return View(db.AdvVBs.ToList());
            return View(db.AdvVBs.OrderBy(d => d.studentname).Where(d => d.studentname != null).ToList());
        }
        [Authorize(Users = "smorosko@gmail.com")]
        public ActionResult MasterView()
        {
            return View(db.AdvVBs.OrderBy(a => a.projectname).ToList());
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
