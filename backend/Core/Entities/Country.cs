using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
[Table("country")]
public class Country : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("spanish_name")]
    public string SpanishName { get; set; }
    [Column("population")]
    public double Population { get; set; }
    [Column("surface")]
    public double Surface { get; set; }
    [Column("independence_day")]
    public DateTime IndependenceDay { get; set; }
    [Column("goverment_id")]
    public int GovermentId { get; set; }
    [Column("language_id")]
    public int LanguageId { get; set; }
    [Column("continent_id")]
    public int ContinentId { get; set; }
    [Column("anthem_id")]
    public int AnthemId { get; set; }
}
