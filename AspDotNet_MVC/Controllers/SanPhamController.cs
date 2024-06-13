using AspDotNet_MVC.IService;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace AspDotNet_MVC.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPhamService _ser;
        private readonly MyDbContext _context;

        public SanPhamController( ISanPhamService ser, MyDbContext context)
        {
            _ser = ser;
            _context = context; 
        }

        // GET: SanPhams
        public IActionResult Index()
        {
           var getSP = _ser.GetAllSP();
            return View(getSP);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPhamRequest sp, IFormFile imgFile)
        {
            //tạo ra một nơi lưu ảnh
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
            // copy ảnh và tải lên thư mục
            var stream = new FileStream(path, FileMode.Create);
            // copy ảnh được chọn làm stream đó
            imgFile.CopyTo(stream);
            // cập nhật đường dẫn ảnh
            sp.ImgFile = imgFile.FileName;
            _ser.CreateSP(sp);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var getId = _ser.GetByIdSP(id);
            return View(getId);
        }
        [HttpPost]
        public IActionResult Update(Guid id, SanPhamRequest sp)
        {
            _ser.UpdateSP(id, sp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _ser.DeleteSP(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            var getId = _ser.GetByIdSP(id);
            return View(getId);
        }
        public IActionResult Thuonghieu()
        {
            var data = _ser.GetAllSP();
            return View(data);
        }

        public IActionResult AddToCart(Guid id, int amount) // id ở đây là id sản phẩm và amount: số lượng sp
        {
            var login = HttpContext.Session.GetString("IdUser");
            if (login == null)
            {
                return Content("Đã đăng nhập đâu anh bạn!");
            }
            else
            {
               var userCart = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(login)).ToList();
                bool checkSelected = false;
                Guid idGHCT = Guid.Empty;
                foreach (var item in userCart)
                {
                    if (item.IdSP == id)
                    {
                        checkSelected = true;
                        idGHCT = item.Id; // lấy Id GHCT để tý nữa update
                        break;
                    }
                }
                if (!checkSelected) // nếu sp chưa được chọn
                {
                    var checkSL = _context.SanPhams.FirstOrDefault(x => x.Id == id);
                    if (amount < 0 && checkSL.SoLuong < amount)
                    {
                        return Content("Rất tiếc, chúng tôi không đủ lượng hàng bạn cần rồi!!!");
                    }
                    else
                    {
                        //tạo mới 1 GHCT ứng với sản phẩm
                       GioHangChiTiet ghct = new GioHangChiTiet()
                       {
                           Id = Guid.NewGuid(),
                           IdSP = id,
                           SanPhams = _context.SanPhams.Find(id),
                           IdGH = Guid.Parse(login),
                           Amount = amount,
                           Money = checkSL.Gia * amount,
                       };
                        _context.GioHangChiTiets.Add(ghct);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else // nếu sản phẩm được chọn
                {
                    var getSP = _context.SanPhams.FirstOrDefault(x => x.Id == id);
                    if (getSP.SoLuong < amount)
                    {
                        return Content("Rất tiếc, chúng tôi không đủ lượng hàng bạn cần rồi!!!");
                    }
                    else
                    {
                        var updateGHCT = _context.GioHangChiTiets.Find(idGHCT);
                        updateGHCT.Amount = updateGHCT.Amount + amount;
                        updateGHCT.Money = getSP.Gia * updateGHCT.Amount;
                        _context.GioHangChiTiets.Update(updateGHCT);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
        }
    }
}
