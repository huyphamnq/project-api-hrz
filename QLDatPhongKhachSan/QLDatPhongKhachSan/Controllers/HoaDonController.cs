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
            List<HoaDon> hoaDons = null;
            hoaDons = await _context.Set<HoaDon>().FromSqlInterpolated($"Exec spAPI_Get_HoaDon_ByMAKH {MaKH}").ToListAsync();
            return Ok(hoaDons);
        }
    }
}
