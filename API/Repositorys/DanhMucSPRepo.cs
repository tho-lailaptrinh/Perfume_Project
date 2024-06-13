
using API.IRepositorys;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;

namespace API.Repositorys
{
    public class DanhMucSPRepo : IDanhMucSPRepo
    {
        private MyDbContext _context;
        public DanhMucSPRepo()
        {
            _context = new MyDbContext();
        }
        public List<DanhMucSanPham> GetAll()
        {
            var data = _context.DanhMucSanPhams.ToList();
            return data;
        }
        public bool CreateDMSP(DanhMucSanPhamRequest dmsp)
        {
            DanhMucSanPham DanhMuc = new DanhMucSanPham()
            {
                Id = Guid.NewGuid(),
                TenDM = dmsp.TenDM,
                MoTa = dmsp.MoTa,
            };
            _context.Add(DanhMuc);
             _context.SaveChanges();
            return true;
        }

        public bool DeleteDM(Guid id)
        {
            var getId =  _context.DanhMucSanPhams.Find(id);
            if (getId != null)
            {
                _context.Remove(getId);
                 _context.SaveChanges();
                return true;
            }
            return false;
        }
        

        public bool UpdateDM(Guid id, DanhMucSanPham dmsp)
        {
            var getId =  _context.DanhMucSanPhams.Find(id);
            if (getId == null)
            {
                return false;
            }
            getId.TenDM = dmsp.TenDM;
            getId.MoTa = dmsp.MoTa;
            _context.Update(getId);
             _context.SaveChanges();
            return true;
        }
    }
}
