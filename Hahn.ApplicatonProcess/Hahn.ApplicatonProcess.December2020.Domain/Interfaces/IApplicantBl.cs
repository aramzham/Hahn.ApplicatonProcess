using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Common.Models;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantBl : IBaseBl
    {
        Task<ApplicantModel> Get(int id);
        Task<int> Add(ApplicantModel applicantModel);
        Task Update(ApplicantModel applicantModel, int id);
        Task Remove(int id);
    }
}