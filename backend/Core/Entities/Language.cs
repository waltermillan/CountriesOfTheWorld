using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("language")]
public class Language : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}
