using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanSach.Models
{
    public class GioHang
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public int _MaSach { get; set; }
        public string _TenSach { get; set; }
        public string _HinhAnh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien {
            get { return SoLuong * DonGia; }
        }
        //Hàm tạo lấy tất cả thuộc tính cho giỏ hàng
        public GioHang(int MaSach)
        {
            _MaSach = MaSach;
            Sach sach = db.Saches.Find(MaSach);
            _TenSach = sach.TenSach;
            _HinhAnh = sach.AnhBia;
            DonGia = double.Parse(sach.GiaBan.ToString());
            SoLuong = 1;
        }
    }
}