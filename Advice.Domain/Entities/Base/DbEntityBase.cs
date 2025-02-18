using MongoDB.Bson;

namespace Advice.Domain.Entities.Base;

public abstract class DbEntityBase
{
    public ObjectId Id { get; set; }
}