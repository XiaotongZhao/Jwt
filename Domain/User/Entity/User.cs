using Infrastructure.Common.RepositoryTool;

namespace Domain.User.Entity
{
    public class User : EntityBase<long>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
