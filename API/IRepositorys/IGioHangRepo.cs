
using Infrastructure.Models.Entitis;

namespace API.IRepositorys
{
    public interface IGioHangRepo
    {
        IEnumerable<GioHang> GetGioHang();
        GioHang CreateGioHang(GioHang g);
        GioHang UpdateGioHang(Guid id, GioHang g);
        GioHang DeleteGioHang(Guid id);
    }
}
