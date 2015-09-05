using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebsiteBanSach.Models;
namespace WebsiteBanSach.Controllers
{
    public class NguoiDungController : Controller
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                //Chèn dữ liệu vào bảng khách hàng
                db.KhachHangs.Add(kh);
                //Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(KhachHang u)
        {
            if (ModelState.IsValid)
            {
                //string tk = f["txtTaiKhoan"].ToString();
                //string mk = f.Get("txtMatKhau").ToString();
                var kh = db.KhachHangs.Where(x => x.TaiKhoan.Equals(u.TaiKhoan) && x.MatKhau.Equals(u.MatKhau)).SingleOrDefault(); 
                if (kh != null)
                {
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    Session["TenKHa"] = kh.HoTen.ToString();
                    //FormsAuthentication.SetAuthCookie(kh.HoTen, true);
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            }
                return RedirectToAction("DangNhap", "NguoiDung");
        }
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
        }
    }
}