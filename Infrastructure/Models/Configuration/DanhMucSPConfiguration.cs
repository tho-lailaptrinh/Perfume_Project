
using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configuration
{
    public class DanhMucSPConfiguration : IEntityTypeConfiguration<DanhMucSanPham>
    {
        public void Configure(EntityTypeBuilder<DanhMucSanPham> builder)
        {
            builder.ToTable("DanhMucSanPham");
            builder.HasKey(x => x.Id);
        }
    }
}
