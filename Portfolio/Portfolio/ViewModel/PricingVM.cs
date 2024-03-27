using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
	public class PricingVM
	{
		[Key]
		public int id { get; set; }

		[Required(ErrorMessage = "Plz Enter your Name")]
		public string Name { get; set; }

		[Display(Name="Enter 1 Include")]
		public string f1 { get; set; }
		[Display(Name = "Enter 2 Include")]

		public string? f2 { get; set; }
		[Display(Name = "Enter 3 Include")]

		public string? f3 { get; set; }
		[Display(Name="Enter 4 Include")]

		public string? f4 { get; set; }
		[Display(Name="Enter 5 Include")]

		public string? f5 { get; set; }
		[Display(Name="Enter 6 Include")]

		public string? f6 { get; set; }


		[Required(ErrorMessage = "Plz Enter your Packege Price")]
		public int Packegeprice { get; set; }

		public string? ImageName { get; set; }
		public IFormFile? Image { get; set; }
	}
}
