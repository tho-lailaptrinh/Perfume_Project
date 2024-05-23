using AspDotNet_MVC.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class HoaDonController : Controller
    {
        // controller hoá đơn, nhưng chúng ta sẽ xử lý hoá đơn chi tiết ở trong này ok
        private MyDbContext _context;
        private HoaDonChiTietController _hdct;
        public HoaDonController()
        {
             _context = new MyDbContext();
            _hdct = new HoaDonChiTietController();
        }
        public IActionResult Index()
        {
            var getSession = HttpContext.Session.GetString("IdUser");
            if (getSession == null)
            {
                return Content("Bạn đã đăng nhập đâu");
            }
            var getlst = _context.HoaDons.Where(x => x.IdUser == Guid.Parse(getSession)).ToList();
            return View(getlst);
        }
        public IActionResult Detail(Guid id)
        {
            return RedirectToAction("Index", "HoaDonChiTiet", new {id = id});
        }
      
    }
}
