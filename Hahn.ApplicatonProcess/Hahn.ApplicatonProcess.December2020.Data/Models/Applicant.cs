using System.Reflection.Metadata.Ecma335;

namespace Hahn.ApplicatonProcess.December2020.Data.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}