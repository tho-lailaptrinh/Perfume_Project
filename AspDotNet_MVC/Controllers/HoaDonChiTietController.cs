using AspDotNet_MVC.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class HoaDonChiTietController : Controller
    {
        private MyDbContext _context;
        public HoaDonChiTietController()
        {
            _context = new MyDbContext();
        }
        public IActionResult Index(Guid id)
        {
            var lsthdct = _context.HoaDonChiTiets.Where(x => x.IdHD == id).ToList();
            return View(lsthdct);
        }
    }
}
