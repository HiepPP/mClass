using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class ChiTietDonHang
    {
        public int MaDonHang { get; set; }
        public int MaSach { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public virtual DonHang DonHang { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
