using Microsoft.AspNet.Identity;
using PlurasightLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlurasightLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly Model1 db = new Model1();
        public ActionResult Index()
        {
            var list = db.BaiViets.ToList();
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult UserName()
        {
            ViewBag.Username = User.Identity.GetUserName();
            return PartialView();
        }
            
    }
}