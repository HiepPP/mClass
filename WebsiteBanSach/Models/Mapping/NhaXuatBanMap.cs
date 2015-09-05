using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class NhaXuatBanMap : EntityTypeConfiguration<NhaXuatBan>
    {
        public NhaXuatBanMap()
        {
            // Primary Key
            this.HasKey(t => t.MaNXB);

            // Properties
            this.Property(t => t.TenNXB)
                .HasMaxLength(50);

            this.Property(t => t.DiaChi)
                .HasMaxLength(100);

            this.Property(t => t.DienThoai)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("NhaXuatBan");
            this.Property(t => t.MaNXB).HasColumnName("MaNXB");
            this.Property(t => t.TenNXB).HasColumnName("TenNXB");
            this.Property(t => t.DiaChi).HasColumnName("DiaChi");
            this.Property(t => t.DienThoai).HasColumnName("DienThoai");
        }
    }
}
