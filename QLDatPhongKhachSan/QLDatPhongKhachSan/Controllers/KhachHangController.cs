using Microsoft.AspNetCore.Mvc;
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
    }
}
