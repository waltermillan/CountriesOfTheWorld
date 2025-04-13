using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
[Table("goverments")]
public class Goverment : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}
