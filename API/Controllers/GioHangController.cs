using API.IRepositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly IGioHangRepo _repo;
        public GioHangController(IGioHangRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("get_giohang")]
        public IActionResult GetAllGioHang()
        {
            return Ok(_repo.GetGioHang());
        }
    }
}
