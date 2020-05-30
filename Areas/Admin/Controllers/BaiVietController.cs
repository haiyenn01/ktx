using PlurasightLogin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlurasightLogin.Areas.Admin.Controllers
{
    public class BaiVietController : Controller
    {
        private readonly Model1 db = new Model1();
        // GET: Admin/BaiViet
        public ActionResult Index()
        {
            var list = db.BaiViets.ToList();
            return View(list);
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(BaiViet model, HttpPostedFileBase file)
        {
            if(file != null)
            {
                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string extension = Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/assets/images/baiviet/" + _filename));
                if(extension.ToLower() == ".jpg" || extension.ToLower() == ".png")
                {
                    if(file.ContentLength <= 10000000)
                    {
                        model.Anh = _filename;
                        file.SaveAs(path);
                    }
                    else
                    {
                        ModelState.AddModelError("", "File anh vuot qua kich thuoc luu tru!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Dinh dang khong hop le!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Ban can nhap file anh!");
                return View();
            }
            model.NgayTao = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
            db.BaiViets.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index","BaiViet");
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            
            var checkdelete = db.BaiViets.FirstOrDefault(x => x.Id == Id);
            if(checkdelete != null)
            {
                string path = Request.MapPath("~/Areas/Admin/assets/images/baiviet/" + checkdelete.Anh);
                if(System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    db.BaiViets.Remove(checkdelete);
                    db.SaveChanges();
                    return Json(new JMessage() { Error = false, Title = "Xoa thanh cong!"}, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new JMessage() { Error = true, Title = "File anh khong ton tai!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new JMessage() { Error = true, Title = "Khong tim thay ban ghi!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
    public class JMessage
    {
        public string Title { get; set; }
        public bool Error { get; set; }
    }
}