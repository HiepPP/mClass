using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class ThamGia
    {
        public int MaSach { get; set; }
        public int MaTacGia { get; set; }
        public string VaiTro { get; set; }
        public string ViTri { get; set; }
        public virtual Sach Sach { get; set; }
        public virtual TacGia TacGia { get; set; }
    }
}
