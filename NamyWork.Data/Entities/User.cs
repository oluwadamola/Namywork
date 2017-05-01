using System.Collections.Generic;

namespace NamyWork.Data.Entities
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual Profile Profile { get; set; }
        public bool ActiveStatus { get; set; }

        public ICollection<UserRole> UserRoles{ get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<UserRating> UserRatings { get; set; } 

        public User()
        {
          UserRoles = new HashSet<UserRole>();
            Services = new HashSet<Service>();
            UserRatings = new HashSet<UserRating>();
        }

    }
}
