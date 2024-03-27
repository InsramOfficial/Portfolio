using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Aboutme
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Please Enter your Name")]
        [Display(Name= "Enter Your Name Please")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter your Name")]
        [Display(Name = "Enter Your Description Please")]

        public string Description { get; set; }
        

        [Required(ErrorMessage = "Please Enter your Description")]
        [Display(Name = "Enter Your Designation Please")]

        public string Designation { get; set; }
    }
}
