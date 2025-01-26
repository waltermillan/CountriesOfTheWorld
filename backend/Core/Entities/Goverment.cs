using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
[Table("goverment")]
public class Goverment : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}
