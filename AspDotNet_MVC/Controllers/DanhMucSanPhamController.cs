
using AspDotNet_MVC.IService;
using AspDotNet_MVC.Service;
using Infrastructure.EntityRequest;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        private IDanhMucSPService _service;
        public DanhMucSanPhamController(IDanhMucSPService service)
        {
            _service = service;
        }
        public  IActionResult Index()
        {
            var data =  _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DanhMucSanPhamRequest dmsp)
        {
            _service.CreateDMSP(dmsp);
            return RedirectToAction("Index");
        }

    }
}
