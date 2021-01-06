using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Common.Models;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Implementation
{
    public class ApplicantBl : BaseBl, IApplicantBl
    {
        public ApplicantBl(ApplicatonProcessDal dal) : base(dal)
        {
        }

        public async Task<ApplicantModel> Get(int id)
        {
            return await _dal.ApplicantDal.Get(id);
        }

        public async Task<int> Add(ApplicantModel applicantModel)
        {
            return await _dal.ApplicantDal.Add(applicantModel);
        }

        public async Task Update(ApplicantModel applicantModel)
        {
            await _dal.ApplicantDal.Update(applicantModel);
            await _dal.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            await _dal.ApplicantDal.Remove(id);
            await _dal.SaveChangesAsync();
        }
    }
}