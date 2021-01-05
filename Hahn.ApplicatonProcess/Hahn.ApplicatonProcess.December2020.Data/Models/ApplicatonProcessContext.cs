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
            base.OnModelCreating(modelBuilder);

            var applicant1 = new Applicant()
            {
                Address = "Yerevan, Charbax",
                Age = 31,
                CountryOfOrigin = "France",
                EMailAdress = "sexy_charbaxci@pornhub.com",
                FamilyName = "Pashinyan",
                Hired = true,
                Id = 1,
                Name = "Artak"
            };

            Applicants.Add(applicant1);

            var applicant2 = new Applicant()
            {
                Address = "Berlin",
                Age = 28,
                CountryOfOrigin = "Germany",
                EMailAdress = "dimitrios_petratos@tuy.am",
                FamilyName = "Petratos",
                Hired = false,
                Id = 2,
                Name = "Dimitrios"
            };

            Applicants.Add(applicant2);

            SaveChanges();
        }
    }
}