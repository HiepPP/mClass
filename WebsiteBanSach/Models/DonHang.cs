using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            this.ChiTietDonHangs = new List<ChiTietDonHang>();
        }

        public int MaDonHang { get; set; }
        public Nullable<System.DateTime> NgayGiao { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public string DaThanhToan { get; set; }
        public Nullable<int> TinhTrangGiaoHang { get; set; }
        public Nullable<int> MaKH { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}
