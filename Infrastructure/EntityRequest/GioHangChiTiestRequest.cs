﻿using Infrastructure.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityRequest
{
    public class GioHangChiTiestRequest
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public decimal? Money { get; set; }
        public Guid? IdSP { get; set; }
        public virtual SanPham? SanPhams { get; set; }
        public Guid? IdGH { get; set; }
        public virtual GioHang? GioHangs { get; set; }
    }
}
