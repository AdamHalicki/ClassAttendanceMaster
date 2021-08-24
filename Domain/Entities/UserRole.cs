using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class UserRole : IdentityUserRole<int>, IBaseEntity
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
