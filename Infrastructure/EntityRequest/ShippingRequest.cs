using Infrastructure.Models.Entitis;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityRequest
{
    public class ShippingRequest
    {
        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
    }
}
