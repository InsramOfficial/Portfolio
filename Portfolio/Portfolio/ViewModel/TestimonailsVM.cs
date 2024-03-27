using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
	public class TestimonailsVM
	{

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Enter The Client Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Enter The Client Description")]
		public string Description { get; set; }
		public string? ImageName { get; set; }
		public IFormFile? Image { get; set; }
	}
}

