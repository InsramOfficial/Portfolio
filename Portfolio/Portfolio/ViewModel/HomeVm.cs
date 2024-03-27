using Portfolio.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
	public class HomeVm
	{
		public Aboutme aboutme { get; set; }
		public IEnumerable<Portfolio_> portfolio { get; set; }
		public IEnumerable<Testamonials> testamonials { get; set; }
		public SocialLinks sociallinks { get; set; }
		public IEnumerable<Pricing> pricing { get; set; }
		public IEnumerable<Services> services { get; set; }

	}
}
