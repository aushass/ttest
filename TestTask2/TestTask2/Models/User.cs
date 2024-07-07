using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestTask2.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Column("NameUser")]
        public string NameUser { get; set; }

        [Column("EmailUser")]
        public string EmailUser { get; set; }
    }
}
