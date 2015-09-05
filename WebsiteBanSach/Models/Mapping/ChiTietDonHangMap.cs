using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class ChiTietDonHangMap : EntityTypeConfiguration<ChiTietDonHang>
    {
        public ChiTietDonHangMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MaDonHang, t.MaSach });

            // Properties
            this.Property(t => t.MaDonHang)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MaSach)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ChiTietDonHang");
            this.Property(t => t.MaDonHang).HasColumnName("MaDonHang");
            this.Property(t => t.MaSach).HasColumnName("MaSach");
            this.Property(t => t.SoLuong).HasColumnName("SoLuong");
            this.Property(t => t.DonGia).HasColumnName("DonGia");

            // Relationships
            this.HasRequired(t => t.DonHang)
                .WithMany(t => t.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDonHang);
            this.HasRequired(t => t.Sach)
                .WithMany(t => t.ChiTietDonHangs)
                .HasForeignKey(d => d.MaSach);

        }
    }
}
