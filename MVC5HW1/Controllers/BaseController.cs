using MVC5HW1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW1.Controllers
{
    public abstract class BaseController : Controller
    {
        //※定義為abstract抽象類別時，該類別一定要被繼承才能使用

        protected 客戶資料Entities db = new 客戶資料Entities();

        //當使用者輸入不存在的Action時的預設導引
        protected override void HandleUnknownAction(string actionName)
        {
            //導引到Index這個Action
            this.RedirectToAction("Index").ExecuteResult(this.ControllerContext);
        }   
    }
}