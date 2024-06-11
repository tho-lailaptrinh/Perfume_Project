using API.IRepositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucSanPhamController : ControllerBase
    {
        IDanhMucSPRepo _repo;
        public DanhMucSanPhamController(IDanhMucSPRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var get = _repo.GetAll();
            return Ok(get);
        }
    }
}
