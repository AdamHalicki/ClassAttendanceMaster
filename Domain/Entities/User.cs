using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace Domain.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public User() : base()
        {
            this.UserRoles = new HashSet<UserRole>();
        }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
