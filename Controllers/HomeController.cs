using GoogleSolution.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Data;
using PhotoHome.Models;
using PhotoHome.Models.Entity;
using PhotoHome.Repository;
using System.Diagnostics;
using System.Security.Claims;

namespace PhotoHome.Controllers
{
	[Authorize(Roles = "Client")]

	public class HomeController : Controller
	{
		private readonly AppDbContext _base;
		private ImageRepository imageRepository;
		private readonly UserManager<User> userManager;
		private const int pageSize = 15;
		public const int ImageMinimumBytes = 512;

		public HomeController(AppDbContext context, UserManager<User> userManager)
		{
			_base = context;
			this.userManager = userManager;
		}


		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult> Index()
		{
			imageRepository = new ImageRepository(_base);
			var model = await imageRepository.GetImage(0, null, null);

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

			ViewBag.Companies = await _base.Companies.Where(a => a.Allow == true).ToListAsync();
			ViewBag.Image_Likes = await _base.ImageLikes.ToListAsync();
			ViewBag.ActiveMenu = "index";

			return View(model);
		}


		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult> ImageListAsync(int? pageNumber, string? searchPattern, string? searchType)
		{
			imageRepository = new ImageRepository(_base);
			var model = await imageRepository.GetImage(pageNumber, searchPattern, searchType);

			return PartialView("ImageList", model);
		}


		[AllowAnonymous]
		public async Task<IActionResult> Search(string searchPattern, string searchType)
		{
			imageRepository = new ImageRepository(_base);
			var model = await imageRepository.GetImage(0, searchPattern, searchType);

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

			ViewBag.Companies = await _base.Companies.Where(a => a.Allow == true).ToListAsync();

			return View("Index", model);
		}


		[HttpPost]
		[AllowAnonymous]
		public List<string> SearchTag(string searchTerm)
		{
			var model = _base.Tags.Where(it => it.Name.ToLower().StartsWith(searchTerm)).Select(it => it.Name).ToList();

			return model;
		}


		[AllowAnonymous]
		public IActionResult SignUpAs()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult LogInAs()
		{
			return View();
		}


		[AllowAnonymous]
		public IActionResult About()
		{
			ViewBag.ActiveMenu = "about";

			return View();
		}


		[AllowAnonymous]
		public IActionResult Contact()
		{
			ViewBag.ActiveMenu = "contact";

			return View();
		}


		[AllowAnonymous]
		public IActionResult Services()
		{
			ViewBag.ActiveMenu = "services";

			return View();
		}


		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ImageInfo(string Id)
		{
			if (Id.Contains("%2F")) Id = Id.Replace("%2F", "/");

			var model = await _base.Images.Include(n => n.User).FirstOrDefaultAsync(n => n.ImageUrl == Id);
			var id = model.Id;

			var relatedImages = await _base.Images.Where(a => a.Id != id).ToListAsync();

			var imageTags = await _base.ImageTags.Where(a => a.ImageId == id).ToListAsync();
			var tags = new List<Tag>();

			foreach (var item in imageTags)
			{
				tags.Add(await _base.Tags.FirstOrDefaultAsync(a => a.Id == item.TagId));
			}

			ViewBag.Tags = (tags);
			ViewBag.RelatedImages = relatedImages;

			return View(model);
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> DownloadImage(string link)
		{
			var picture = await _base.Images.FirstOrDefaultAsync(a => a.ImageUrl == link);
			picture.DownloadCount++;

			await _base.SaveChangesAsync();

			return RedirectToAction("Index");
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> LikeImage(string link)
		{
			var userId = GetUserId();

			if (userId == null)
				return RedirectToAction("LogIn", "User");

			var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == userId);
			var picture = await _base.Images.FirstOrDefaultAsync(a => a.ImageUrl == link);

			var imageLike = new ImageLike { ImageId = picture.Id, UserId = user.Id };

			if (!_base.ImageLikes.Contains(imageLike))
			{
				await _base.ImageLikes.AddAsync(imageLike);
				picture.LikeCount++;
			}
			else
			{
				_base.ImageLikes.Remove(imageLike);
				picture.LikeCount--;
			}

			await _base.SaveChangesAsync();

			return RedirectToAction("Index");
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> DeleteImage(string link)
		{
			var userId = GetUserId();

			if (userId == null)
				return RedirectToAction("LogIn", "User");

			var picture = await _base.Images.FirstOrDefaultAsync(a => a.ImageUrl == link);

			_base.Images.Remove(picture);
			await _base.SaveChangesAsync();

			return RedirectToAction("Created");
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> MarkAsRead()
		{
			var userId = GetUserId();

			foreach (var item in _base.Notifications)
			{
				if (item.UserId == userId)
					_base.Remove(item);
			}

			await _base.SaveChangesAsync();

			return RedirectToAction("Index");
		}


		public string GetUserId()
		{
			var claim = (ClaimsIdentity)User.Identity;
			var claims = claim.FindFirst(ClaimTypes.NameIdentifier);

			if (claims == null)
				return null;

			return claims.Value;
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}