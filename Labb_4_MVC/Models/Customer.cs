using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb_4_MVC.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "min: 4 max:50")]
        public string FullName { get; set; }
        [Required]
        [Range(5, 120)]
        public int age { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<BorrowedBook> BorrowedBook { get; set;} = new List<BorrowedBook>();
    }
}
