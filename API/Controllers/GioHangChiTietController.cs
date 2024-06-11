using API.IRepositorys;
using Infrastructure.Models.Entitis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietController : ControllerBase
    {
        private readonly IGioHangChiTietRepo _repo;
        public GioHangChiTietController(IGioHangChiTietRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get_ghct")]
        public IActionResult GetAllGHCT()
        {
            return Ok(_repo.GetGioHangCT());
        }

        [HttpPost("get_ghct")]
        public IActionResult CreateGHCt(GioHangChiTiet ghct)
        {
            try
            {
                return Ok(_repo.CreateGioHangCT(ghct));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPost("get_ghct")]
        public IActionResult UpdateGHCT()
        {
            return Ok(_repo.GetGioHangCT());
        }
        [HttpPost("get_ghct")]
        public IActionResult DeleteGHCT()
        {
            return Ok(_repo.GetGioHangCT());
        }

    }
}
