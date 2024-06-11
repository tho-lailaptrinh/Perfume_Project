﻿
using Infrastructure.IRepositorys;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys
{
    public class GioHangChiTietRepo : IGioHangChiTietRepo
    {
        private MyDbContext _context;
        public GioHangChiTietRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GioHangChiTiet>> GetGioHangCT()
        {
            return await _context.GioHangChiTiets.ToListAsync();
            
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
