using Infrastructure.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityRequest
{
    public class HoaDonRequest
    {
        public Guid Id { get; set; }
        public DateTime? NgayTao { get; set; } // ngày bán
        public int? TrangThai { get; set; } // trạng thái
        public Guid? IdUser { get; set; }
        public virtual User? Users { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }

    }
}
