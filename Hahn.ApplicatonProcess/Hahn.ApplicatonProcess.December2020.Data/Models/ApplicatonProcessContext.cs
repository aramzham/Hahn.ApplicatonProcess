using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Models
{
    public class ApplicatonProcessContext : DbContext
    {
        public ApplicatonProcessContext()
        {

        }

        public ApplicatonProcessContext(DbContextOptions<ApplicatonProcessContext> options) : base(options)
        {

        }

        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().HasData(new Applicant()
            {
                Address = "Yerevan, Charbax",
                Age = 31,
                CountryOfOrigin = "France",
                EMailAddress = "sexy_charbaxci@pornhub.com",
                FamilyName = "Pashinyan",
                Hired = true,
                Id = 1,
                Name = "Artak"
            });

            modelBuilder.Entity<Applicant>().HasData(new Applicant()
            {
                Address = "Berlin",
                Age = 28,
                CountryOfOrigin = "Germany",
                EMailAddress = "dimitrios_petratos@tuy.am",
                FamilyName = "Petratos",
                Hired = false,
                Id = 2,
                Name = "Dimitrios"
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Hahn.ApplicatonProcess.Database");
        }
    }
}