using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Services
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Plz Enter your Service_Name")]
        public string Service_Name { get; set; }
        [Required(ErrorMessage = "Plz Enter your Service_Description")]
        public string Service_Description { get; set; }

        public string? Image { get; set; }

    }
}
