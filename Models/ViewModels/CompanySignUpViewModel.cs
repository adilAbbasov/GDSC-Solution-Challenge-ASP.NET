using System.ComponentModel.DataAnnotations;

namespace PhotoHome.Models.ViewModels
{
	public class CompanySignUpViewModel
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z]{3,15}$", ErrorMessage = "First name can contain only letters.")]
		public string? Name { get; set; }

		[Required]
		public string? SiteUrl { get; set; }

		[Required]
		[RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+", ErrorMessage = "Email can contain only letters, numbers, '@' and '.'.")]
		public string? Email { get; set; }

		[Required]
		[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,20}$", ErrorMessage = "Password must contain minimum eight characters, one upper case letter, one lower case letter, one number and one special character.")]
		public string? Password { get; set; }
	}
}
