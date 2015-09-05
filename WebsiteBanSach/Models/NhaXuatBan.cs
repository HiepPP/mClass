using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class NhaXuatBan
    {
        public NhaXuatBan()
        {
            this.Saches = new List<Sach>();
        }

        public int MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
