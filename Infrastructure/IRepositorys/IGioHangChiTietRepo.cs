
using Infrastructure.Models.Entitis;

namespace Infrastructure.IRepositorys
{
    public interface IGioHangChiTietRepo
    {
        Task<IEnumerable<GioHangChiTiet>> GetGioHangCT();
        Task<GioHangChiTiet> CreateGioHangCT(GioHangChiTiet g);
        Task<GioHangChiTiet> UpdateGioHangCTr(Guid id, GioHangChiTiet g);
        Task<GioHangChiTiet> DeleteGioHangCT(Guid id);
    }
}
