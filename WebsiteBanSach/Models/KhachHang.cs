using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            this.DonHangs = new List<DonHang>();
        }

        public int MaKH { get; set; }
        public string HoTen { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
