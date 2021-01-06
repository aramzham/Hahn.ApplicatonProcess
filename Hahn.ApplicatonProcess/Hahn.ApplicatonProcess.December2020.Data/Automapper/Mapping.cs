using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Automapper.Profiles;

namespace Hahn.ApplicatonProcess.December2020.Data.Automapper
{
    public static class Mapping
    {
        public static IMapper Config()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ApplicantBlToDalProfile>();
            });

            return config.CreateMapper();
        }
    }
}