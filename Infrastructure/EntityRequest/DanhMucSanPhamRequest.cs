using Infrastructure.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityRequest
{
    public class DanhMucSanPhamRequest
    {
        public Guid Id { get; set; }
        public string? TenDM { get; set; }
        public string? MoTa { get; set; }
        public virtual ICollection<SanPham>? SanPhams { get; set; }
    }
}
