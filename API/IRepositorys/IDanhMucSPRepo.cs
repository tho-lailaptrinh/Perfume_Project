using Infrastructure.EntityRequest;
using Infrastructure.Models.Entitis;

namespace API.IRepositorys
{
    public interface IDanhMucSPRepo
    {
       List<DanhMucSanPham> GetAll();
       bool CreateDMSP(DanhMucSanPhamRequest dmsp);
       bool UpdateDM(Guid id,DanhMucSanPham dmsp);
       bool DeleteDM(Guid id);

    }
}
