using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configuration
{
    public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang");
            builder.HasKey(x => x.Id);
        }
    }
}
