using Domain.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
