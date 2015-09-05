using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class KhachHangMap : EntityTypeConfiguration<KhachHang>
    {
        public KhachHangMap()
        {
            // Primary Key
            this.HasKey(t => t.MaKH);

            // Properties
            this.Property(t => t.HoTen)
                .HasMaxLength(50);

            this.Property(t => t.GioiTinh)
                .HasMaxLength(3);

            this.Property(t => t.DienThoai)
                .HasMaxLength(50);

            this.Property(t => t.TaiKhoan)
                .HasMaxLength(50);

            this.Property(t => t.MatKhau)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.DiaChi)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("KhachHang");
            this.Property(t => t.MaKH).HasColumnName("MaKH");
            this.Property(t => t.HoTen).HasColumnName("HoTen");
            this.Property(t => t.NgaySinh).HasColumnName("NgaySinh");
            this.Property(t => t.GioiTinh).HasColumnName("GioiTinh");
            this.Property(t => t.DienThoai).HasColumnName("DienThoai");
            this.Property(t => t.TaiKhoan).HasColumnName("TaiKhoan");
            this.Property(t => t.MatKhau).HasColumnName("MatKhau");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.DiaChi).HasColumnName("DiaChi");
        }
    }
}
