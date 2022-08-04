using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//LAPTOP-9Q643LVC
namespace WebAPI2.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public DateTime? Birth { get; set; }
    }
}
