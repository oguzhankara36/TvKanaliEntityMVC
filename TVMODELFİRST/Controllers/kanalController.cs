using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TVMODELFİRST;

namespace TVMODELFİRST.Controllers
{
    public class kanalController : Controller
    {
        private TVContainer db = new TVContainer();

        // GET: kanal
        public ActionResult Index()
        {
            return View(db.kanal.ToList());
        }

        // GET: kanal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kanal kanal = db.kanal.Find(id);
            if (kanal == null)
            {
                return HttpNotFound();
            }
            return View(kanal);
        }

        // GET: kanal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kanal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kanalid,kanaladi,ciro,adres,reyting")] kanal kanal)
        {
            if (ModelState.IsValid)
            {
                db.kanal.Add(kanal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kanal);
        }

        // GET: kanal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kanal kanal = db.kanal.Find(id);
            if (kanal == null)
            {
                return HttpNotFound();
            }
            return View(kanal);
        }

        // POST: kanal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kanalid,kanaladi,ciro,adres,reyting")] kanal kanal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kanal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kanal);
        }

        // GET: kanal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kanal kanal = db.kanal.Find(id);
            if (kanal == null)
            {
                return HttpNotFound();
            }
            return View(kanal);
        }

        // POST: kanal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kanal kanal = db.kanal.Find(id);
            db.kanal.Remove(kanal);
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
