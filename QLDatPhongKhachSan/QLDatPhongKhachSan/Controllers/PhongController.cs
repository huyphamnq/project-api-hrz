using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLDatPhongKhachSan.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLDatPhongKhachSan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly QLDatPhongKhachSanDBContext _context;

        public PhongController(QLDatPhongKhachSanDBContext ctx)
        {
            _context = ctx;
        }

        //code o day
        [HttpPost]
        public async Task<IActionResult> AddPhong(string MaPhong, string TenPhong, string LoaiPhong, int GiaTienMotNgay, string TinhTrang)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"Exec spAPI_AddRoom {MaPhong}, {TenPhong}, {LoaiPhong}, {GiaTienMotNgay}, {TinhTrang}"
                );
                return Ok("Đặt phòng thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi đặt phòng: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhong(string MaPhong)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"Exec spAPI_DeleteRoom {MaPhong}"
                );
                return Ok("Xóa phòng thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi xóa phòng: " + ex.Message);
            }
        }
    }
}
