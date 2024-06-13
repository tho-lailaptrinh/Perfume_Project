
using Infrastructure.Models.Entitis;

namespace API.IRepositorys
{
    public interface IGioHangChiTietRepo
    {
        IEnumerable<GioHangChiTiet> GetGioHangCT();
        Task<GioHangChiTiet> CreateGioHangCT(GioHangChiTiet g);
        Task<GioHangChiTiet> UpdateGioHangCTr(Guid id, GioHangChiTiet g);
        Task<GioHangChiTiet> DeleteGioHangCT(Guid id);
    }
}
