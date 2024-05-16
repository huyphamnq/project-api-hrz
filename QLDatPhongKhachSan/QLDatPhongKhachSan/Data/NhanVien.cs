using System.ComponentModel.DataAnnotations;

namespace QLDatPhongKhachSan.Data
{
    public class NhanVien
    {
        [Key]
        public string MaNV { get; set; }
        [Required]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public decimal Luong { get; set; }
    }
}
