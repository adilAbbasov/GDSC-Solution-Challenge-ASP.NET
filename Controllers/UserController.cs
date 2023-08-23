using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhotoHome.Data;
using PhotoHome.Models;
using PhotoHome.Models.Entity;
using PhotoHome.Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;
using EASendMail;
using SmtpClient = EASendMail.SmtpClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Helpers;
using GoogleSolution.Models.Entity;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

namespace PhotoHome.Controllers
{
	public class UserController : Controller
	{
		private readonly AppDbContext _base;
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;
		private readonly RoleManager<IdentityRole> rolemanager;
		private readonly IWebHostEnvironment _env;

		public static string? FileName { get; set; }
		private static List<string> image_tags;

		public List<string> Image_Tags
		{
			get { return image_tags; }
			set { image_tags = value; }
		}


		public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> rolemanager, AppDbContext context, IWebHostEnvironment env)
		{
			_base = context;
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.rolemanager = rolemanager;
			_env = env;
		}


		public IActionResult Create()
		{
			var userId = GetUserId();

			if (userId == null)
				return RedirectToAction("LogInAs", "Home");

			ViewBag.ActiveMenu = "create";

			return View();
		}


		public IActionResult SignUp(string? errorMessage)
		{
			ViewBag.ErrorMessage = errorMessage;

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> SignUp(UserSignUpViewModel usersdata)

		{
			if (ModelState.IsValid)
			{
				string[] option = usersdata.Email.Split("@");

				var user = new User
				{
					Email = usersdata.Email,
					FirstName = usersdata.FirstName,
					LastName = usersdata.LastName,
					UserName = option[0],
					IsUser = true
				};

				if (!await rolemanager.RoleExistsAsync("Client"))
				{
					await rolemanager.CreateAsync(new IdentityRole { Name = "Client" });
				}

				var result = await userManager.CreateAsync(user, usersdata.Password);
				var boss = await userManager.AddToRoleAsync(user, "Client");

				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, true);
					var count = 0;

					try
					{
						var task = Task.Run(async delegate
						{
							try
							{
								await Task.Delay(1000);

								var oMail = new SmtpMail("TryIt")
								{
									From = "photohome2023@gmail.com",
									To = usersdata.Email,
									Subject = $"Thank you '{usersdata.FirstName}' for filling out our form! " + "\nPhotoHome",
									HtmlBody = "<html><body><img src='https://i.pinimg.com/564x/85/ac/9d/85ac9d284995da771bd36153a7c84107.jpg' /></body></html>"
								};

								var oServer = new SmtpServer("smtp.outlook.com")
								{
									Port = 587,
									User = "photohome2023@gmail.com",
									Password = "Photo_Home_2023",
									ConnectType = SmtpConnectType.ConnectTryTLS
								};

								var oSmtp = new SmtpClient();
								await oSmtp.SendMailAsync(oServer, oMail);
							}
							catch (Exception)
							{
								count++;
								throw;
							}
						});
						task.Wait();
					}
					catch (Exception)
					{
						return RedirectToAction("SignUp", "User", new { errorMessage = "Email is not existing, write an existing email." });
					}

					return RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var item in result.Errors)
						ModelState.AddModelError(item.Code, item.Description);

					return RedirectToAction("SignUp", "User", new { errorMessage = "Account with this email already exists." });
				}
			}

			return View();
		}


		public IActionResult LogIn(string? returnUrl, string? errorMessage)
		{
			if (returnUrl.ToLower() == "/admin")
				return RedirectToAction("Index", "AdminLogin", new { returnUrl = returnUrl.ToLower(), errorMessage = errorMessage });

			ViewBag.ReturnUrl = returnUrl.ToLower();
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
						await signInManager.SignInAsync(user, true);

						if (!string.IsNullOrWhiteSpace(returnUrl.ToLower()))
							return Redirect(returnUrl.ToLower());

						return RedirectToAction("Index", "Home");
					}
					else
						return RedirectToAction("Login", "User", new { returnUrl = returnUrl.ToLower(), errorMessage = "Incorrect email or password. Please try again." });
				}
				else
					return RedirectToAction("Login", "User", new { returnUrl = returnUrl.ToLower(), errorMessage = "Sorry, we couldn't find an account with that email address." });
			}

			return View();
		}


		public IActionResult LogOut()
		{
			signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}


		public async Task<IActionResult> Created()
		{
			var userId = GetUserId();
			var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == userId);

			var model = await _base.Images.Where(a => a.Allow == true && a.UserId == userId).ToListAsync();

			ViewBag.Images = model;

			return View(user);
		}


		[HttpGet]
		[AllowAnonymous]
		public IActionResult AccessDenied(string? returnUrl)
		{
			return RedirectToAction("LogIn", "User", returnUrl.ToLower());
		}


		public async Task<IActionResult> Liked()
		{
			var userId = GetUserId();
			var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == userId);

			var imageLikes = await _base.ImageLikes.Include(a => a.User).Where(a => a.UserId == userId).ToListAsync();
			var imageList = new List<Picture>();

			foreach (var item in imageLikes)
			{
				imageList.Add(await _base.Images.FirstOrDefaultAsync(a => a.Id == item.ImageId));
			}

			ViewBag.Images = imageList;

			return View(user);
		}


		public async Task<IActionResult> Settings()
		{
			var userId = GetUserId();
			var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == userId);

			return View(user);
		}


		[HttpPost]
		public async Task<IActionResult> Settings(User model)
		{
			var userId = GetUserId();
			var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == userId);

			user.FirstName = model.FirstName;
			user.LastName = model.LastName;
			user.UserName = model.UserName;
			user.Email = model.Email;

			await _base.SaveChangesAsync();

			return RedirectToAction("Settings");
		}


		[HttpPost]
		public async Task<IActionResult> Create(AddImageViewModel viewModel)
		{
			try
			{
				var userId = GetUserId();

				var picture = new Picture()
				{
					Title = viewModel.Title,
					LikeCount = viewModel.LikeCount,
					DownloadCount = viewModel.DownloadCount,
					UserId = userId,
					Allow = false
				};

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
				picture.ImageUrl = storageObject.MediaLink;

				await _base.Images.AddAsync(picture);
				await _base.SaveChangesAsync();

				//

				foreach (var item in Image_Tags)
				{
					if (await _base.Tags.FirstOrDefaultAsync(a => a.Name == item) == null)
					{
						await _base.Tags.AddAsync(new Tag { Name = item });
					}

					await _base.SaveChangesAsync();

					var tag = await _base.Tags.FirstOrDefaultAsync(a => a.Name == item);
					var image = await _base.Images.FirstOrDefaultAsync(a => a.ImageUrl == picture.ImageUrl);

					await _base.ImageTags.AddAsync(new ImageTag { ImageId = image.Id, TagId = tag.Id });
				}

				await _base.SaveChangesAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return RedirectToAction("Index", "Home");
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<int> GetFileName(IFormFile file)
		{
			FileName = await UploadFileHelper.UploadFile(file);

			return 200;
		}


		[HttpPost]
		[AllowAnonymous]
		public int AddTag(List<string> list)
		{
			Image_Tags = new List<string>();

			foreach (var item in list)
			{
				Image_Tags.Add(item);
			}

			return 200;
		}


		public string GetUserId()
		{
			var claim = (ClaimsIdentity)User.Identity;
			var claims = claim.FindFirst(ClaimTypes.NameIdentifier);

			if (claims == null)
				return null;

			return claims.Value;
		}


		private string? GenerateFileName(string fileName)
		{
			var fn = Path.GetFileNameWithoutExtension(fileName);
			var ex = Path.GetExtension(fileName);

			return $"{fn}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{ex}";
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}