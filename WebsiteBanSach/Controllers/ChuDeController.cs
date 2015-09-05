using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
    public class ChuDeController : Controller
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        // GET: ChuDe
        public PartialViewResult ChuDePartial()
        {
            var chude = db.ChuDes.Take(5).ToList();
            return PartialView(chude);
        }
        //Tìm sách theo chủ đề
        public ViewResult SachTheoChuDe(int id = 0)
        {
            //Kiểm tra chủ đề có tồn tại hay không
            var cd = db.ChuDes.Find(id);
            if(cd ==null)
            {
                Response.StatusCode = 404;
            }
            var listsach = db.Saches.Where(x=>x.MaChuDe==id).OrderBy(x=>x.GiaBan).ToList();
            if (listsach.Count==0)
	        {
		        ViewBag.Sach="Không có sách nào thuộc chủ đề này";
	        }
            return View(listsach);
        }
        //Hiển thị các chủ dề
        public ViewResult DanhMucChuDe()
        {
            var chude = db.ChuDes.ToList();
            return View(chude);
        }
    }
}