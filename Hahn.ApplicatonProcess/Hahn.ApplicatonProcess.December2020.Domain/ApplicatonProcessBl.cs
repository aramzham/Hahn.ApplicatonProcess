using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Implementation;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class ApplicatonProcessBl
    {
        private ApplicatonProcessDal _dal;
        protected ApplicatonProcessDal Dal => _dal ??= new ApplicatonProcessDal();

        public ApplicatonProcessBl()
        {
            
        }

        public ApplicatonProcessBl(ApplicatonProcessDal dal)
        {
            _dal = dal;
        }

        #region Bls

        private IApplicantBl _applicantBl;
        public IApplicantBl ApplicantBl => _applicantBl ??= new ApplicantBl(Dal);

        #endregion
    }
}