using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class Sach
    {
        public Sach()
        {
            this.ChiTietDonHangs = new List<ChiTietDonHang>();
            this.ThamGias = new List<ThamGia>();
        }

        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
        public string MoTa { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
        public string AnhBia { get; set; }
        public Nullable<int> SoLuongTon { get; set; }
        public Nullable<int> MaChuDe { get; set; }
        public Nullable<int> MaNXB { get; set; }
        public Nullable<int> Moi { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ChuDe ChuDe { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
