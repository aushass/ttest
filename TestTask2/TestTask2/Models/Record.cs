using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask2.Models
{
    [Table("Records")]
    public class Record
    {
        [Key]
        public int IdRecord { get; set; }

        [Column("IdUser")]
        public int IdUser { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("IdDish")]
        public int IdDish { get; set; }
    }
}
