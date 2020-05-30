using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using PlurasightLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlurasightLogin.Controllers
{
    public class StudentController : Controller
    {
        private readonly Model1 db = new Model1();

        

        // GET: Student
        public ActionResult TrangChu()
        {

            return View();
        }
        public ActionResult QuanLiDangKi()
        {
            return View();
        }
        public ActionResult DichVuHoTro()
        {
            return View();
        }
        public ActionResult GiatLa()
        {
            return View();
        }
        public ActionResult PhongTuHoc()
        {
            ViewBag.Username = User.Identity.GetUserName();
            return View();
        }
        public ActionResult CanBo()
        {
            return View();
        }
        public ActionResult ThanhToan()
        {
            return View();
        }
        public ActionResult GhiChu()
        {
            return View();
        }
        public ActionResult TaiKhoan()
        {
            return View();
        }
    }
}