using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Common.Models;

namespace Hahn.ApplicatonProcess.December2020.Data.Interfaces
{
    public interface IApplicantDal
    {
        Task<ApplicantModel> Get(int id);
        Task<int> Add(ApplicantModel applicantModel);
        Task Update(ApplicantModel applicantModel, int id);
        Task Remove(int id);
    }
}