using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Contactme
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your  Name")]

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Your  Message")]
        [MaxLength(500)]
        public string Message { get; set; }
    }
}
