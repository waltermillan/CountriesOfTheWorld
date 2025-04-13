using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("symbols")]
    public class Symbol : BaseEntity
    {
        [Column("flag")]
        public string Flag { get; set; }
        [Column("coat_of_arms")]
        public string CoatOfArms { get; set; }
    }
}
