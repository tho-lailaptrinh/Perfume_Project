﻿namespace AspDotNet_MVC.Models.Entitis
{
    public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Quantity { get; set; }
        public Guid? IdSP { get; set; }
        public virtual SanPham? SanPhams { get; set; }
        public Guid? IdHD { get; set; }
        public virtual HoaDon? HoaDons { get; set; }

        public Guid? IdTT { get; set; }
        public virtual ThanhToan? ThanhToans { get; set; }

        public Guid? IdDVVC { get; set; }
        public virtual Shipping? Shippings { get; set; }
    }
}
