using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class tabletestMap : EntityTypeConfiguration<tabletest>
    {
        public tabletestMap()
        {
            // Primary Key
            this.HasKey(t => t.jhagsd);

            // Properties
            this.Property(t => t.jhagsd)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.asdad)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("tabletest");
            this.Property(t => t.jhagsd).HasColumnName("jhagsd");
            this.Property(t => t.asdad).HasColumnName("asdad");
        }
    }
}
