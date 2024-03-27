using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
    public class LoginVm
    {
        [Required(ErrorMessage ="Enter Your User_Name")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Enter Your User_Name")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
