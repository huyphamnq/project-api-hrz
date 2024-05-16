using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLDatPhongKhachSan.Data;

namespace QLDatPhongKhachSan.Controllers
{
    public class QLDatPhongKhachSanDBContext : DbContext
    {
        public QLDatPhongKhachSanDBContext(DbContextOptions<QLDatPhongKhachSanDBContext> options) : base(options)
        {

        }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<Phong> phongs { get; set; }
        public DbSet<DatPhong> datPhongs { get; set; }
        public DbSet<HoaDon> hoaDons{ get; set; }
    }
}
