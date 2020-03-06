using System.Linq;
using Infrastructure.Common.RepositoryTool;

namespace Domain.User.Service
{
    public class UserService : IUserService
    {
        private IRepository<Entity.User, long> userRepository;

        public UserService(IRepository<Entity.User, long> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IQueryable<Entity.User> GetUsers()
        {
            return userRepository.GetAll();
        }
    }
}
