using Microsoft.AspNetCore.Identity;

namespace MigrationIdentity.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}