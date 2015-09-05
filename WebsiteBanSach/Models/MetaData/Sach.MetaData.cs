using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
//using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
// using 2 thu vien thiet ke class metadata


namespace WebsiteBanSach.Models
{
    [MetadataType(typeof(SachMetaData))]
	public partial class Sach
	{
		//internal: chi dung chi class nay, sealed: ko cho ke thua
		internal sealed class SachMetaData
        {
            [Display(Name = "Mã Sách")]
            //[HiddenInput(DisplayValue = false)]
            public int MaSach { get; set; }
            [Display(Name = "Tên Sách")]
            public string TenSach { get; set; }
            [Display(Name = "Giá Bán")]
            public Nullable<decimal> GiaBan { get; set; }
            [Display(Name = "Mô Tả")]
            public string MoTa { get; set; }
            [Display(Name = "Ngày Cập Nhật")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode= true)]
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
            public string AnhBia { get; set; }
            public Nullable<int> SoLuongTon { get; set; }
            public Nullable<int> MaChuDe { get; set; }
            public Nullable<int> MaNXB { get; set; }
            public Nullable<int> Moi { get; set; }
        }
	}
}