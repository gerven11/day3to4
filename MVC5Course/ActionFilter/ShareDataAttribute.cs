using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// 建立ActionFilter
/// 1. 建立一個ActionFilter 資料夾
/// 2. 建立共用的Attributes 類別(Class)，要繼承 ActionFilterAttribute
/// 3.在controller上套用
/// </summary>
namespace MVC5Course.ActionFilter
{
    public class ShareDataAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";
            base.OnActionExecuting(filterContext);
        }
    }
}