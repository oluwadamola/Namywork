using NamyWork.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace NamyWork.Core.Business
{
    public class RoleModel : Model
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }

        public RoleModel(Role role)
        {
            this.Assign(role);
        }
    }
}
