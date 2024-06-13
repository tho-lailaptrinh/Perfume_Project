

using API.IRepositorys;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorys
{
    public class GioHangRepo : IGioHangRepo
    {
        private MyDbContext _context;
        public GioHangRepo(MyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<GioHang> GetGioHang()
        {
            var result =  _context.GioHangs.ToList();
            return result;
        }
        public GioHang CreateGioHang(GioHang g)
        {
            throw new NotImplementedException();
        }

        public GioHang UpdateGioHang(Guid id, GioHang g)
        {
            throw new NotImplementedException();
        }

        public GioHang DeleteGioHang(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
