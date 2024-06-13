using API.IRepositorys;
using Infrastructure.EntityRequest;
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
        [HttpPost("create_dmsp")]
        public IActionResult CreateDMSP(DanhMucSanPhamRequest request)
        {
            var get = _repo.CreateDMSP(request);
            return Ok(get);
        }
    }
}
