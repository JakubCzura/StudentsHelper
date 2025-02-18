using Advice.Domain.SeedData;
using Advice.Infrastructure.Persistence.DatabaseContext;
using MongoDB.Driver;

namespace Advice.API.ExtensionMethods.Database;

public static class DatabaseExtensions
{
    public static void SeedDatabase(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using AdviceDbContext dbContext = scope.ServiceProvider.GetRequiredService<AdviceDbContext>();
        SeedData(dbContext);
    }

    private static void SeedData(AdviceDbContext context)
    {
        List<string> quickTipsTitles = QuickTipSeed.QuickTips.Select(x => x.Title).ToList();
        bool areQuickTipsInserted = context.QuickTips.AsQueryable().Any(x => quickTipsTitles.Contains(x.Title));
        if (!areQuickTipsInserted)
        {
            context.QuickTips.InsertMany(QuickTipSeed.QuickTips);
        }
    }
}