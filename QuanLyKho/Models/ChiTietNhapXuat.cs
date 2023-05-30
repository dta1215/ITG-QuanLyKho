using System.ComponentModel.DataAnnotations;

namespace QuanLyKho.Models
{
    public class ChiTietNhapXuat
    {
        [Key]
        public int Id { get; set; }
        public string so_phieu { get; set; }
        public DateTime ngay_lap_phieu { get; set; }
        public string ma_vt { get; set; }
        public string ten_vt { get; set; }
        public string dvt { get; set; }
        public float? sl_nhap { get; set; }
        public float? sl_xuat { get; set; }
    }
}
