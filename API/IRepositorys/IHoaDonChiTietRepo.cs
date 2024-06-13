using Infrastructure.Models.Entitis;

namespace API.IRepositorys
{
    public interface IHoaDonChiTietRepo
    {
        public List<HoaDonChiTiet> GetAllHoaDonChiTiet();
    }
}
