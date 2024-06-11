using Infrastructure.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityRequest
{
    public class DanhGiaSPRequest
    {
        public Guid Id { get; set; }
        public string? Mota { get; set; }
        public Guid? IdSP { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
