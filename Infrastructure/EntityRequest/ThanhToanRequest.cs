using Infrastructure.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityRequest
{
    public class ThanhToanRequest
    {
        public Guid Id { get; set; }
        public string? PhuongThuc { get; set; }
        public DateTime? NgayTao { get; set; }
        public decimal? TongTien { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
    }
}
