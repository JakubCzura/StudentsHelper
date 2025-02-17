using System.ComponentModel.DataAnnotations;

namespace School.Domain.Entities.Base;

public abstract class DbEntityBase
{
    [Key]
    public int Id { get; set; }
}