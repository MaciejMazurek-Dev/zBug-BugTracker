using Microsoft.AspNetCore.Identity;

namespace BugTracker.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? RefreshTokenCreated { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
        public string? RefreshToken { get; set; }
        public int InternalUserId { get; set; }
    }
}
