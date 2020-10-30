using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5_2.Context;
using WebApplication5_2.Models;

namespace WebApplication5_2.Controllers
{
    public class sandwichesController : Controller
    {
        private fData2 db = new fData2();

        // GET: sandwiches
        public ActionResult Index()
        {
            return View(db.sandwichs.ToList());
        }

        // GET: sandwiches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sandwich sandwich = db.sandwichs.Find(id);
            if (sandwich == null)
            {
                return HttpNotFound();
            }
            return View(sandwich);
        }

        // GET: sandwiches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sandwiches/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fid,fname,fNumber,fDesc,fPrice")] sandwich sandwich)
        {
            if (ModelState.IsValid)
            {
                db.sandwichs.Add(sandwich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sandwich);
        }

        // GET: sandwiches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sandwich sandwich = db.sandwichs.Find(id);
            if (sandwich == null)
            {
                return HttpNotFound();
            }
            return View(sandwich);
        }

        // POST: sandwiches/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fid,fname,fNumber,fDesc,fPrice")] sandwich sandwich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sandwich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sandwich);
        }

        // GET: sandwiches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sandwich sandwich = db.sandwichs.Find(id);
            if (sandwich == null)
            {
                return HttpNotFound();
            }
            return View(sandwich);
        }

        // POST: sandwiches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sandwich sandwich = db.sandwichs.Find(id);
            db.sandwichs.Remove(sandwich);
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
