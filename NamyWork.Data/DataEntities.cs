using NamyWork.Data.Entities;
using System.Data.Entity;

namespace NamyWork.Data
{
    public class DataEntities : DbContext
    {
        public DataEntities() : base("DataEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>() // one to one entity
                .HasRequired(u => u.Profile)
                .WithRequiredPrincipal(p => p.User);
        }
    }
}
