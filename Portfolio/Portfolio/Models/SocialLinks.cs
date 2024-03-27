using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class SocialLinks
    {

        public int id { get; set; }
        public string ?Twiter { get; set; }

        [Required(ErrorMessage ="Enter Your Facebook Link")]
        public string Facebook { get; set; }
        public string ?Instagram { get; set; }
    }
}
