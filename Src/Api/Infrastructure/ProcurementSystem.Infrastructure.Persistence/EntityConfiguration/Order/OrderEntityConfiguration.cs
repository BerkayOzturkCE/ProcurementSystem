using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementSystem.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Infrastructure.Persistence.EntityConfiguration.Order;

public class OrderEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.Order>
{
    public override void Configure(EntityTypeBuilder<Api.Domain.Models.Order> builder)
    {
        base.Configure(builder);
        builder.ToTable("order", ProcurementSystemContext.DEFAULT_SCHEME);
    }
}
