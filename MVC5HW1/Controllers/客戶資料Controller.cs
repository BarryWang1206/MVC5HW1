using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HW1.Models;

namespace MVC5HW1.Controllers
{
    public class 客戶資料Controller : BaseController
    {
        客戶資料Repository repo;

        public 客戶資料Controller()
        {
            repo = RepositoryHelper.Get客戶資料Repository();
        }

        // GET: 客戶資料
        public ActionResult Index()
        {
            var data = repo.All();
            return View(data);
        }

        //關鍵字查詢
        public ActionResult Search(string keyword)
        {
            var data = repo.KeyWordSearch(keyword);

            return View("Index", data);
        }


        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 data = repo.Find(id.Value);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            var data = 客戶資料;

            if (ModelState.IsValid)
            {    
                repo.Add(data);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 data = repo.Find(id.Value);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: 客戶資料/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            var data = 客戶資料;

            if (ModelState.IsValid)
            {
                var db = repo.UnitOfWork.Context;

                data.是否已刪除 = false;

                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 data = repo.Find(id.Value);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 data = repo.Find(id);
            repo.Delete(data);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
