using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanSach.Models;
namespace WebsiteBanSach.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        #region Giohang
        // Khởi tạo giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> LstGioHang = Session["GioHang"] as List<GioHang>;
            if (LstGioHang == null)
            {
                LstGioHang = new List<GioHang>();
                Session["GioHang"] = LstGioHang;
            }
            return LstGioHang;
        }
        // Thêm giỏ hàng
        public ActionResult ThemGioHang(int _MaSach, string url)
        {
            Sach sach = db.Saches.Find(_MaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lấy session giỏ hàng
            List<GioHang> LstGioHang = LayGioHang();
            GioHang sp = LstGioHang.Find(x=>x._MaSach==_MaSach);
            if(sp == null)
            {
                return RedirectToAction("DangNhap","NguoiDung");
                sp = new GioHang(_MaSach);
                // add sp moi them vao list
                LstGioHang.Add(sp);
                return Redirect(url);
            }
            else
            {
                sp.SoLuong++;
                return Redirect(url);
            }
        }
        public ActionResult CapNhatGioHang(int iMaSach, FormCollection f)
        {
            // Kiểm tra sp
            Sach sp = db.Saches.Find(iMaSach);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> LstGioHang = LayGioHang();
            GioHang sanpham = LstGioHang.SingleOrDefault(x=>x._MaSach==iMaSach);
            if(sanpham != null)
            {
                sanpham.SoLuong = int.Parse(f["txtSoLuong"]);
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(int iMaSach)
        {
            Sach sp = db.Saches.Find(iMaSach);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> LstGioHang = LayGioHang();
            GioHang sanpham = LstGioHang.SingleOrDefault(x => x._MaSach == iMaSach);
            if (sanpham != null)
            {
                LstGioHang.RemoveAll(x => x._MaSach == iMaSach);
            }
            if(LstGioHang.Count==0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if(Session["GioHang"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> LstGioHang = LayGioHang();
            return View(LstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        private int TongSoLuong()
        {
            int Tong = 0;
            List<GioHang> LstGioHang = Session["GioHang"] as List<GioHang>;
            if(LstGioHang != null)
            {
                Tong = LstGioHang.Sum(x => x.SoLuong);
            }
            return Tong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> LstGioHang = Session["GioHang"] as List<GioHang>;
            if(LstGioHang != null)
            {
                dTongTien = LstGioHang.Sum(x => x.ThanhTien);
            }
            return dTongTien;
        }
        public PartialViewResult GioHangPartial()
        {
            if(TongSoLuong()==0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> LstGioHang = LayGioHang();
            return View(LstGioHang);
        }
        #endregion
        #region Dathang
        // Chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng nhập,chưa đăng nhập thì chuyển sang login page
            if(Session["TaiKhoan"]==null|| Session["TaiKhoan"].ToString() =="")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //Kiem tra gio hang
            if (Session["TaiKhoan"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Them don hang
            DonHang donhang = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            donhang.MaKH = kh.MaKH;
            donhang.NgayDat = DateTime.Now;
            //Them don hang
            db.DonHangs.Add(donhang);
            db.SaveChanges();
            //Them chi tiet don hang
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = donhang.MaDonHang;
                ctDH.MaSach = item._MaSach;
                ctDH.SoLuong = item.SoLuong;
                ctDH.DonGia = (decimal)item.DonGia;
                db.ChiTietDonHangs.Add(ctDH);
            }
            return RedirectToAction("Index", "Home");
        }
        
        #endregion
    }
}