using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanSach.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data.Entity;
namespace WebsiteBanSach.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        // GET: QuanLySanPham
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var m = db.Saches.ToList().OrderBy(x=>x.MaSach).ToPagedList(pageNumber, pageSize);
            return View(m);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //Dua du lieu vao dropdown list
            //ViewBag.Moi = new SelectList(db.Saches.SingleOrDefault(x=>x.Moi).ToList(), "MaSach", "Moi");
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(),"MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Sach sach, HttpPostedFileBase fileUpload)
        {
            
            //dua du lieu vao view bag
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB");
            //Kiểm tra file đường ẫn ảnh bìa
            if (fileUpload == null)
            {
                ViewBag.Anh = "Vui lòng chọn hình ảnh cho sách";
                return View();
            }
            //Thêm một cuốn sách mới vào csdl
            if(ModelState.IsValid)
            {
                //Lưu tên của file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sach.AnhBia = fileUpload.FileName;
                db.Saches.Add(sach);
                db.SaveChanges();
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id,HttpPostedFileBase fileUpload,Sach sach)
        {
            var m = db.Saches.Find(id);
            if( m == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe","MaChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB","MaNXB");
            return View(m);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Sach sach)
        {
            //them vao csdl
            if(ModelState.IsValid)
            {
                //cap nhat model
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe", "MaChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB", "MaNXB");
            ViewBag.MaSach = sach.MaSach;
            return RedirectToAction("Index", "QuanLySanPham");
        }
        public ActionResult Details(int id)
        {
            var m = db.Saches.Find(id);
            if (m == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(m);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
             var m = db.Saches.Find(id);
             if (m == null)
             {
                 Response.StatusCode = 404;
                 return null;
             }
             return View(m);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(int id)
        {
            var m = db.Saches.Find(id);
            if (m == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Saches.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}