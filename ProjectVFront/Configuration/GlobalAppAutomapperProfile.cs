using AutoMapper;
using ProjectVFront.Crosscutting.Dtos;
using ProjectVFront.WebClient.ViewModels;

namespace ProjectVFront.WebClient.Configuration
{
    public class GlobalAppAutomapperProfile : Profile
    {
        public GlobalAppAutomapperProfile()
        {
            CreateMap<SignUpViewModel, SignUpRequestDto>().ReverseMap();
            CreateMap<LogInViewModel, LogInRequestDto>().ReverseMap();
        }
    }
}
