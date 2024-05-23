using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;

namespace AspDotNet_MVC.Repositorys
{
    public class HoaDonChiTietRepo : IHoaDonChiTietRepo
    {
        private MyDbContext _context;
        public HoaDonChiTietRepo()
        {
            _context = new MyDbContext();
        }
        public List<HoaDonChiTiet> GetAllHoaDonChiTiet()
        {
            var getLst = _context.HoaDonChiTiets.ToList();  
            return getLst;
        }
    }
}
