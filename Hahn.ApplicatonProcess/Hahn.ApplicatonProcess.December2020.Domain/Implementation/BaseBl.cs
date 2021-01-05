using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Implementation
{
    public class BaseBl : IBaseBl
    {
        protected ApplicatonProcessDal _dal;

        public BaseBl(ApplicatonProcessDal dal)
        {
            _dal = dal;
        }

        protected void SaveChanges()
        {
            _dal.SaveChanges();
        }

        protected async Task SaveChangesAsync()
        {
            await _dal.SaveChangesAsync();
        }
    }
}