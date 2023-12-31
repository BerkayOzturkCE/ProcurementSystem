using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementSystem.Infrastructure.Persistence.Context;


namespace ProcurementSystem.Infrastructure.Persistence.EntityConfiguration.OrderContent;

public class OrderContentEntityConfiguration:BaseEntityConfiguration<Api.Domain.Models.OrderContent>
{

    public override void Configure(EntityTypeBuilder<Api.Domain.Models.OrderContent> builder)
    {
        base.Configure(builder);
        builder.ToTable("ordercontent", ProcurementSystemContext.DEFAULT_SCHEME);

        builder.HasOne(i => i.Order).WithMany(i=>i.Content).HasForeignKey(i=>i.OrderId);

    }
}
