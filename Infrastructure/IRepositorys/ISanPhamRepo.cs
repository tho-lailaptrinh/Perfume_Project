
using Infrastructure.Models.Entitis;

namespace Infrastructure.IRepositorys
{
    public interface ISanPhamRepo
    {
        IEnumerable<SanPham> GetSanPhams();
        SanPham GetById(Guid id);
        SanPham CreateSP(SanPham sp);
        SanPham UpdateSP(Guid id,SanPham sp);
        SanPham DeleteSP(Guid id);  
    }
}
