using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
[Table("continents")]
public class Continent : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}
