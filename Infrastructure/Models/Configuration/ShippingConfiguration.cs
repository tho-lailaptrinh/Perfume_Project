using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configuration
{
    public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.ToTable("Shipping");
            builder.HasKey(x => x.Id);
        }
    }
}
