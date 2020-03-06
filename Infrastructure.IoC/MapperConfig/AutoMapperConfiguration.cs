using AutoMapper;
using AppService.UserAppService.ViewModel;
using Domain.User.Entity;

namespace Infrastructure.IoC.MapperConfig
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateConfiguration();
        }

        public void CreateConfiguration()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}

