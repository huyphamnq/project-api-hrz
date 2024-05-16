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

        //[HttpGet]
        //public async Task<IActionResult> GetAllKhachHang()
        //{
        //    List<KhachHang> khachHangs = null;
        //    khachHangs = await _context.Set<KhachHang>().FromSqlInterpolated($"Exec spAPI_GetAll_KhachHang").ToListAsync();
        //    return Ok(khachHangs);
        //}

        [HttpGet]
        public async Task<IActionResult> GetKhachHang(string MaKH)
        {
            var parameters = new[]
            {
                new SqlParameter("@MaKH", MaKH)
            };

            var khachHang = await _context.khachHangs.FromSqlRaw("EXEC spAPI_Get_KhachHang_ByMaKH @MaKH", parameters).ToListAsync();
            if (khachHang.Count == null)
            {
                return NotFound("Khách hàng không tồn tại:");
            }
            return Ok(khachHang);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateKhachHang(string MaKH, string HoTen, string DiaChi, string DienThoai)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC spAPI_Update_KhachHang_ByMaKH {MaKH}, {HoTen}, {DiaChi}, {DienThoai}"
                );
                return Ok("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
