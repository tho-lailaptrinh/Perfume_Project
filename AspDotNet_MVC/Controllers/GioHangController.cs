using AspDotNet_MVC.IService;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class GioHangController : Controller
    {
        private IGioHangService _ser;

        public GioHangController(IGioHangService ser)
        {
            _ser = ser;
        }

        //public IActionResult Index()
        //{
        //    var data =  _ser.GetAllGioHang();
        //    return View(data);
        //}
    }
}
