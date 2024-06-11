
namespace Infrastructure.Models.Entitis
{
    public class DanhGiaSP
    {
        public Guid Id { get; set; }
        public string? Mota { get; set; }
        public Guid? IdSP { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
