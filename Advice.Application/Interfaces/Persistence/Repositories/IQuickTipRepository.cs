using Advice.Domain.Entities;

namespace Advice.Application.Interfaces.Persistence.Repositories;

public interface IQuickTipRepository
{
    Task<QuickTip?> GetRandomAsync(CancellationToken cancellationToken);
}