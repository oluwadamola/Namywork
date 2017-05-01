using System.Collections.Generic;

namespace NamyWork.Data.Entities
{
    public class Role : BaseEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles{ get; set; }

        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public enum AppRole
        {
            SystemAdministrator,
            User,
            Freelancer
        }

    }
}
