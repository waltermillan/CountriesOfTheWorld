using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("languages")]
public class Language : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}
