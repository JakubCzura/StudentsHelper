using System.ComponentModel.DataAnnotations;

namespace Advice.Domain.Entities.Base;

public abstract class DbEntityBase
{
    [Key]
    public int Id { get; set; }
}