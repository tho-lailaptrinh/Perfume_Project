
using AspDotNet_MVC.IService;
using Infrastructure.EntityRequest;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _ser;
        public UserController( IUserService ser)
        {
            _ser = ser;
        }
        public IActionResult Index()
        {
            var data = _ser.GetAllUser();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult CreateUser(UserRequest user)
        {
            //var checkUser = _repo.UserExists(user.UserName);
            //if (checkUser != null)
            //{
            //    ModelState.AddModelError("UserName", "Tên người dùng đã tồn tại!");
            //}
            //if (!ModelState.IsValid)
            //{
            //    // Nếu có lỗi, trả về View "Create" với ModelState để hiển thị thông báo lỗi
            //    return View("Create", user);
            //}
             _ser.CreateUser(user);
            return RedirectToAction("Index");
        }
        public IActionResult Update(Guid id)
        {
            var user =  _ser.GetByIdUser(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(Guid id, UserRequest user)
        {
             _ser.UpdateUser(id,user);   
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
             _ser.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var user = _ser.GetByIdUser(id);
            return View(user);
        }
        //Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var userRequest = new UserRequest();
            userRequest.UserName = username;
            userRequest.Password = password;

            if (_ser.Login(userRequest) == true)
            {
                HttpContext.Session.SetString("IdUser", userRequest.Id.ToString());
                return RedirectToAction("Welcome","User");
            }
            return Content("Đăng nhập thất bại");

            //var users =  _userRepo.GetAllUser();
            //var user = users.FirstOrDefault(p => p.UserName == username && p.Password == password);
            //if (user != null)
            //{
            //    HttpContext.Session.SetString("IdUser", user.Id.ToString());
            //    return RedirectToAction("Welcome","User");
            //}
            //return Content("Đăng nhập thất bại");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IdUser");
            return RedirectToAction("Login","User");
        }

        public IActionResult Welcome()
        {
            ViewBag.Message = HttpContext.Session.GetString("IdUser");
            return View();
        }
    }
}
