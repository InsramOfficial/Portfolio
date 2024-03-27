using Portfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data
{
    public class DataDbContext: DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
        

        public DbSet<Aboutme> tbl_about_me { get; set; }
        public DbSet<Contactme> tbl_contact_me{ get; set; }
        public DbSet<Portfolio_> tbl_portfolio { get; set; }
        public DbSet<Pricing> tbl_pricing { get; set; }
        public DbSet<Services> tbl_services { get; set; }
        public DbSet<SocialLinks> tbl_sociallinks { get; set; }
        public DbSet<Testamonials> tbl_testamonials { get; set; }
        public DbSet<Signup> tbl_Signup { get; set; }
        public DbSet<Login> tbl_Login { get; set; }

    }
}
