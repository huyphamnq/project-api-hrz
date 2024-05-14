using System.ComponentModel.DataAnnotations;

namespace QLDatPhongKhachSan.Data
{
    public class Phong
    {
        [Key]
        public string MaPhong { get; set; }
        [Required]
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public int GiaTienMotNgay { get; set; }
        public string TinhTrang { get; set; }
    }
}
