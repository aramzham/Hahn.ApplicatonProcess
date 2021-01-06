using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Common.Models;
using Hahn.ApplicatonProcess.December2020.Web.Models.ResponseModels;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Automapper.Profiles
{
    public class ApplicantBlToResponseModelProfile : Profile
    {
        public ApplicantBlToResponseModelProfile()
        {
            CreateMap<ApplicantModel, ApplicantResponseModel>().ForMember(x => x.Hired, o => o.NullSubstitute(false));
        }
    }
}