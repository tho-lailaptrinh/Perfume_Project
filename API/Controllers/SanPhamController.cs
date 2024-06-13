using API.IRepositorys;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepo _repo;
        private readonly MyDbContext _context;
        public SanPhamController(ISanPhamRepo repo, MyDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        [HttpGet("get_sp")]
        public IActionResult GetAllSP()
        {
            return Ok(_repo.GetSanPhams());
        }
        [HttpPost("create_sp")]
        public IActionResult CreateSanPham(SanPhamRequest sanPham)
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
        [HttpDelete("delete_sp")]
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
        [HttpGet("getbyid_sp")]
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

        //public IActionResult AddToCart(Guid id, int amount)
        //{
        //    // lấy tất cả sản phẩm có trong giỏ hàng user vừa đăng nhập
        //    var userCart = _context.GioHangChiTiets.Where(x => x.IdGH == Guid.Parse(login)).ToList();
        //    bool checkSelected = false;
        //    Guid idGHCT = Guid.Empty;
        //    foreach (var item in userCart)
        //    {
        //        if (item.IdSP == id)
        //        {
        //            // nếu id sp trong giỏ hàng đã trùng với id được chọn
        //            checkSelected = true;
        //            idGHCT = item.Id; // lấy Id GHCT để tý nữa update
        //            break;
        //        }
        //    }
        //    if (!checkSelected) // nếu sp chưa được chọn
        //    {
        //        var checkSL = _context.SanPhams.FirstOrDefault(x => x.Id == id);
        //        if (amount < 0 && checkSL.SoLuong < amount)
        //        {
        //            return Content("Rất tiếc, chúng tôi không đủ lượng hàng bạn cần rồi!!!");
        //        }
        //        else
        //        {
        //            // tạo mới 1 GHCT ứng với sản phẩm
        //            GioHangChiTiet ghct = new GioHangChiTiet()
        //            {
        //                Id = Guid.NewGuid(),
        //                IdSP = id,
        //                SanPhams = _context.SanPhams.Find(id),
        //                IdGH = Guid.Parse(login),
        //                Amount = amount,
        //                Money = checkSL.Gia * amount,
        //            };
        //            _context.GioHangChiTiets.Add(ghct);
        //            _context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else // nếu sản phẩm được chọn
        //    {
        //        var getSP = _context.SanPhams.FirstOrDefault(x => x.Id == id);
        //        if (getSP.SoLuong < amount)
        //        {
        //            return Content("Rất tiếc, chúng tôi không đủ lượng hàng bạn cần rồi!!!");
        //        }
        //        else
        //        {
        //            var updateGHCT = _context.GioHangChiTiets.Find(idGHCT);
        //            updateGHCT.Amount = updateGHCT.Amount + amount;
        //            updateGHCT.Money = getSP.Gia * updateGHCT.Amount;
        //            _context.GioHangChiTiets.Update(updateGHCT);
        //            _context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //}

    }
}
