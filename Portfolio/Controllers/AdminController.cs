using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace insramportfolio.Controllers
{
    public class AdminController : Controller
    {
        IWebHostEnvironment env;
        DataDbContext db;
        public AdminController(DataDbContext _db, IWebHostEnvironment env)
        {
            db=_db;
            this.env = env;
            
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }
		#region Aboutus
		public IActionResult AboutMe() 
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {

                ViewBag.Username = HttpContext.Session.GetString("username");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }

        }
        [HttpPost]
        public IActionResult AboutMe(Aboutme aboutme)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                db.tbl_about_me.Add(aboutme);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowAboutMe));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            

        }
		public IActionResult ShowAboutMe()
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var show = db.tbl_about_me.FirstOrDefault();
                return View(show);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
          
			
		}

		public IActionResult UpdateAboutMe(Aboutme aboutme)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                db.tbl_about_me.Update(aboutme);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowAboutMe));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
          


        }

		#endregion

		#region Social Links
		public IActionResult SocialLinks()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }
        [HttpPost]
		public IActionResult SocialLinks(SocialLinks socialLinks)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                db.tbl_sociallinks.Add(socialLinks);
                db.SaveChanges();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
		}


        public IActionResult ShowSocaillinks()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var show = db.tbl_sociallinks.FirstOrDefault();
                return View(show);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }

        }
		public IActionResult UpdatesSocaillinks(SocialLinks socialLinks)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                db.tbl_sociallinks.Update(socialLinks);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowSocaillinks));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
		}

		#endregion#


		#region Portfolio
		public IActionResult AddPortfolio()
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
		}
		[HttpPost]
        public IActionResult AddPortfolio(PortfolioVM portfolioVM)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Portfolio_ port = new();
                port.Name = portfolioVM.Name;
                port.Description = portfolioVM.Description;
                port.Image = portfolioVM.Image.FileName;
                var Folderpath = Path.Combine(env.WebRootPath, "images");
                var Imagepath = Path.Combine(Folderpath, portfolioVM.Image.FileName);
                portfolioVM.Image.CopyTo(new FileStream(Imagepath, FileMode.Create));
                db.tbl_portfolio.Add(port);
                db.SaveChanges();

                return RedirectToAction(nameof(ShowPortfolio));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
        }

        public IActionResult  ShowPortfolio()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var show = db.tbl_portfolio;
			return View(show);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
		}
        public IActionResult UpdatePortfolio(int id)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var update = db.tbl_portfolio.Find(id);
                PortfolioVM port = new();
                port.Name = update.Name;
                port.Description = update.Description;
                port.ImageName = update.Image;
                return View(port);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }
        [HttpPost]
		public IActionResult UpdatePortfolio(PortfolioVM portfolioVM)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Portfolio_ portfolio = new();
                portfolio.id = portfolioVM.id;
                portfolio.Name = portfolioVM.Name;
                portfolio.Description = portfolioVM.Description;
                if (portfolioVM.Image != null)
                {
                    portfolio.Image = portfolioVM.Image.FileName;
                    var Folderpath = Path.Combine(env.WebRootPath, "images");
                    var ImagePath = Path.Combine(Folderpath, portfolioVM.Image.FileName);
                    portfolioVM.Image.CopyTo(new FileStream(ImagePath, FileMode.Create));
                }

                else
                {
                    portfolio.Image = portfolioVM.ImageName;
                }
                db.tbl_portfolio.Update(portfolio);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowPortfolio));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            

        }
		public IActionResult DeletePortfolio(int id)
		{
            if(HttpContext.Session.GetString("flag")=="true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_portfolio.Find(id);
                db.tbl_portfolio.Remove(data);
                db.SaveChanges();

                return RedirectToAction(nameof(ShowPortfolio));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
		
		}
		#endregion

		#region Pricing

        public IActionResult AddPricing()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
        }

        [HttpPost]
		public IActionResult AddPricing(PricingVM pricingVM)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Pricing port = new Pricing();
                port.Name = pricingVM.Name;
                port.f1 = pricingVM.f1;
                port.f2 = pricingVM.f2;
                port.f3 = pricingVM.f3;
                port.f4 = pricingVM.f4;
                port.f5 = pricingVM.f5;
                port.f6 = pricingVM.f6;
                port.Packegeprice = pricingVM.Packegeprice;
                port.Image = pricingVM.Image.FileName;

                var Folderpath = Path.Combine(env.WebRootPath, "images");
                var Imagepath = Path.Combine(Folderpath, pricingVM.Image.FileName);
                pricingVM.Image.CopyTo(new FileStream(Imagepath, FileMode.Create));


                db.tbl_pricing.Add(port);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowPricing));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
		}

        public IActionResult ShowPricing()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var show = db.tbl_pricing;
                return View(show);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
        }


        public IActionResult UpdatePricing(int id)
        {
            if(HttpContext.Session.GetString("flag")=="true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_pricing.Find(id);
                PricingVM pricingVM = new();
                pricingVM.Name = data.Name;
                pricingVM.Packegeprice = data.Packegeprice;
                pricingVM.ImageName = data.Image;
                pricingVM.f1 = data.f1;
                pricingVM.f2 = data.f2;
                pricingVM.f3 = data.f3;
                pricingVM.f4 = data.f4;
                pricingVM.f5 = data.f5;
                pricingVM.f6 = data.f6;

                return View(pricingVM);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
        }
        [HttpPost]
		public IActionResult UpdatePricing(PricingVM pricingVM)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Pricing port = new();
                port.id = pricingVM.id;
                port.Name = pricingVM.Name;
                port.f1 = pricingVM.f1;
                port.f2 = pricingVM.f2;
                port.f3 = pricingVM.f3;
                port.f4 = pricingVM.f4;
                port.f5 = pricingVM.f5;
                port.f6 = pricingVM.f6;
                port.Packegeprice = pricingVM.Packegeprice;

                if (pricingVM.Image != null)
                {
                    port.Image = pricingVM.Image.FileName;
                    var Folderpath = Path.Combine(env.WebRootPath, "images");
                    var Imagepath = Path.Combine(Folderpath, pricingVM.Image.FileName);
                    pricingVM.Image.CopyTo(new FileStream(Imagepath, FileMode.Create));
                }
                else
                {
                    port.Image = pricingVM.ImageName;

                }
                db.tbl_pricing.Update(port);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowPricing));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
		}

		public IActionResult DeletePricing(int id)
        {

            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_pricing.Find(id);
                db.tbl_pricing.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowPricing));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
        }

		#endregion

		#region Services

        public IActionResult Addservices()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }

        }

        [HttpPost]
		public IActionResult Addservices(ServicesVM servicesVM)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Services services = new();
                services.Service_Name = servicesVM.Service_Name;
                services.Service_Description = servicesVM.Service_Description;
                services.Image = servicesVM.Image.FileName;
                var FolderPath = Path.Combine(env.WebRootPath, "images");
                var Imagepath = Path.Combine(FolderPath, servicesVM.Image.FileName);
                servicesVM.Image.CopyTo(new FileStream(Imagepath, FileMode.Create));

                db.tbl_services.Add(services);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowServices));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
		}


        public IActionResult ShowServices()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_services;
                return View(data);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
        }

        public IActionResult UpdateServices(int id)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_services.Find(id);
                ServicesVM services = new();
                services.Service_Name = data.Service_Name;
                services.Service_Description = data.Service_Description;
                services.ImageName = data.Image;
                return View(services);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
        }
        [HttpPost]
		public IActionResult UpdateServices(ServicesVM servicesVM)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Services services = new();
                services.id = servicesVM.id;
                services.Service_Name = servicesVM.Service_Name;
                services.Service_Description = servicesVM.Service_Description;
                if (servicesVM.Image != null)
                {
                    services.Image = servicesVM.Image.FileName;
                    var Folderpath = Path.Combine(env.WebRootPath, "images");
                    var Imagepath = Path.Combine(Folderpath, servicesVM.Image.FileName);
                    servicesVM.Image.CopyTo(new FileStream(Imagepath, FileMode.Create));
                }
                else
                {
                    services.Image = servicesVM.ImageName;

                }
                db.tbl_services.Update(services);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowServices));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
          
		}
		public IActionResult DeleteServices(int id)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_services.Find(id);
                db.tbl_services.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowServices));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
		}
		#endregion


		#region Testamonaials


        public IActionResult AddTestamonials()
        {
            if(HttpContext.Session.GetString("flag")=="true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
        }

		[HttpPost]
		public IActionResult AddTestamonials(TestimonailsVM testimonailsVM)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Testamonials port = new();
                port.Id = testimonailsVM.Id;
                port.Name = testimonailsVM.Name;
                port.Description = testimonailsVM.Description;
                port.Image = testimonailsVM.Image.FileName;
                var Folderpath = Path.Combine(env.WebRootPath, "images");
                var Imagepath = Path.Combine(Folderpath, testimonailsVM.Image.FileName);
                testimonailsVM.Image.CopyTo(new FileStream(Imagepath, FileMode.Create));
                db.tbl_testamonials.Add(port);
                db.SaveChanges();

                return RedirectToAction(nameof(ShowTestimonial));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
		}

		public IActionResult ShowTestimonial()
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var show = db.tbl_testamonials;
                return View(show);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
		}
		public IActionResult UpdateTestimonial(int id)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var update = db.tbl_testamonials.Find(id);
                TestimonailsVM port = new();
                port.Name = update.Name;
                port.Description = update.Description;
                port.ImageName = update.Image;
                return View(port);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
		}
		[HttpPost]
		public IActionResult UpdateTestimonial(TestimonailsVM testimonailsVM)
		{
             if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Testamonials testamonial = new();
                testamonial.Id = testimonailsVM.Id;
                testamonial.Name = testimonailsVM.Name;
                testamonial.Description = testimonailsVM.Description;
                if (testimonailsVM.Image != null)
                {
                    testamonial.Image = testimonailsVM.Image.FileName;
                    var Folderpath = Path.Combine(env.WebRootPath, "images");
                    var ImagePath = Path.Combine(Folderpath, testimonailsVM.Image.FileName);
                    testimonailsVM.Image.CopyTo(new FileStream(ImagePath, FileMode.Create));
                }

                else
                {
                    testamonial.Image = testimonailsVM.ImageName;
                }
                db.tbl_testamonials.Update(testamonial);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowTestimonial));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
			

		}
		public IActionResult DeleteTestimonial(int id)
		{
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_testamonials.Find(id);
                db.tbl_testamonials.Remove(data);
                db.SaveChanges();

                return RedirectToAction(nameof(ShowTestimonial));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
		}
        #endregion



        #region Contact

        [HttpPost]
        public IActionResult ADDContact(string name,string email, string message)
        {

            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                Contactme contact = new Contactme();
                contact.Name = name;
                contact.Email = email;
                contact.Message = message;
                db.tbl_contact_me.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
        }

        public IActionResult ShowContact()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("username");
                var data = db.tbl_contact_me;
                return View(data);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            

        }


        public IActionResult DeleteContact(int id)
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {

                var data = db.tbl_contact_me.Find(id);
                db.tbl_contact_me.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowContact));
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
           
        }
        #endregion



        #region Login

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVm loginVm)
        {
           
            if(ModelState.IsValid)
            {
                var login = db.tbl_Signup.Where(s => s.Username == loginVm.Username && s.Password == loginVm.Password).FirstOrDefault();
                
                if(login is not null)
                {
                    HttpContext.Session.SetString("username",login.Username );
                    HttpContext.Session.SetString("flag","true" );
                    return RedirectToAction("Index", "Admin");
                }

                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                }
            }
            return View();
        }
        #endregion


        #region Signup
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SIgnupVM sIgnupVM)
        {

            if(ModelState.IsValid)
            {
                Signup signup = new();
                signup.Name = sIgnupVM.Name;
                signup.Username = sIgnupVM.Username;
                signup.Password = sIgnupVM.Password;
                db.tbl_Signup.Add(signup);
                db.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View();
            }
        }
        #endregion


        #region Logout

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
        #endregion
    }
}
