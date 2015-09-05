using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebsiteBanSach.Models.Mapping;

namespace WebsiteBanSach.Models
{
    public partial class QuanLyBanSachContext : DbContext
    {
        static QuanLyBanSachContext()
        {
            Database.SetInitializer<QuanLyBanSachContext>(null);
        }

        public QuanLyBanSachContext()
            : base("Name=QuanLyBanSachContext")
        {
        }

        public DbSet<aaaa> aaaas { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<ddddd> ddddds { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<dsadsa> dsadsas { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tabletest> tabletests { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<ThamGia> ThamGias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new aaaaMap());
            modelBuilder.Configurations.Add(new ChiTietDonHangMap());
            modelBuilder.Configurations.Add(new ChuDeMap());
            modelBuilder.Configurations.Add(new dddddMap());
            modelBuilder.Configurations.Add(new DonHangMap());
            modelBuilder.Configurations.Add(new dsadsaMap());
            modelBuilder.Configurations.Add(new KhachHangMap());
            modelBuilder.Configurations.Add(new NhaXuatBanMap());
            modelBuilder.Configurations.Add(new SachMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new tabletestMap());
            modelBuilder.Configurations.Add(new TacGiaMap());
            modelBuilder.Configurations.Add(new ThamGiaMap());
        }
    }
}
