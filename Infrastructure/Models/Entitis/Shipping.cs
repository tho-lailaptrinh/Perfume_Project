namespace Infrastructure.Models.Entitis
{
    public class Shipping
    {
        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public virtual ICollection<HoaDon>? HoaDons { get; set; }

    }
}
