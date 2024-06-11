using API.IRepositorys;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepo _repo;
        public SanPhamController(ISanPhamRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get_sp")]
        public IActionResult GetAllSP()
        {
            return Ok(_repo.GetSanPhams());
        }
        [HttpPost("create_sp")]
        public IActionResult CreateSanPham(SanPham sanPham)
        {
            try
            {
                return Ok(_repo.CreateSP(sanPham));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPut("update_sp")]
        public IActionResult UpdateSanPham(Guid id, SanPham sanPham)
        {
            try
            {
                return Ok(_repo.UpdateSP(id, sanPham));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpDelete("update_sp")]
        public IActionResult DeleteSanPham(Guid id)
        {
            try
            {
                return Ok(_repo.DeleteSP(id));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpGet("GetById_sp")]
        public IActionResult GetByIdSanPham(Guid id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

    }
}
