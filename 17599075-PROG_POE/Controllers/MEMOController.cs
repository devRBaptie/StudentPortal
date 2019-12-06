using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _17599075_PROG_POE.Models;

namespace _17599075_PROG_POE.Controllers
{
    public class MEMOController : Controller
    {
        private Db_Entities db = new Db_Entities();

        // GET: MEMO
        public ActionResult Index()
        {
            return View(db.QUIZs.ToList());
        }

        // GET: MEMO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUIZ qUIZ = db.QUIZs.Find(id);
            if (qUIZ == null)
            {
                return HttpNotFound();
            }
            return View(qUIZ);
        }

        // GET: MEMO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MEMO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QUESTION,SOL_A,SOL_B,SOL_C,CORRECT_ANSWER")] QUIZ qUIZ)
        {
            if (ModelState.IsValid)
            {
                db.QUIZs.Add(qUIZ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUIZ);
        }

        // GET: MEMO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUIZ qUIZ = db.QUIZs.Find(id);
            if (qUIZ == null)
            {
                return HttpNotFound();
            }
            return View(qUIZ);
        }

        // POST: MEMO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QUESTION,SOL_A,SOL_B,SOL_C,CORRECT_ANSWER")] QUIZ qUIZ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUIZ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUIZ);
        }

        // GET: MEMO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUIZ qUIZ = db.QUIZs.Find(id);
            if (qUIZ == null)
            {
                return HttpNotFound();
            }
            return View(qUIZ);
        }

        // POST: MEMO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUIZ qUIZ = db.QUIZs.Find(id);
            db.QUIZs.Remove(qUIZ);
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
