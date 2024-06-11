using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configuration
{
    public class ThanhToanConfiguration : IEntityTypeConfiguration<ThanhToan>
    {
        public void Configure(EntityTypeBuilder<ThanhToan> builder)
        {
            builder.ToTable("ThanhToan");
            builder.HasKey(x => x.Id);
        }
    }
}
