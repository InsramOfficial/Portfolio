using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Portfolio_
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Plz Enter  Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Plz Enter  Description")]
        public string Description { get; set; }
        public string? Image { get; set; }
    }
}
