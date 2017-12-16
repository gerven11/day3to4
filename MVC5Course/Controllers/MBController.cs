using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBBatchUpdateVM
    {
        public int ProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    }

    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            var data = repo.Get取得所有尚未刪除的商品資料Top10();

            ViewData.Model = data;

            //ViewData["PageTitle"] = "商品清單";
            ViewBag.PageTitle = "商品清單";
            
            return View();
        }
        /// <summary>
        /// 自定義HandleError 訊息用法
        /// 1.[HandleError(ExceptionType = typeof(DbEntityValidationException),View ="Error_DbEntityValidationException")]
        /// </summary>
        /// <param name="batch"></param>
        /// <returns></returns>
        [HttpPost]
        [HandleError(ExceptionType = typeof(DbEntityValidationException),View ="Error_DbEntityValidationException")]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(MBBatchUpdateVM[] batch)
        {
            if (ModelState.IsValid)
            {
                foreach(var item in batch)
                {
                    var ProductData = repo.Find(item.ProductId);
                    ProductData.Price = item.Price;
                    ProductData.ProductId = item.ProductId;
                    ProductData.Stock = item.Stock;
                }
                try
                {
                    repo.UnitOfWork.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
                

                return RedirectToAction("Index");
            }

            var data = repo.Get取得所有尚未刪除的商品資料Top10();
            ViewData.Model = data;
            ViewBag.PageTitle = "商品清單";
            
            return View();
        }
    }
}