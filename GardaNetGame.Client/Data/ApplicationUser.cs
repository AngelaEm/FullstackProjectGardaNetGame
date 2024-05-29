using Microsoft.AspNetCore.Identity;

namespace GardaNetGame.Client.Data
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser
	{
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateOnly? DateOfBirth { get; set; }

    }

}
