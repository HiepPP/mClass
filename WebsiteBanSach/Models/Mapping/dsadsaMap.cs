using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class dsadsaMap : EntityTypeConfiguration<dsadsa>
    {
        public dsadsaMap()
        {
            // Primary Key
            this.HasKey(t => t.dsa);

            // Properties
            this.Property(t => t.dsa)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.dsads)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("dsadsa");
            this.Property(t => t.dsa).HasColumnName("dsa");
            this.Property(t => t.dsads).HasColumnName("dsads");
        }
    }
}
