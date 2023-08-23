using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhotoHome.Models
{
	public class Tokens
	{
		// Generate token
		public string Token { get; set; }
		public string RefreshToken { get; set; }
	}
}
