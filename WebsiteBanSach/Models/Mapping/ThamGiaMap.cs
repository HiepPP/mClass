using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class ThamGiaMap : EntityTypeConfiguration<ThamGia>
    {
        public ThamGiaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MaSach, t.MaTacGia });

            // Properties
            this.Property(t => t.MaSach)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MaTacGia)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.VaiTro)
                .HasMaxLength(50);

            this.Property(t => t.ViTri)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ThamGia");
            this.Property(t => t.MaSach).HasColumnName("MaSach");
            this.Property(t => t.MaTacGia).HasColumnName("MaTacGia");
            this.Property(t => t.VaiTro).HasColumnName("VaiTro");
            this.Property(t => t.ViTri).HasColumnName("ViTri");

            // Relationships
            this.HasRequired(t => t.Sach)
                .WithMany(t => t.ThamGias)
                .HasForeignKey(d => d.MaSach);
            this.HasRequired(t => t.TacGia)
                .WithMany(t => t.ThamGias)
                .HasForeignKey(d => d.MaTacGia);

        }
    }
}
