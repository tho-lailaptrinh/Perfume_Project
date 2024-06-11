using Infrastructure.Models.Entitis;

namespace Infrastructure.IRepositorys
{
    public interface IDanhMucSPRepo
    {
        Task<List<DanhMucSanPham>> GetAll();
        Task<bool> CreateDM(DanhMucSanPham dmsp);
        Task<bool> UpdateDM(Guid id,DanhMucSanPham dmsp);
        Task<bool> DeleteDM(Guid id);

    }
}
