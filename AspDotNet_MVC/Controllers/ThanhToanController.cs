using AspDotNet_MVC.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class ThanhToanController : Controller
    {
        private MyDbContext _context;
        public ThanhToanController()
        {
                _context = new MyDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
