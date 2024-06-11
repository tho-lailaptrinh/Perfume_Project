

using Infrastructure.IRepositorys;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;

namespace Infrastructure.Repositorys
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
