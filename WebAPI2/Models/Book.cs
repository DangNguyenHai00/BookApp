using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI2.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Publisher { get; set; }
        public int AuthorId { get; set; }
    }
}
