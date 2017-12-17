﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.ActionFilter;

namespace MVC5Course.Controllers
{
    [LocalOnly]
    public class HomeController : Controller
    {
        [ShareData]
        public ActionResult Index()
        {
            return View();
        }

        [ShareData]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult VT()
        //{

        //    return PartialView();
        //}

        public ActionResult MetroIndex()
        {

            return View();
        }
    }
}