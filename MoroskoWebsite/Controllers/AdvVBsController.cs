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
            DoesUserHaveCourse();
            DisplayUserGrades();
            var userID = GetUserID();
            //This linq query gives us only the projects assigned to the user.
            var userProjects = from v in db.AdvVBs
                               where v.AspNetUser_Id == userID
                               select v;

            try
            {
                var adminLogin = from user in db.AspNetUsers
                                 join role in db.AspNetRoles on user.Id equals role.AspNetUserId
                                 where role.Name == "Admin"
                                 select user.Id;
                //Single gives us the single result of the
                //above query as a string value.
                string admin = adminLogin.SingleOrDefault();
                if (admin == userID)
                {
                    //If the admin is logged in
                    //we will show everything.
                    ViewBag.DisplayAdvVB = true;
                    return View(db.AdvVBs.ToList());
                }
            }
            catch (Exception)
            {
                //May need to change logic if more than one
                //administrator is present in database.
                //Possible use a List if this is the case.
            }

            return View(userProjects.ToList());
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
            #region comment for ViewBag.AspNetUser_Id
            //This view bag needs to be named exactly AspNetUser_Id to match the foreign
            //key in the table. This is for a drop down list that will assign the Id
            //from the AspNetUsers table to the data row being created/edited, 
            //however we will display the email and not the actual Id when using 
            //the drop down.
            #endregion
            ViewBag.AspNetUser_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View(advVB);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdvVBs/Create
        public ActionResult Create()
        {
            #region comment for ViewBag.AspNetUser_Id
            //This view bag needs to be named exactly AspNetUser_Id to match the foreign
            //key in the table. This is for a drop down list that will assign the Id
            //from the AspNetUsers table to the data row being created/edited, 
            //however we will display the email and not the actual Id when using 
            //the drop down.
            #endregion
            ViewBag.AspNetUser_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: AdvVBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,projectname,description,studentname,AspNetUser_Id,grade")] AdvVB advVB)
        {
            if (ModelState.IsValid)
            {
                db.AdvVBs.Add(advVB);
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
            ViewBag.AspNetUser_Id = new SelectList(db.AspNetUsers, "Id", "Email");
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
            #region comment for ViewBag.AspNetUser_Id
            //This view bag needs to be named exactly AspNetUser_Id to match the foreign
            //key in the table. This is for a drop down list that will assign the Id
            //from the AspNetUsers table to the data row being created/edited, 
            //however we will display the email and not the actual Id when using 
            //the drop down.
            #endregion
            ViewBag.AspNetUser_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View(advVB);
        }

        // POST: AdvVBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,projectname,description,studentname,AspNetUser_Id,grade")] AdvVB advVB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advVB).State = EntityState.Modified;
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
            ViewBag.AspNetUser_Id = new SelectList(db.AspNetUsers, "Id", "Email");
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

        private string GetUserID()
        {
            return User.Identity.GetUserId();
        }

        private void DisplayUserGrades()
        {
            string userId = GetUserID();
            var courseGrade = from u in db.UserCourses
                              join a in db.AdvVBs on u.aspnetusersId equals a.AspNetUser_Id
                              join c in db.Courses on u.courseId equals c.Id
                              where u.aspnetusersId == userId
                              where c.coursename == "AdvVB"
                              select u.coursegrade;
            ViewBag.AdvVBCourseGrade = courseGrade.FirstOrDefault();

            var finalGrade = from u in db.UserCourses
                             join a in db.AdvVBs on u.aspnetusersId equals a.AspNetUser_Id
                             join c in db.Courses on u.courseId equals c.Id
                             where u.aspnetusersId == userId
                             where c.coursename == "AdvVB"
                             select u.finalgrade;
            ViewBag.AdvVBFinalGrade = finalGrade.FirstOrDefault();
        }

        private void DoesUserHaveCourse()
        {
            string userId = GetUserID();
            var thisCourse = from c in db.Courses
                             where c.coursename == "AdvVB"
                             select c.Id;
            int thisCourseId = Int32.Parse(thisCourse.FirstOrDefault().ToString());
            var shouldDisplayCourse = from u in db.UserCourses
                                      join c in db.Courses on u.courseId equals c.Id
                                      where u.aspnetusersId == userId
                                      where u.courseId == thisCourseId
                                      select u;
            ViewBag.DisplayAdvVB = shouldDisplayCourse.Any();
        }
    }
}
