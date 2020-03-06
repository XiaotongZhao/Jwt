using System.Linq;

namespace Domain.User.Service
{
    public interface IUserService
    {
        IQueryable<Entity.User> GetUsers();
    }
}
