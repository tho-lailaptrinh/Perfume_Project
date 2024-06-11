namespace Infrastructure.Models.Entitis
{
    public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public int? Quantity { get; set; }
        public Guid? IdSP { get; set; }
        public virtual SanPham? SanPhams { get; set; }
        public Guid? IdHD { get; set; }
        public virtual HoaDon? HoaDons { get; set; }

       
    }
}
