using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class ChuDeMap : EntityTypeConfiguration<ChuDe>
    {
        public ChuDeMap()
        {
            // Primary Key
            this.HasKey(t => t.MaChuDe);

            // Properties
            this.Property(t => t.TenChuDe)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ChuDe");
            this.Property(t => t.MaChuDe).HasColumnName("MaChuDe");
            this.Property(t => t.TenChuDe).HasColumnName("TenChuDe");
        }
    }
}
