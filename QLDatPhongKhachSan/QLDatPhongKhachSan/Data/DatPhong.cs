using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace QLDatPhongKhachSan.Data
{
    public class DatPhong
    {
        [Key]
        public string MaDatPhong { get; set; }
        [Required]
        public string MaKH { get; set; }
        [Required]
        public string MaPhong { get; set; }
        [Required]
        public string MaNV { get; set; }
        [Required]
        public DateTime NgayDat { get; set; }
        public DateTime NgayTra { get; set; }
        public int SoTienPhaiTra { get; set; }
        public bool DaThanhToan { get; set; }
    }
}
