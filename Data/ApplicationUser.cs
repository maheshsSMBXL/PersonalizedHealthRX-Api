using Microsoft.AspNetCore.Identity;

namespace PersonalizedHealthRX_Api.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
    }
}
