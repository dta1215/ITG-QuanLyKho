using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKho.Models
{
    public class ChiTietNhapXuat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Số phiếu")]
        public string so_phieu { get; set; }
        [Required]
        [DisplayName("Ngày lập phiếu")]
        public DateTime ngay_lap_phieu { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Mã vật tư")]
        public string ma_vt { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Têm vật tư")]
        public string ten_vt { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Đơn vị tính")]
        public string dvt { get; set; }
        [DisplayName("Số lượng nhập")]
        public float? sl_nhap { get; set; }
        [DisplayName("Số lượng xuất")]
        public float? sl_xuat { get; set; }
    }
}
