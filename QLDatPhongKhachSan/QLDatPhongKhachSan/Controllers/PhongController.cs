using Microsoft.AspNetCore.Mvc;

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
    }
}
