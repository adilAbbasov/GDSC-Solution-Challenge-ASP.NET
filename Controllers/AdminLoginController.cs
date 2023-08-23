using Microsoft.AspNetCore.Mvc;

namespace PhotoHome.Controllers
{
    public class AdminLoginController : Controller
    {
		public IActionResult Index(string? returnUrl, string? errorMessage)
		{
			ViewBag.ReturnUrl = returnUrl;
			ViewBag.ErrorMessage = errorMessage;

			return View();
		}
	}
}
