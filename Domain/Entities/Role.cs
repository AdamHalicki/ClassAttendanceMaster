using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role : IdentityRole<int>, IBaseEntity
    {
        public Role() : base()
        {
            this.UserRoles = new HashSet<UserRole>();
        }

        public Role(string roleName)
            : base(roleName)
        {
        }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
