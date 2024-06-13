using API.IRepositorys;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Data;
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
        private readonly MyDbContext _context;
        public UserController(IUserRepo repo, MyDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        [HttpGet("get_user")]
        public IActionResult GetUser() 
        {
            return Ok(_repo.GetAllUser());
        }

        [HttpGet("getbyid_user")]
        public IActionResult GetByIdUser(Guid id)
        {
            try
            {
                return Ok(  _repo.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPost("create_user")]
        public IActionResult Create(UserRequest user)
        {
            try
            {
                return Ok( _repo.CreateUser(user));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPut("update_user")]
        public IActionResult Update(Guid id, User user)
        {
            try
            {
                return Ok( _repo.UpdateUser(id, user));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpDelete("delete_user")]
        public IActionResult Delete(Guid id)
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
        [HttpPost("login")]
        public IActionResult Login(UserRequest user)
        {
            if (user.UserName == null && user.Password == null)
            {
                return BadRequest("không có username and password truyền vào");
            }
            else
            {
                var checkAccout = _context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
                if (checkAccout != null)
                {
                    return Ok();
                }
                return BadRequest("ko có tài khoản này");
            }
        }
        
    }
}
