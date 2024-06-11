using Infrastructure.EntityRequest;

namespace AspDotNet_MVC.IService
{
    public interface IDanhMucSPService
    {
        List<DanhMucSanPhamRequest> GetAll();
        DanhMucSanPhamRequest GetById(Guid id);
        bool CreateDMSP(DanhMucSanPhamRequest dmsp);
        bool UpdateDMSP( DanhMucSanPhamRequest dmsp);
        bool DeleteDMSP(Guid id);
    }
}
