using Infrastructure.EntityRequest;

namespace AspDotNet_MVC.IService
{
    public interface ISanPhamService
    {
        List<SanPhamRequest> GetAllSP();
        SanPhamRequest GetByIdSP(Guid id);
        bool CreateSP(SanPhamRequest request);
        bool UpdateSP(Guid id, SanPhamRequest request);
        bool DeleteSP(Guid id);
    }
}
