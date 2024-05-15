using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLDatPhongKhachSan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatPhongController : ControllerBase
    {
        private readonly QLDatPhongKhachSanDBContext _context;

        public DatPhongController(QLDatPhongKhachSanDBContext ctx)
        {
            _context = ctx;
        }

        //code o day
        [HttpPost]
        public async Task<IActionResult> AddDatPhong(string MaDatPhong, string MaKH, string MaPhong, string MaNV, DateTime NgayDat, DateTime NgayNhanPhong, DateTime NgayTraPhong, bool DaThanhToan)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"Exec spAPI_Add_DatPhong {MaDatPhong}, {MaKH}, {MaPhong}, {MaNV}, {NgayDat}, {NgayNhanPhong}, {NgayTraPhong}, {DaThanhToan}"
                );
                return Ok("Đặt phòng thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi đặt phòng: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDatPhongByMaDP(string MaDatPhong, string MaKH, string MaPhong, string MaNV, DateTime NgayDat, DateTime NgayNhanPhong, DateTime NgayTraPhong, bool DaThanhToan)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"Exec spAPI_Update_DatPhong_ByMaDatPhong {MaDatPhong}, {MaKH}, {MaPhong}, {MaNV}, {NgayDat}, {NgayNhanPhong}, {NgayTraPhong}, {DaThanhToan}"
                );
                return Ok("Đặt lại phòng thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi đặt phòng: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDatPhongByMaKH(string MaKH)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"Exec spAPI_Delete_DatPhong_ByMaKH {MaKH}"
                );
                return Ok("Huỷ đặt phòng thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi huỷ đặt phòng: " + ex.Message);
            }
        }
    }
}
