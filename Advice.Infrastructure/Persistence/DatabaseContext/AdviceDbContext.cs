using Advice.Domain.Entities;
using Advice.Domain.SettingsOptions.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Advice.Infrastructure.Persistence.DatabaseContext;

public class AdviceDbContext : DbContext
{
    private readonly IMongoDatabase _mongoDatabase = null!;

    public AdviceDbContext(IOptions<DatabaseOptions> databaseOptions)
    {
        MongoClient mongoClient = new(databaseOptions.Value.ConnectionString);
        _mongoDatabase = mongoClient.GetDatabase(databaseOptions.Value.DatabaseName);
    }

    public IMongoCollection<QuickTip> QuickTips => _mongoDatabase.GetCollection<QuickTip>("quickTip");
}