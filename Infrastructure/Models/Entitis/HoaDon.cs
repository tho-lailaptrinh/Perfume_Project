namespace Infrastructure.Models.Entitis
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public DateTime? NgayTao { get; set; } // ngày bán
        public decimal? TotalAmount { get; set; }
        public int? TrangThai { get; set; } // trạng thái
        public Guid? IdUser { get; set; }
        public virtual User? Users { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
        public Guid? IdTT { get; set; }
        public virtual ThanhToan? ThanhToans { get; set; }

        public Guid? IdDVVC { get; set; }
        public virtual Shipping? Shippings { get; set; }


    }
}
