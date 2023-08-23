using GoogleSolution.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace PhotoHome.Models.Entity
{
	public class Company : IdentityUser
	{
		public string? Name { get; set; }
		public string? SiteUrl { get; set; }
		public string? VideoUrl { get; set; }
		public string? LogoUrl { get; set; }
		public string? About { get; set; }
		public bool? Allow { get; set; }

		public User CompanyUser { get; set; }
		public string? UserId { get; set; }

		public bool IsCompleted { get; set; }
	}
}
