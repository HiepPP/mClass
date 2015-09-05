using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class TacGia
    {
        public TacGia()
        {
            this.ThamGias = new List<ThamGia>();
        }

        public int MaTacGia { get; set; }
        public string TenTacGia { get; set; }
        public string DiaChi { get; set; }
        public string TieuSu { get; set; }
        public string DienThoai { get; set; }
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
