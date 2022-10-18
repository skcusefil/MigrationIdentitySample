using Microsoft.AspNetCore.Identity;

namespace MigrationIdentity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
