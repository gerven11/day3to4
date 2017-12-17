using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity;

namespace MVC5Course.Controllers
{
    public class OrderLinesController : Controller
    {
        private FabricsEntities db = new FabricsEntities();
        // GET: OrderLines
        public ActionResult Index(int id)
        {
            var orderLine = db.OrderLine
                .Where(p => p.ProductId == id)
                .Include(o => o.Order).Include(o => o.Product);
            return View(orderLine.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}