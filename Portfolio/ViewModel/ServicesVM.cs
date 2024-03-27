using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
	public class ServicesVM
	{

		[Key]
		public int id { get; set; }

		[Required(ErrorMessage = "Plz Enter your Service_Name")]
		public string Service_Name { get; set; }
		[Required(ErrorMessage = "Plz Enter your Service_Description")]
		public string Service_Description { get; set; }
		public string? ImageName { get; set; }
		public IFormFile? Image { get; set; }
	}
}
