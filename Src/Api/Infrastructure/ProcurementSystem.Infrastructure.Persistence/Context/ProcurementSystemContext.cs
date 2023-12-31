using Microsoft.EntityFrameworkCore;
using ProcurementSystem.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Infrastructure.Persistence.Context;

public class ProcurementSystemContext:DbContext
{
    public const string DEFAULT_SCHEME= "dbo";

    public ProcurementSystemContext()
    {

    }

    public ProcurementSystemContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderContent> OrderContents { get; set; }
    public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conString = "Data Source=DESKTOP-J8S6BN0;Initial Catalog=ProcurementSystemDatabase;User ID=sa;Password=sa123+;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(conString, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addenEntity =ChangeTracker.Entries().Where(i=>i.State==EntityState.Added).Select(i=>(BaseEntity)i.Entity);
        PrepareAddenEntities(addenEntity);
    }

    private void PrepareAddenEntities(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.CreatedDate==DateTime.MinValue)
            {
                entity.CreatedDate = DateTime.Now;
            }
            else
            {
                entity.UpdatedDate = DateTime.Now;
            }

        }
    }





}
