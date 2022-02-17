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
    public class sorumluController : Controller
    {
        private TVContainer db = new TVContainer();

        // GET: sorumlu
        public ActionResult Index()
        {
            var sorumlu = db.sorumlu.Include(s => s.yayin);
            return View(sorumlu.ToList());
        }

        // GET: sorumlu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sorumlu sorumlu = db.sorumlu.Find(id);
            if (sorumlu == null)
            {
                return HttpNotFound();
            }
            return View(sorumlu);
        }

        // GET: sorumlu/Create
        public ActionResult Create()
        {
            ViewBag.yayinid = new SelectList(db.yayin, "yayinid", "yayinadi");
            return View();
        }

        // POST: sorumlu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sorumluid,adsoyad,gorevi,maas,gorevsayisi,yayinid")] sorumlu sorumlu)
        {
            if (ModelState.IsValid)
            {
                db.sorumlu.Add(sorumlu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.yayinid = new SelectList(db.yayin, "yayinid", "yayinadi", sorumlu.yayinid);
            return View(sorumlu);
        }

        // GET: sorumlu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sorumlu sorumlu = db.sorumlu.Find(id);
            if (sorumlu == null)
            {
                return HttpNotFound();
            }
            ViewBag.yayinid = new SelectList(db.yayin, "yayinid", "yayinadi", sorumlu.yayinid);
            return View(sorumlu);
        }

        // POST: sorumlu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sorumluid,adsoyad,gorevi,maas,gorevsayisi,yayinid")] sorumlu sorumlu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sorumlu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.yayinid = new SelectList(db.yayin, "yayinid", "yayinadi", sorumlu.yayinid);
            return View(sorumlu);
        }

        // GET: sorumlu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sorumlu sorumlu = db.sorumlu.Find(id);
            if (sorumlu == null)
            {
                return HttpNotFound();
            }
            return View(sorumlu);
        }

        // POST: sorumlu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sorumlu sorumlu = db.sorumlu.Find(id);
            db.sorumlu.Remove(sorumlu);
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
