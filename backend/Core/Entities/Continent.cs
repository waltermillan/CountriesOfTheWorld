using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
[Table("continent")]
public class Continent : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}
