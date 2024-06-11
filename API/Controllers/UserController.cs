using API.IRepositorys;
using Infrastructure.Models.Entitis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get_user")]
        public IActionResult GetAllUser() {
            return Ok(_repo.GetAllUser());
        }

        [HttpGet("getbyid_user")]
        public IActionResult GetAllUser(Guid id)
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
        [HttpPost("create_user")]
        public IActionResult CreateUser(User user)
        {
            try
            {
                return Ok(_repo.CreateUser(user));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPut("update_user")]
        public IActionResult UpdateUser(Guid id, User user)
        {
            try
            {
                return Ok(_repo.UpdateUser(id, user));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpDelete("update_user")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                return Ok(_repo.DeleteUser(id));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        
        
    }
}
