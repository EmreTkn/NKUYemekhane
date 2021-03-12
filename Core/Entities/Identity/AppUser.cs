using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string SchoolNumber { get; set; }
        public School School { get; set; }
    }
}
