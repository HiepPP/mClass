using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models
{
    public partial class ChuDe
    {
        public ChuDe()
        {
            this.Saches = new List<Sach>();
        }

        public int MaChuDe { get; set; }
        public string TenChuDe { get; set; }
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
