using Infrastructure.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityRequest
{
    public class GioHangRequest
    {
        public Guid Id { get; set; }
        public Guid? IdUser { get; set; }
        public virtual User? Users { get; set; }
        public virtual ICollection<GioHangChiTiet>? GioHangChiTiets { get; set; }
    }
}
