using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Common.Models;
using Hahn.ApplicatonProcess.December2020.Data.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Implementations
{
    public class ApplicantDal : BaseDal, IApplicantDal
    {
        public ApplicantDal(ApplicatonProcessContext db) : base(db)
        {
        }

        public async Task<ApplicantModel> Get(int id)
        {
            var applicant = await _db.Applicants.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ApplicantModel>(applicant);
        }

        public async Task<int> Add(ApplicantModel applicantModel)
        {
            var applicant = _mapper.Map<Applicant>(applicantModel);
            await _db.Applicants.AddAsync(applicant);
            await _db.SaveChangesAsync();
            return applicant.Id;
        }

        public async Task Update(ApplicantModel applicantModel)
        {
            var applicant = await _db.Applicants.FirstOrDefaultAsync(x => x.Id == applicantModel.Id);
            if (applicant is null)
                return;

            if (!string.IsNullOrEmpty(applicantModel.FamilyName))
                applicant.FamilyName = applicantModel.FamilyName;
            if (!string.IsNullOrEmpty(applicantModel.CountryOfOrigin))
                applicant.CountryOfOrigin = applicantModel.CountryOfOrigin;
            if (!string.IsNullOrEmpty(applicantModel.EMailAdress))
                applicant.EMailAdress = applicantModel.EMailAdress;
            if (!string.IsNullOrEmpty(applicantModel.Address))
                applicant.Address = applicantModel.Address;
            if (applicantModel.Age != default)
                applicant.Age = applicantModel.Age;
            if (applicantModel.Hired.HasValue)
                applicant.Hired = applicantModel.Hired.Value;
        }

        public async Task Remove(int id)
        {
            var applicant = await _db.Applicants.FirstOrDefaultAsync(x => x.Id == id);
            if(applicant is null)
                return;

            _db.Applicants.Remove(applicant);
        }
    }
}