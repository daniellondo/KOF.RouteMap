using KOF.RouteMap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KOF.RouteMap.Infrastructure.Persistence.Configurations;

public class VisitPlanConfiguration : IEntityTypeConfiguration<VisitPlan>
{
    public void Configure(EntityTypeBuilder<VisitPlan> builder)
    {
        builder.ToTable("VisitPlan");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

    }
}
