using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Testamonials
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter The Client Name")]
        public string Name { get; set; }
      
        [Required(ErrorMessage = "Enter The Client Description")]
        public string Description { get; set; }
        public string? Image { get; set; }
    }
}
