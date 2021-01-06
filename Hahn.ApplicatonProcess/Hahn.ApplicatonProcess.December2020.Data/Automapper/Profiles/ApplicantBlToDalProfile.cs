using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Common.Models;
using Hahn.ApplicatonProcess.December2020.Data.Models;

namespace Hahn.ApplicatonProcess.December2020.Data.Automapper.Profiles
{
    public class ApplicantBlToDalProfile : Profile
    {
        public ApplicantBlToDalProfile()
        {
            CreateMap<ApplicantModel, Applicant>().ForMember(x => x.Hired, o => o.MapFrom(y => y.Hired ?? false));
            CreateMap<Applicant, ApplicantModel>();
        }
    }
}