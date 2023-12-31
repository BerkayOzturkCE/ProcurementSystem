using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementSystem.Api.Domain.Models;


namespace ProcurementSystem.Infrastructure.Persistence.EntityConfiguration;

public abstract class BaseEntityConfiguration<T>:IEntityTypeConfiguration<T> where T : BaseEntity
{

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i=> i.Id).ValueGeneratedOnAdd();
        builder.Property(i=>i.CreatedDate).ValueGeneratedOnAdd();
        builder.Property(i => i.UpdatedDate).ValueGeneratedOnUpdate();
        builder.HasOne(i => i.CreatedBy).WithMany().HasForeignKey(i => i.CreatedById).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        builder.HasOne(i => i.UpdatedBy).WithMany().HasForeignKey(i => i.UpdatedById).OnDelete(DeleteBehavior.Restrict).IsRequired(false);

    }
}
