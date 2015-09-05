using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanSach.Models;
using PagedList;
using PagedList.Mvc;
using WebsiteBanSach.Models.MutiModel;
namespace WebsiteBanSach.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        // GET: Home
        public ActionResult Index(int? page)
        {
            //Tao bien' so san pham tren trang
            int pageSize = 9;
            //Tao bien so trang
            int pageNumber = (page ?? 1);
            var book = db.Saches.ToList().Where(x => x.Moi == 1).OrderBy(x=>x.GiaBan).ToPagedList(pageNumber, pageSize);
            return View(book);
        }
        [HttpPost]
        public ViewResult KetQuaTimKiem(int? page, FormCollection f)
        {
            string TuKhoa = f["txtSearch"].ToString();
            List<Sach> kq = db.Saches.Where(x => x.TenSach.Contains(TuKhoa)).ToList();
            // Phan trang tim kiem
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (kq.Count == 0)
            {
                ViewBag.Tim = "Không tìm thấy sách nào";
                return View();
            }
            return View(kq.OrderBy(x=>x.TenSach).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Search()
        {
            var data = Request["term"];
            var search = db.Saches.Where(x => x.TenSach.Contains(data)).Select(x => x.TenSach).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListSach(int mNXB=0 ,int mChuDe=0 )
        {
            if (mNXB != 0)
            {
                var model = db.Saches.Where(x => x.MaNXB == mNXB).ToList();
                db.SaveChanges();
                return View(model);
            }
            else if (mChuDe != 0)
            {
                var model = db.Saches.Where(x => x.MaChuDe == mChuDe).ToList();
                return View(model);
            }
            else
            {
                @ViewBag.Sach = "Không tìm thấy sách";
            }
            return View();
        }
        public ActionResult ShowAll(int? kCD, int? kNXB)
        {
            if (kCD == 0)
            {
                var model = db.ChuDes.ToList().OrderBy(x=>x.TenChuDe);
                var list = from a in model
                           select new ShowAllModel
                           {
                               MaChuDe = a.MaChuDe,
                               TenChuDe = a.TenChuDe,
                               MaNXB = 0,
                           };
                return View(list);
            }
            else if(kNXB == 0)
            {
                var model = db.NhaXuatBans.ToList().OrderBy(x => x.TenNXB);
                var list = from a in model
                           select new ShowAllModel
                           {
                               TenNXB = a.TenNXB,
                               MaNXB = a.MaNXB,
                               MaChuDe = 0,
                           };
                return View(list);
            }
            else
            {
                Response.StatusCode = 404;
            }
            return View();
        }
        //public ActionResult ShowChuDe()
        //{
        //    var list = db.ChuDes;
        //    var model = from a in list
        //                select new ChudeModel
        //                {
        //                    MaChuDe = a.MaChuDe,
        //                    TenChuDe = a.TenChuDe
        //                };
        //    return Json(model,JsonRequestBehavior.AllowGet);
        //}
    }
}