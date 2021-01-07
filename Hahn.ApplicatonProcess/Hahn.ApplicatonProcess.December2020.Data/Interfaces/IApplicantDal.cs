using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Common.Models;

namespace Hahn.ApplicatonProcess.December2020.Data.Interfaces
{
    public interface IApplicantDal
    {
        Task<ApplicantModel> Get(int id);
        Task<int> Add(ApplicantModel applicantModel);
        Task<bool> Update(ApplicantModel applicantModel, int id);
        Task<bool> Remove(int id);
    }
}