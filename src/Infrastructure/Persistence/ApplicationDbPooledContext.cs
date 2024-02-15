using KOF.RouteMap.Application.Common.Interfaces;
using KOF.RouteMap.Domain.Common;
using KOF.RouteMap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KOF.RouteMap.Infrastructure.Persistence;

public class ApplicationDbPooledContext(
    DbContextOptions<ApplicationDbPooledContext> options) : DbContext(options), IApplicationDbPooledContext
{
    public int TenantId { get; set; }
    public DbSet<VisitPlan> VisitPlans => Set<VisitPlan>();

    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    //{
    //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
    //    {
    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.CreatedBy = "UserId";
    //                entry.Entity.Created = _dateTime.Now;
    //                entry.Entity.RowVersion = Guid.NewGuid();
    //                break;

    //            case EntityState.Modified:
    //                entry.Entity.LastModifiedBy = "UserId";
    //                entry.Entity.LastModified = _dateTime.Now;
    //                entry.Entity.RowVersion = Guid.NewGuid();
    //                break;
    //        }
    //    }

    //    var events = ChangeTracker.Entries<IHasDomainEvent>()
    //            .Select(x => x.Entity.DomainEvents)
    //            .SelectMany(x => x)
    //            .Where(domainEvent => !domainEvent.IsPublished)
    //            .ToArray();

    //    var result = 0;

    //    try
    //    {
    //        result = await base.SaveChangesAsync(cancellationToken);
    //    }
    //    catch (DbUpdateConcurrencyException ex)
    //    {
    //        // Update the values of the entity that failed to save from the store (https://docs.microsoft.com/es-es/ef/ef6/saving/concurrency)
    //        ex.Entries.Single().Reload();
    //    }

    //    await DispatchEvents(events);

    //    return result;
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // filtro por Tenant Id 
        //modelBuilder.Entity<WeatherForecast>()
        //    .HasQueryFilter(f => f.TenantId == TenantId)
        //    .HasData(
        //        new WeatherForecast
        //        {
        //            Id = 1,
        //            TenantId = 0,
        //            Date = new(2022, 1, 1),
        //            Summary = "Chilly",
        //            TemperatureC = -17
        //        },
        //        new WeatherForecast
        //        {
        //            Id = 2,
        //            TenantId = 0,
        //            Date = new(2022, 1, 2),
        //            Summary = "Balmy",
        //            TemperatureC = 38
        //        },
        //        new WeatherForecast
        //        {
        //            Id = 3,
        //            TenantId = 1,
        //            Date = new(2022, 1, 3),
        //            Summary = "Sweltering",
        //            TemperatureC = -7
        //        });

        base.OnModelCreating(modelBuilder);
    }

    //private async Task DispatchEvents(DomainEvent[] events)
    //{
    //    foreach (var @event in events)
    //    {
    //        @event.IsPublished = true;
    //        await _domainEventService.Publish(@event);
    //    }
    //}
}
