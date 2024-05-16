using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLDatPhongKhachSan.Data;

namespace QLDatPhongKhachSan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly QLDatPhongKhachSanDBContext _context;

        public KhachHangController(QLDatPhongKhachSanDBContext ctx)
        {
            _context = ctx;
        }

        // code o day

        [HttpGet]
        public async Task<IActionResult> GetAllKhachHang()
        {
            List<KhachHang> khachHangs = null;
            khachHangs = await _context.Set<KhachHang>().FromSqlInterpolated($"Exec spAPI_GetAll_KhachHang").ToListAsync();
            return Ok(khachHangs);
        }

        [HttpGet("{MaKH}")]
        public async Task<IActionResult> GetKhachHangByMaKH(string MaKH)
        {
            try
            {
                var khachHangs = await _context.Set<KhachHang>().FromSqlInterpolated($"Exec spAPI_Get_KhachHang_ByMaKH {MaKH}").ToListAsync();
                if (khachHangs == null || khachHangs.Count == 0)
                {
                    return NotFound("Khách hàng không tồn tại");
                }
                return Ok(khachHangs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi: " + ex.Message);
            }
        }


        [HttpPut("{MaKH}")]
        public async Task<IActionResult> UpdateKhachHang(string MaKH, string HoTen, string DiaChi, string DienThoai)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"Exec spAPI_Update_KhachHang_ByMaKH {MaKH}, {HoTen}, {DiaChi}, {DienThoai}");
                return Ok("Sửa thông tin khách hàng thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi sửa thông tin khách hàng: " + ex.Message);
            }
        }

    }
}
