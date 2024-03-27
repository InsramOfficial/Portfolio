using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Signup
    {
        [Key]
        public int id { get; set; }
       
        public string Name { get; set; }

        public string Username { get; set; }
        
        public string Password { get; set; }
        
    }
}
