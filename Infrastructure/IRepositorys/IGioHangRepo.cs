﻿
using Infrastructure.Models.Entitis;

namespace Infrastructure.IRepositorys
{
    public interface IGioHangRepo
    {
        Task<IEnumerable<GioHang>> GetGioHang();
        Task<GioHang> CreateGioHang(GioHang g);
        Task<GioHang> UpdateGioHang(Guid id, GioHang g);
        Task<GioHang> DeleteGioHang(Guid id);
    }
}
