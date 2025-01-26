using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("anthem")]
public class Anthem : BaseEntity
{
    [Column("motto")]
    public string Motto { get; set; }
    [Column("content")]
    public string Content { get; set; }
}
