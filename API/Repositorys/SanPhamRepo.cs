
using API.IRepositorys;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace API.Repositorys
{
    public class SanPhamRepo : ISanPhamRepo
    {
        private readonly MyDbContext _context;
        public SanPhamRepo(MyDbContext context)
        {
            _context = context;
        }
        public List<SanPham> GetSanPhams()
        {
            var result = _context.SanPhams.ToList();
            return result;
        }
        public bool CreateSP(SanPhamRequest sp)
        {
            SanPham sanpham = new SanPham()
            {
                Id = Guid.NewGuid(),
                Ten = sp.Ten,
                Gia = sp.Gia,
                SoLuong = sp.SoLuong,
                ImgFile = sp.ImgFile,
                IdDMSP = sp.IdDMSP,
            };
            _context.SanPhams.Add(sanpham);
             _context.SaveChanges();
            return true;
        }
        public SanPham UpdateSP(Guid id, SanPham sp)
        {
            var updateSP =  _context.SanPhams.FirstOrDefault(x => x.Id == id);
            if (updateSP == null)
            {
                // Xử lý khi sản phẩm không tồn tại, ví dụ: throw exception hoặc trả về một kết quả tùy ý
                return null;
            }
            //var updateSP = await _context.SanPhams.FirstOrDefaultAsync(x=>x.Id == id);
            updateSP.Ten = sp.Ten;
            updateSP.Gia = sp.Gia;
            updateSP.SoLuong = sp.SoLuong;
            updateSP.IdDMSP = sp.IdDMSP; 
            _context.SanPhams.Update(sp);
             _context.SaveChanges();
            return updateSP;
        }
        public SanPham DeleteSP(Guid id)
        {  
        
            var deleteSP =  _context.SanPhams.Find(id);
            _context.SanPhams.Remove(deleteSP);
            _context.SaveChanges();
            return deleteSP;
              
        }

        public SanPham GetById(Guid id)
        {
            var getId =  _context.SanPhams.Find(id);
            return getId;
        }
    }
}
