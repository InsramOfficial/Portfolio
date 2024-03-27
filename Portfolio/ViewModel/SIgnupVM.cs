using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
    public class SIgnupVM
    {
        [Required(ErrorMessage = "Enter Your Name ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Your User_Name ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Your Password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Enter Your Confirm_Password ")]
        [Compare("Password", ErrorMessage = "Password and Confirm_Password Did Not Match")]
        [DataType(DataType.Password)]
        public string Confirm_Password { get; set; }
    }
}
