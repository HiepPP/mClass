using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
    public class NhaXuatBanController : Controller
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        // GET: NhaXuatBan
        public PartialViewResult NhaXuatBanPartial()
        {
            var nxb = db.NhaXuatBans.Take(10).ToList().OrderBy(x => x.TenNXB);
            return PartialView(nxb);
        }
        //public ViewResult HienThiSachNXB(int id)
        //{
        //    var booknxb = db.Saches.Where(x => x.MaNXB == id).ToList();
        //    return View(booknxb);
        //}
        public ViewResult TatCaNXB()
        {
            var nxb = db.NhaXuatBans.ToList();
            return View(nxb);
        }
    }
}