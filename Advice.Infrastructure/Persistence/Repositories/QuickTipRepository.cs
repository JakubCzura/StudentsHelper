using Advice.Application.Interfaces.Persistence.Repositories;
using Advice.Domain.Entities;
using Advice.Infrastructure.Persistence.DatabaseContext;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Advice.Infrastructure.Persistence.Repositories;

internal class QuickTipRepository(AdviceDbContext adviceDbContext) : IQuickTipRepository
{
    public async Task<QuickTip?> GetRandomAsync(CancellationToken cancellationToken)
        => await adviceDbContext.QuickTips.AsQueryable()
                                          .Sample(1)
                                          .FirstOrDefaultAsync(cancellationToken);                                    
}