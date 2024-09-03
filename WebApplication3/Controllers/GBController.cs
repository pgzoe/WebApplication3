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
            return View();
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