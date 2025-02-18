using Advice.Domain.Entities.Base;

namespace Advice.Domain.Entities;

public class QuickTip : DbEntityBase
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}