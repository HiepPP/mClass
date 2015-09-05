using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class SachMap : EntityTypeConfiguration<Sach>
    {
        public SachMap()
        {
            // Primary Key
            this.HasKey(t => t.MaSach);

            // Properties
            this.Property(t => t.TenSach)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Sach");
            this.Property(t => t.MaSach).HasColumnName("MaSach");
            this.Property(t => t.TenSach).HasColumnName("TenSach");
            this.Property(t => t.GiaBan).HasColumnName("GiaBan");
            this.Property(t => t.MoTa).HasColumnName("MoTa");
            this.Property(t => t.NgayCapNhat).HasColumnName("NgayCapNhat");
            this.Property(t => t.AnhBia).HasColumnName("AnhBia");
            this.Property(t => t.SoLuongTon).HasColumnName("SoLuongTon");
            this.Property(t => t.MaChuDe).HasColumnName("MaChuDe");
            this.Property(t => t.MaNXB).HasColumnName("MaNXB");
            this.Property(t => t.Moi).HasColumnName("Moi");

            // Relationships
            this.HasOptional(t => t.ChuDe)
                .WithMany(t => t.Saches)
                .HasForeignKey(d => d.MaChuDe);
            this.HasOptional(t => t.NhaXuatBan)
                .WithMany(t => t.Saches)
                .HasForeignKey(d => d.MaNXB);

        }
    }
}
