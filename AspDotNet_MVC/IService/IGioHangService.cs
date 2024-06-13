using Infrastructure.EntityRequest;

namespace AspDotNet_MVC.IService
{
    public interface IGioHangService
    {
        List<GioHangRequest> GetAllGioHang();
    }
}
