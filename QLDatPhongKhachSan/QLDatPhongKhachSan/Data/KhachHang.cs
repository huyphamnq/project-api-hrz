using System.ComponentModel.DataAnnotations;

namespace QLDatPhongKhachSan.Data
{
    public class KhachHang
    {
        [Key]
        public string MaKH {  get; set; }
        [Required]
        public string HoTen {  get; set; }
        public string DiaChi {  get; set; }
        public string DienThoai {  get; set; }
    }
}
