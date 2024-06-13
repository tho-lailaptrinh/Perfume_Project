using API.IRepositorys;
using Infrastructure.Models.Data;
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
        private readonly MyDbContext _context;
        public GioHangChiTietController(IGioHangChiTietRepo repo, MyDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        [HttpGet("get_ghct")]
        public IActionResult GetAllGHCT()
        {
            return Ok(_repo.GetGioHangCT());
        }
        //public IActionResult GetGioHangUser()
        //{
        //    var data = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(HttpContext.Session.GetString("IdUser"))).ToList();
        //    return Ok(data);
        //}
        //[HttpPost("create_ghct")]
        //public IActionResult CreateGHCt(GioHangChiTiet ghct)
        //{
        //    try
        //    {
        //        return Ok(_repo.CreateGioHangCT(ghct));
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
        //[HttpPost("get_ghct")]
        //public IActionResult UpdateGHCT()
        //{
        //    return Ok(_repo.GetGioHangCT());
        //}
        //[HttpPost("get_ghct")]
        //public IActionResult DeleteGHCT()
        //{
        //    return Ok(_repo.GetGioHangCT());
        //}

    }
}
