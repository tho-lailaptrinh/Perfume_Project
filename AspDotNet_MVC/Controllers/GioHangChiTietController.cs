using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_MVC.Controllers
{
    public class GioHangChiTietController : Controller
    {
        private IGioHangChiTietRepo _repo;
        private MyDbContext _context;

        public GioHangChiTietController(IGioHangChiTietRepo repo, MyDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        public  IActionResult Index()
        {
            var data = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(HttpContext.Session.GetString("IdUser"))).ToList();
            return View(data);
        }
        public IActionResult GHCT()
        {
            return View();
        }

        // thanh toán tất cả sp có trong giỏ hàng
        public IActionResult ThanhToan()
        {
            var LoginUser = HttpContext.Session.GetString("IdUser");
            if (LoginUser == null)
            {
                return Content("Đã đăng nhập đâu anh bạn");
            }
            // lấy ra tất cả sp có trong ghct của user đó
            var lstCart = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(LoginUser)).ToList();

            for (int i = 0; i < lstCart.Count; i++)
            {
                var product = _context.SanPhams.Find(lstCart[i].IdSP);

                if(product != null)
                {
                    if (lstCart[i].Amount > product.SoLuong)
                    {
                        return Content("Số lượng khong đủ");
                    }
                }
            }

            // tạo hoá đơn khi thanh toán
            var _hD = new HoaDon()
            {
                Id = Guid.NewGuid(),
                NgayTao = DateTime.Now,
                TrangThai =2,
                IdUser = Guid.Parse(LoginUser)
                
            };
            _context.HoaDons.Add(_hD);
            _context.SaveChanges();
            // tạo hdct tương ứng với hoá đơn
            foreach (var item in lstCart)
            {
                var product = _context.SanPhams.Find(item.IdSP);

                if (product != null)
                {
                  
                    var _hDCT = new HoaDonChiTiet() 
                    {
                       
                        Id = Guid.NewGuid(),
                        TotalAmount = item.Money,
                        Quantity = item.Amount,
                        IdHD = _hD.Id,
                        IdSP = item.IdSP,
                    };

                    _context.HoaDonChiTiets.Add(_hDCT);
                    product.SoLuong = product.SoLuong - item.Amount;
                    _context.SanPhams.Update(product);
                    _context.SaveChanges();
                }
            }
            _context.GioHangChiTiets.RemoveRange(lstCart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Buy(Guid id)
        {
            var getSession = HttpContext.Session.GetString("IdUser");
            if (getSession == null)
            {
                return Content("Bạn chưa đăng nhập!");
            }
            else
            {
                // lấy tất cả các sản phẩm có trong giỏ hàng của user đã đăng nhập
                //var giohanglst = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(getSession)).ToList();

                // lấy sp đó có trong giỏ hàng đó ra
                var spbuy = _context.GioHangChiTiets.Where(x => x.IdSP == id && x.IdGH == Guid.Parse(getSession)).ToList();
                // tạo hoá đơn mới
                if (spbuy != null)
                {
                    var hd = new HoaDon()
                    {
                        Id = Guid.NewGuid(),
                        NgayTao = DateTime.Now,
                        TrangThai = 1,
                        IdUser = Guid.Parse(getSession),
                    };
                    _context.HoaDons.Add(hd);
                    // thêm các mục giỏ hàng vào hoá đơn chi tiết
                    foreach (var item in spbuy)
                    {
                        // tìm ra sp đó
                        var product = _context.SanPhams.Find(item.IdSP);
                        product.SoLuong -= item.Amount;
                        // tạo hdct tương ứng với hd
                        var hdct = new HoaDonChiTiet()
                        {
                            Id = Guid.NewGuid(),
                            TotalAmount = product.Gia,
                            Quantity = item.Amount,
                            IdSP = item.IdSP,
                            IdHD = hd.Id,
                        };
                        _context.HoaDonChiTiets.Add(hdct);
                    }
                }
              
                _context.GioHangChiTiets.RemoveRange(spbuy);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
         public IActionResult ViewHoaDon()
        {
            return RedirectToAction("Index", "HoaDon");
        }

        public IActionResult Delete(Guid id)
        {
            var obj = _context.GioHangChiTiets.Find(id);

            _context.GioHangChiTiets.Remove(obj);
            _context.SaveChanges();

            return RedirectToAction("Index", "GioHangChiTiet");
        }
    }
}
