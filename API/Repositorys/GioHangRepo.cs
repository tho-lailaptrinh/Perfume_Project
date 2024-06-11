

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
        public async Task<IEnumerable<GioHang>> GetGioHang()
        {
            var result = await _context.GioHangs.ToListAsync();
            return result;
        }
        public Task<GioHang> CreateGioHang(GioHang g)
        {
            throw new NotImplementedException();
        }

        public Task<GioHang> DeleteGioHang(Guid id)
        {
            throw new NotImplementedException();
        }

     

        public Task<GioHang> UpdateGioHang(Guid id, GioHang g)
        {
            throw new NotImplementedException();
        }
    }
}
