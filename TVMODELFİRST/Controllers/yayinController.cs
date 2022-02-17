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
    public class yayinController : Controller
    {
        private TVContainer db = new TVContainer();

        // GET: yayin
        public ActionResult Index()
        {
            var yayin = db.yayin.Include(y => y.kanal);
            return View(yayin.ToList());
        }

        // GET: yayin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yayin yayin = db.yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            return View(yayin);
        }

        // GET: yayin/Create
        public ActionResult Create()
        {
            ViewBag.kanalid = new SelectList(db.kanal, "kanalid", "kanaladi");
            return View();
        }

        // POST: yayin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yayinid,yayinadi,yayintarihi,reyting,kanalid")] yayin yayin)
        {
            if (ModelState.IsValid)
            {
                db.yayin.Add(yayin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kanalid = new SelectList(db.kanal, "kanalid", "kanaladi", yayin.kanalid);
            return View(yayin);
        }

        // GET: yayin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yayin yayin = db.yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            ViewBag.kanalid = new SelectList(db.kanal, "kanalid", "kanaladi", yayin.kanalid);
            return View(yayin);
        }

        // POST: yayin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "yayinid,yayinadi,yayintarihi,reyting,kanalid")] yayin yayin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yayin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kanalid = new SelectList(db.kanal, "kanalid", "kanaladi", yayin.kanalid);
            return View(yayin);
        }

        // GET: yayin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yayin yayin = db.yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            return View(yayin);
        }

        // POST: yayin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yayin yayin = db.yayin.Find(id);
            db.yayin.Remove(yayin);
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
