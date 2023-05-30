namespace QuanLyKho.Services.DTO
{
    public class IndexViewModel
    {
        public SearchModel SearchModel { get; set; }
        public IEnumerable<QuanLyKho.Models.ChiTietNhapXuat> ChiTietNhapXuats { get; set; }
    }
}
