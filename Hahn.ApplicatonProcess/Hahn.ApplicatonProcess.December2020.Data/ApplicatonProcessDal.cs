using System;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Implementations;
using Hahn.ApplicatonProcess.December2020.Data.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Models;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class ApplicatonProcessDal : IDisposable
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

        #region Dals

        private IApplicantDal _applicantDal;
        public IApplicantDal ApplicantDal => _applicantDal ??= new ApplicantDal(DB);

        #endregion

        #region SaveChanges

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        #endregion

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}