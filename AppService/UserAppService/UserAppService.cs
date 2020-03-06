using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using AppService.UserAppService.ViewModel;
using Domain.User.Service;

namespace AppService.UserAppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper mapper;
        private IUserService userService;
        public UserAppService(IUserService userService, IMapper mapper)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        public List<UserViewModel> GetUsers()
        {
            return mapper.Map<List<UserViewModel>>(userService.GetUsers().ToList());
        }
    }
}
