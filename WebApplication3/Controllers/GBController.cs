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
                Exception ex2 = ex;
                while (ex2.InnerException != null)
                {
                    ex2= ex2.InnerException;
                }
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
            
        }

        public ActionResult Create2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create2(GuestBookCreateVm model, HttpPostedFileBase FileName)
        {
            //將FileName存檔，如果有上傳的話
            string path = Server.MapPath("/Uploads"); //取得 uploads 真實的完整路徑
            string newFileName = SaveFile(FileName, path); //若沒上傳，回傳null

            //將檔名傳給 model.FileName
            model.FileName = newFileName;

            //建立一筆紀錄
            DoCreate2(model);

            return RedirectToAction("Index");
        }

        private void DoCreate2(GuestBookCreateVm model)
        {
            //利用Dapper
            //todo
        }

        private string SaveFile(HttpPostedFileBase file, string path)
        {
            //如果沒有檔案或是長度為0回傳null
            if (file == null || file.ContentLength == 0) return null;

            //驗證副檔名看類型是不是允許的

            //驗證圖片尺寸(如果是圖片的話)

            //驗證檔案大小

            //取得檔名(必須更名???)
            string ext = System.IO.Path.GetExtension(file.FileName); // 取得".jpg"
                                                                     //88888888-4444-4444-4444-11111
                                                                     //8888888844444444444411111
            string newFileName = Guid.NewGuid().ToString("N") + ext; //新的檔名

            //組合出完整的路徑
            string fullPath = System.IO.Path.Combine(path, newFileName);

            //存檔
            file.SaveAs(fullPath);

            //回傳最後的檔名
            return newFileName;
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