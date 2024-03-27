using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
	public class PortfolioVM
	{
		[Key]
		public int id { get; set; }

		[Required(ErrorMessage = "Plz Enter  Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Plz Enter  Description")]
		public string Description { get; set; }
		public string? ImageName { get; set; }

		public IFormFile? Image { get; set; }
	}
}
