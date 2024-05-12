using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb_4_MVC.Models
{
    public class BorrowedBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
