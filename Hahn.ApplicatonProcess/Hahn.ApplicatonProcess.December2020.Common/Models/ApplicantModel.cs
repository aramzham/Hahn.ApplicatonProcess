﻿namespace Hahn.ApplicatonProcess.December2020.Common.Models
{
    public class ApplicantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        public int Age { get; set; }
        public bool? Hired { get; set; }
    }
}