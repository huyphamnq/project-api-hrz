using System.ComponentModel.DataAnnotations;

namespace QLDatPhongKhachSan.Data
{
    public class HoaDon
    {
        [Key]
        public int MaHoaDon {  get; set; }
        [Required]
        public string MaDatPhong { get; set; }
        [Required]
        public string MaKH{ get; set; }
        [Required]
        public DateTime NgayXuat { get; set; }
        public int TongTien { get; set; }
    }
}
