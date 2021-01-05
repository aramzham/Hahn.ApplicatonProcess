using Hahn.ApplicatonProcess.December2020.Data.Implementations;
using Hahn.ApplicatonProcess.December2020.Data.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Models;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class ApplicatonProcessDal
    {
        private ApplicatonProcessContext _db;

        protected ApplicatonProcessContext DB => _db ??= new ApplicatonProcessContext();

        public ApplicatonProcessDal()
        {
            
        }

        public ApplicatonProcessDal(ApplicatonProcessContext db)
        {
            _db = db;
        }

        private IApplicantDal _applicantDal;
        public IApplicantDal ApplicantDal => _applicantDal ??= new ApplicantDal();
    }
}