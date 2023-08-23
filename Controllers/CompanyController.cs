using Microsoft.AspNetCore.Mvc;
using PhotoHome.Models.Entity;
using PhotoHome.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using PhotoHome.Helpers;
using Microsoft.AspNetCore.Identity;
using PhotoHome.Data;
using Microsoft.EntityFrameworkCore;
using EASendMail;
using GoogleSolution.Models.Entity;
using PhotoHome.Repository;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace PhotoHome.Controllers
{
	public class CompanyController : Controller
	{
		private readonly AppDbContext _base;
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> SignInManager;
		private readonly RoleManager<IdentityRole> rolemanager;
		private CompanyRepository companyRepository;
		private readonly IWebHostEnvironment _env;
		private static string? FileName { get; set; }


		public CompanyController(UserManager<User> userManager, SignInManager<User> SignInManager, RoleManager<IdentityRole> rolemanager, AppDbContext context, IWebHostEnvironment env)
		{
			_base = context;
			this.userManager = userManager;
			this.SignInManager = SignInManager;
			this.rolemanager = rolemanager;
			_env = env;
		}


		public async Task<ActionResult> Index()
		{
			companyRepository = new CompanyRepository(_base);
			var model = await companyRepository.GetCompany(0);

			var userId = GetUserId();

			if (userId != null)
			{
				ViewBag.User = await _base.Users.FirstOrDefaultAsync(a => a.Id == userId);

				ViewBag.NotificationMessages = await _base.Notifications.Where(a => a.UserId == userId).Select(a => a.Message).ToListAsync();

				var notificationTimes = new List<string>();

				foreach (var item in _base.Notifications.Where(a => a.UserId == userId))
				{
					TimeSpan timeSpan = DateTime.Now - item.SendTime;
					var sendTime = "";

					if (timeSpan.Hours > 0)
					{
						sendTime = $"{timeSpan.Hours} hours ago";
					}
					else if (timeSpan.Minutes > 0)
					{
						sendTime = $"{timeSpan.Minutes} minutes ago";
					}
					else
					{
						sendTime = $"{timeSpan.Seconds} seconds ago";
					}

					notificationTimes.Add(sendTime);
				}

				ViewBag.NotificationTimes = notificationTimes;
			}

			ViewBag.ActiveMenu = "companies";

			return View(model);
		}


		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult> CompanyListAsync(int? pageNumber)
		{
			companyRepository = new CompanyRepository(_base);
			var model = await companyRepository.GetCompany(pageNumber);

			return PartialView("CompanyList", model);
		}


		public async Task<IActionResult> CompanyInfo(string id)
		{
			var model = await _base.Companies.FirstOrDefaultAsync(a => a.Id == id);

			ViewBag.RelatedCompanies = await _base.Companies.Where(a => a.Id != id).ToListAsync();

			return View(model);
		}


		public IActionResult SignUp(string? errorMessage)
		{
			ViewBag.ErrorMessage = errorMessage;

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> SignUp(CompanySignUpViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				string[] option = viewModel.Email.Split("@");

				var user = new User
				{
					Email = viewModel.Email,
					UserName = option[0],
					FirstName = viewModel.Name,
					LastName = viewModel.SiteUrl,
					IsUser = false
				};

				if (!await rolemanager.RoleExistsAsync("Client"))
				{
					await rolemanager.CreateAsync(new IdentityRole { Name = "Client" });
				}

				var result = await userManager.CreateAsync(user, viewModel.Password);

				if (result.Succeeded)
				{
					await SignInManager.SignInAsync(user, true);

					await _base.SaveChangesAsync();

					var company = new Company
					{
						Name = viewModel.Name,
						Email = viewModel.Email,
						SiteUrl = viewModel.SiteUrl,
						CompanyUser = user,
					};

					await _base.Companies.AddAsync(company);

					var notification = new Models.Entity.Notification()
					{
						Message = "Complete your profile from settings to make your company visible to the users.",
						UserId = user.Id,
						SendTime = DateTime.Now
					};

					await _base.Notifications.AddAsync(notification);

					await _base.SaveChangesAsync();

					return RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var item in result.Errors)
						ModelState.AddModelError(item.Code, item.Description);

					return RedirectToAction("SignUp", "Company", new { errorMessage = "Account with this email already exists." });
				}
			}

			return View();
		}


		public IActionResult LogIn(string? returnUrl, string? errorMessage)
		{
			if (returnUrl == "/admin")
				return RedirectToAction("Index", "AdminLogin", new { returnUrl = returnUrl, errorMessage = errorMessage });

			ViewBag.ReturnUrl = returnUrl;
			ViewBag.ErrorMessage = errorMessage;

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LogInViewModel viewModel, string? returnUrl)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(viewModel.Email);

				if (user != null)
				{
					if (await userManager.CheckPasswordAsync(user, viewModel.Password))
					{
						await SignInManager.SignInAsync(user, true);

						if (!string.IsNullOrWhiteSpace(returnUrl))
							return Redirect(returnUrl);

						return RedirectToAction("Index", "Home");
					}
					else
						return RedirectToAction("Login", "Company", new { returnUrl = returnUrl, errorMessage = "Incorrect email or password. Please try again." });
				}
				else
					return RedirectToAction("Login", "Company", new { returnUrl = returnUrl, errorMessage = "Sorry, we couldn't find an account with that email address." });
			}

			return View();
		}


		public async Task<IActionResult> Settings()
		{
			var userId = GetUserId();
			var company = await _base.Companies.Include(a => a.CompanyUser).FirstOrDefaultAsync(a => a.CompanyUser.Id == userId);

			return View(company);
		}


		[HttpPost]
		public async Task<IActionResult> Settings(Company model)
		{
			try
			{
				var userId = GetUserId();
				var company = await _base.Companies.Include(a => a.CompanyUser).FirstOrDefaultAsync(a => a.CompanyUser.Id == userId);

				company.Name = model.Name;
				company.About = model.About;
				company.SiteUrl = model.SiteUrl;
				company.VideoUrl = model.VideoUrl;
				company.Allow = false;
				company.IsCompleted = true;

				//

				var credentialPath = Path.Combine(_env.WebRootPath, "auth.json");
				var credential = GoogleCredential.FromFile(credentialPath);
				var storage = StorageClient.Create(credential);
				var bucketName = "asp-net-file-server-demo";
				var name = GenerateFileName(FileName);

				using (var fileStream = new FileStream(FileName, FileMode.Open))
				{
					storage.UploadObject(bucketName, name, null, fileStream);
				}

				var storageObject = storage.GetObject(bucketName, name);
				storageObject.Acl ??= new List<ObjectAccessControl>();
				storageObject.Acl.Add(new ObjectAccessControl { Entity = "allUsers", Role = "READER" });

				storage.UpdateObject(storageObject, new UpdateObjectOptions { });
				company.LogoUrl = storageObject.MediaLink;

				await _base.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return RedirectToAction("Settings");
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<int> GetFileName(IFormFile file)
		{
			FileName = await UploadFileHelper.UploadFile(file);

			return 200;
		}


		private static string? GenerateFileName(string fileName)
		{
			var fn = Path.GetFileNameWithoutExtension(fileName);
			var ex = Path.GetExtension(fileName);

			return $"{fn}-{DateTime.Now.ToUniversalTime():yyyyMMddHHmmss}{ex}";
		}


		public string GetUserId()
		{
			var claim = (ClaimsIdentity)User.Identity;
			var claims = claim.FindFirst(ClaimTypes.NameIdentifier);

			if (claims == null)
				return null;

			return claims.Value;
		}
	}
}
