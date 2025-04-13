using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("countries")]
    public class Country : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("spanish_name")]
        public string SpanishName { get; set; }

        [Column("population")]
        public long Population { get; set; }

        [Column("surface")]
        public string Surface { get; set; }

        [Column("independence_day")]
        public DateTime? IndependenceDay { get; set; }

        [Column("goverment_id")]
        public long GovermentId { get; set; }

        [Column("language_id")]
        public long LanguageId { get; set; }

        [Column("continent_id")]
        public long ContinentId { get; set; }

        [Column("anthem_id")]
        public long AnthemId { get; set; }
    }
}
