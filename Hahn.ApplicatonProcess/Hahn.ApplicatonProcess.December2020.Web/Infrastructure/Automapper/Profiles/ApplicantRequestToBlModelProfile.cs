using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Common.Models;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Automapper.Profiles
{
    public class ApplicantRequestToBlModelProfile : Profile
    {
        public ApplicantRequestToBlModelProfile()
        {
            CreateMap<ApplicantAddRequestModel, ApplicantModel>();
            CreateMap<ApplicantUpdateRequestModel, ApplicantModel>();
        }
    }
}