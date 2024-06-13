
using API.IRepositorys;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorys
{
    public class GioHangChiTietRepo : IGioHangChiTietRepo
    {
        private MyDbContext _context;
        public GioHangChiTietRepo(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GioHangChiTiet> GetGioHangCT()
        {
            return  _context.GioHangChiTiets.ToList();
            
        }
        public Task<GioHangChiTiet> CreateGioHangCT(GioHangChiTiet g)
        {
            throw new NotImplementedException();
        }

        public Task<GioHangChiTiet> DeleteGioHangCT(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<GioHangChiTiet> UpdateGioHangCTr(Guid id, GioHangChiTiet g)
        {
            throw new NotImplementedException();
        }
    }
}
