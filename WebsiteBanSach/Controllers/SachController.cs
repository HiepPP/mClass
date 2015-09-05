using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
    public class SachController : Controller
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        // GET: Sach
//Sach moi
        public PartialViewResult SachMoiPartial()
        {
            var book = db.Saches.Take(3).ToList();
            return PartialView(book);
        }
        public ViewResult XemChiTiet(int id=0)
        {
            var book = db.Saches.Find(id);
            //var sach = db.Saches.FirstOrDefault(x => x.MaSach == id);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Bo sung hang da xem vao cookie
            var views = Request.Cookies["views"];
            if (views == null)
            {
                views = new HttpCookie("views");
            }
            // Bổ sung sách đã xem vào cookie
            views.Values[id.ToString()] = id.ToString();
            // Đặt thời hạn tồn tại cho cookie
            views.Expires = DateTime.Now.AddDays(1);
            // Lưu cookie
            Response.Cookies.Add(views);
            var keys = views.Values.AllKeys.Select(x => int.Parse(x)).ToList();
            ViewBag.Views = db.Saches.Where(x => keys.Contains(x.MaSach));

            return View(book);
        }
    }
}