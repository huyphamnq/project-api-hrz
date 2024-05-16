using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLDatPhongKhachSan.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLDatPhongKhachSan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly QLDatPhongKhachSanDBContext _context;

        public HoaDonController(QLDatPhongKhachSanDBContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetHoaDonByMaKH(string MaKH)
        {
            try
            {
                var hoadons = await _context.Set<HoaDon>().FromSqlInterpolated($"Exec spAPI_Get_HoaDon_ByMaKH {MaKH}").ToListAsync();
                if (hoadons == null || hoadons.Count == 0)
                {
                    return NotFound("Chưa có đơn đặt phòng");
                }
                return Ok(hoadons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
