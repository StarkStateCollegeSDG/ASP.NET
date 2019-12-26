using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoroskoWebsite.Models;

namespace MoroskoWebsite.Controllers
{
    public class AdvVBsController : Controller
    {
        private EntitiesDBConn db = new EntitiesDBConn();

        // GET: AdvVBs
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            //This linq query gives us only the projects assigned to the user.
            var result = from v in db.AdvVBs
                         where v.AspNetUser_Id == userID
                         select v;

            var AdminLogin = from user in db.AspNetUsers
                             join role in db.AspNetRoles on user.Id equals role.Id
                             where role.Name == "Admin"
                             select user.Id;
            //Single gives us the single result of the
            //above query as a string value.
            string admin = AdminLogin.Single();
            if (admin == userID)
            {
                //If the admin is logged in
                //we will show everything.
                return View(db.AdvVBs.ToList());
            }
            else
            {
                return View(result.ToList());
            }
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
