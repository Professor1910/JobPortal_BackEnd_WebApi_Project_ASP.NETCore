using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApplication.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> option):base(option)
        {

        }
        public DbSet<Jobs> tblJob {  get; set; }
        public DbSet<JobProvider> tblJobProviders { get; set; }
        public DbSet<JobSeeker> tblJobSeekers { get; set; }
        public DbSet<JobApply> tblJobApply { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobProvider>().HasData(
            new JobProvider { EmailId = "aziz_infosys@gmail.com", Password = HashPassword("aziz@infosys"), FirstName = "Md", LastName = "Aziz", CompanyName = " Infosys", Address = "Kolkata NewTown" },
            new JobProvider { EmailId = "suman_accenture@gmail.com", Password = HashPassword("suman@accenture"), FirstName = "Suman", LastName = "Bose", CompanyName = "Accenture", Address = "Kolkata Salt Lake Sector V" },
            new JobProvider { EmailId = "rajib_godrej@gmail.com", Password = HashPassword("rajib@godrej"), FirstName = "Rajib", LastName = "Sen", CompanyName = "Godrej", Address = "Kolkata EcoSpace" });

        }
        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
            return hashedPassword;
        }
    }
}
