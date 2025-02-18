using Advice.Domain.Entities.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace Advice.Domain.Entities;

public class QuickTip : DbEntityBase
{
    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;
}
