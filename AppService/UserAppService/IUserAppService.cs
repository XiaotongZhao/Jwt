using System.Collections.Generic;
using AppService.UserAppService.ViewModel;

namespace AppService.UserAppService
{
    public interface IUserAppService
    {
        List<UserViewModel> GetUsers();
    }
}
