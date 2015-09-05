using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class aaaaMap : EntityTypeConfiguration<aaaa>
    {
        public aaaaMap()
        {
            // Primary Key
            this.HasKey(t => t.dsa);

            // Properties
            this.Property(t => t.dsa)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.aaaa1)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("aaaa");
            this.Property(t => t.dsa).HasColumnName("dsa");
            this.Property(t => t.aaaa1).HasColumnName("aaaa");
        }
    }
}
