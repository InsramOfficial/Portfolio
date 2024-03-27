using Portfolio.Data;
using Portfolio.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {

        DataDbContext db;
        public HomeController(DataDbContext _db)
        {
            db= _db;
        }
        public IActionResult Index()
        {

            HomeVm vm = new HomeVm();

            vm.aboutme = db.tbl_about_me.FirstOrDefault();
            vm.sociallinks = db.tbl_sociallinks.FirstOrDefault();
			vm.portfolio = db.tbl_portfolio.ToList();
            vm.services = db.tbl_services.ToList();
            vm.testamonials = db.tbl_testamonials.ToList();
            vm.pricing = db.tbl_pricing.ToList();
			return View(vm);
        }
    }
}
