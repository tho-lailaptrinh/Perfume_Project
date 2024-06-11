using API.IRepositorys;
using Infrastructure.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly MyDbContext _context;
        public HoaDonController(MyDbContext context)
        {
            _context = context;       
        }
        [HttpGet("get_hd")]
        public IActionResult GetAllHD()
        {
            return Ok(_context.HoaDons.ToList());
        }
    }
}
