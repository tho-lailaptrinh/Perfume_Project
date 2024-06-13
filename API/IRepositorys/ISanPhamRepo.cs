
using Infrastructure.EntityRequest;
using Infrastructure.Models.Entitis;

namespace API.IRepositorys
{
    public interface ISanPhamRepo
    {
        List<SanPham> GetSanPhams();
        SanPham GetById(Guid id);
        bool CreateSP(SanPhamRequest sp);
        SanPham UpdateSP(Guid id,SanPham sp);
        SanPham DeleteSP(Guid id);  
    }
}
