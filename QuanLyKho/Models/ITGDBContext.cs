using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QuanLyKho.Models
{
    public class ITGDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ChiTietNhapXuat> ChitietNhapxuats { get; set; }

        public ITGDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task SeedData()
        {
            if (!ChitietNhapxuats.Any())
            {
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PN-001",
                    ngay_lap_phieu = new DateTime(2023, 3, 1),
                    ma_vt = "IP13",
                    ten_vt = "Iphone 13",
                    dvt = "Chiec",
                    sl_nhap = 10
                });
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PN-001",
                    ngay_lap_phieu = new DateTime(2023, 3, 1),
                    ma_vt = "IP14",
                    ten_vt = "Iphone 14",
                    dvt = "Chiec",
                    sl_nhap = 20
                });
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PN-002",
                    ngay_lap_phieu = new DateTime(2023, 3, 5),
                    ma_vt = "IP13",
                    ten_vt = "Iphone 13",
                    dvt = "Chiec",
                    sl_nhap = 5
                });
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PN-002",
                    ngay_lap_phieu = new DateTime(2023, 3, 5),
                    ma_vt = "IP14",
                    ten_vt = "Iphone 14",
                    dvt = "Chiec",
                    sl_nhap = 10
                });
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PX-001",
                    ngay_lap_phieu = new DateTime(2023, 3, 15),
                    ma_vt = "IP13",
                    ten_vt = "Iphone 13",
                    dvt = "Chiec",
                    sl_xuat = 5
                });
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PX-001",
                    ngay_lap_phieu = new DateTime(2023, 3, 15),
                    ma_vt = "IP14",
                    ten_vt = "Iphone 14",
                    dvt = "Chiec",
                    sl_xuat = 6
                });
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PX-002",
                    ngay_lap_phieu = new DateTime(2023, 3, 20),
                    ma_vt = "IP13",
                    ten_vt = "Iphone 13",
                    dvt = "Chiec",
                    sl_xuat = 10
                });
                await ChitietNhapxuats.AddAsync(new ChiTietNhapXuat
                {
                    so_phieu = "PX-002",
                    ngay_lap_phieu = new DateTime(2023, 3, 20),
                    ma_vt = "IP14",
                    ten_vt = "Iphone 14",
                    dvt = "Chiec",
                    sl_xuat = 8
                });

                //Lưu lại
                await SaveChangesAsync();
            }
        }
    }
}
