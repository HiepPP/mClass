using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class TacGiaMap : EntityTypeConfiguration<TacGia>
    {
        public TacGiaMap()
        {
            // Primary Key
            this.HasKey(t => t.MaTacGia);

            // Properties
            this.Property(t => t.TenTacGia)
                .HasMaxLength(50);

            this.Property(t => t.DiaChi)
                .HasMaxLength(100);

            this.Property(t => t.DienThoai)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TacGia");
            this.Property(t => t.MaTacGia).HasColumnName("MaTacGia");
            this.Property(t => t.TenTacGia).HasColumnName("TenTacGia");
            this.Property(t => t.DiaChi).HasColumnName("DiaChi");
            this.Property(t => t.TieuSu).HasColumnName("TieuSu");
            this.Property(t => t.DienThoai).HasColumnName("DienThoai");
        }
    }
}
