using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configuration
{
    public class DanhGiaSPConfiguration : IEntityTypeConfiguration<DanhGiaSP>
    {
        public void Configure(EntityTypeBuilder<DanhGiaSP> builder)
        {
            builder.ToTable("DanhGiaSP");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SanPham).WithMany(x => x.DanhGiaSPs).HasForeignKey(x => x.IdSP);
        }
    }
}
