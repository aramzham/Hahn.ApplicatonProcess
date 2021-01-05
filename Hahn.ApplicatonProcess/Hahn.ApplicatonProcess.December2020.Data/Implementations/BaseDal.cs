using Hahn.ApplicatonProcess.December2020.Data.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Models;

namespace Hahn.ApplicatonProcess.December2020.Data.Implementations
{
    public class BaseDal : IBaseDal
    {
        protected ApplicatonProcessContext _db;

        public BaseDal(ApplicatonProcessContext db)
        {
            _db = db;
        }
    }
}