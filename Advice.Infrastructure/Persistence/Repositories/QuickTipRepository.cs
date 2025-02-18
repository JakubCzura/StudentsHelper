using Advice.Application.Interfaces.Persistence.Repositories;
using Advice.Domain.Entities;
using Advice.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Advice.Infrastructure.Persistence.Repositories;

internal class QuickTipRepository(AdviceDbContext adviceDbContext) : IQuickTipRepository
{
    public async Task<QuickTip?> GetRandomAsync(CancellationToken cancellationToken)
        => await adviceDbContext.QuickTips.AsNoTracking()
                                          .OrderBy(x => EF.Functions.Random())
                                          .FirstOrDefaultAsync(cancellationToken);
}