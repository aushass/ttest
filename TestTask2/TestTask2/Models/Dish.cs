using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestTask2.Models
{
    [Table("Dish")]
    public class Dish
    {
        [Key]
        public int IdDish { get; set; }

        [Column("NameDish")]
        public string NameDish { get; set; }
    }
}
