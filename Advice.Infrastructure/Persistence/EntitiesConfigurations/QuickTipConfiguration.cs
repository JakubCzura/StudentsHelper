using Advice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Advice.Infrastructure.Persistence.EntitiesConfigurations;

internal class QuickTipConfiguration : IEntityTypeConfiguration<QuickTip>
{
    public void Configure(EntityTypeBuilder<QuickTip> builder)
    {
        builder.ToCollection("QuickTip");

        builder.Property(x => x.Title).IsRequired();

        builder.Property(x => x.Description).IsRequired();
    }
}