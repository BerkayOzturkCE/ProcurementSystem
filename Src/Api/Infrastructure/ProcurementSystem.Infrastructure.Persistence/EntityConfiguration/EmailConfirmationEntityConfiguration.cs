using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementSystem.Api.Domain.Models;
using ProcurementSystem.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Infrastructure.Persistence.EntityConfiguration;

public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EmailConfirmation>
{
    public override void Configure(EntityTypeBuilder<Api.Domain.Models.EmailConfirmation> builder)
    {
        base.Configure(builder);
        builder.ToTable("emailconfirmation", ProcurementSystemContext.DEFAULT_SCHEME);


    }
}
