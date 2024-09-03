using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.EFModels;

namespace WebApplication3.Controllers
{
    public class GuestBooksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: GuestBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Confirm()
        {
            return View();
        }

        // POST: GuestBooks/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,CellPhone,Message,CreateTime")] GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                db.GuestBooks.Add(guestBook);
                guestBook.CreateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Confirm");
            }

            return View(guestBook);
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
