using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.EFModels;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Controllers
{
    public class GBController : Controller
    {
        // GET: GB
        public ActionResult Index()
        {
            var data = GetData();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestBookCreateVm model)
        {
            if (ModelState.IsValid) return View(model);

            //CREATE RECORD
            var entity = new GuestBook()
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                CellPhone = model.CellPhone,
                CreateTime = DateTime.Now,
            };

            try
            {
                var db = new AppDbContext();
                db.GuestBooks.Add(entity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
            
        }

        private List<GuestBookVm> GetData()
        {
            return new AppDbContext().GuestBooks
                .Select(gb=>new GuestBookVm()
                {
                    Id = gb.Id,
                    Name = gb.Name,
                    Email= gb.Email,
                    CreateTime = gb.CreateTime,
                })
                .OrderByDescending(gb=>gb.CreateTime)
                .ToList();
        }
    }
}