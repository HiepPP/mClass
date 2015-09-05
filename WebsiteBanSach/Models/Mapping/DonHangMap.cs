using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class DonHangMap : EntityTypeConfiguration<DonHang>
    {
        public DonHangMap()
        {
            // Primary Key
            this.HasKey(t => t.MaDonHang);

            // Properties
            this.Property(t => t.DaThanhToan)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DonHang");
            this.Property(t => t.MaDonHang).HasColumnName("MaDonHang");
            this.Property(t => t.NgayGiao).HasColumnName("NgayGiao");
            this.Property(t => t.NgayDat).HasColumnName("NgayDat");
            this.Property(t => t.DaThanhToan).HasColumnName("DaThanhToan");
            this.Property(t => t.TinhTrangGiaoHang).HasColumnName("TinhTrangGiaoHang");
            this.Property(t => t.MaKH).HasColumnName("MaKH");

            // Relationships
            this.HasOptional(t => t.KhachHang)
                .WithMany(t => t.DonHangs)
                .HasForeignKey(d => d.MaKH);

        }
    }
}
