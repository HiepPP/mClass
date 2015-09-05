using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebsiteBanSach.Models.Mapping
{
    public class dddddMap : EntityTypeConfiguration<ddddd>
    {
        public dddddMap()
        {
            // Primary Key
            this.HasKey(t => t.da);

            // Properties
            this.Property(t => t.d)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("ddddd");
            this.Property(t => t.da).HasColumnName("da");
            this.Property(t => t.d).HasColumnName("d");
        }
    }
}
