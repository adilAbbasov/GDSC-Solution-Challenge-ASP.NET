using GoogleSolution.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Data;
using PhotoHome.Models.Entity;

namespace PhotoHome.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class NotificationController : Controller
	{
		private readonly AppDbContext _base;
		private static string? Message { get; set; }

		public NotificationController(AppDbContext context)
		{
			_base = context;
		}


		public async Task<IActionResult> Index()
		{
			var images = await _base.Images.Include(a => a.User).Where(a => a.Allow == false).ToListAsync();
			var companies = await _base.Companies.Where(a => a.IsCompleted == true && a.Allow == false).ToListAsync();

			var imageNotifications = new List<ImageViewModel>();
			var companyNotifications = new List<CompanyViewModel>();

			foreach (var item in images)
			{
				var viewModel = new ImageViewModel()
				{
					Id = item.Id,
					UserFirstName = item.User.FirstName,
					UserLastName = item.User.LastName
				};

				imageNotifications.Add(viewModel);
			}

			foreach (var item in companies)
			{
				var viewModel = new CompanyViewModel()
				{
					Id = item.Id,
					Name = item.Name
				};

				companyNotifications.Add(viewModel);
			}

			ViewBag.ImageNotifications = imageNotifications;
			ViewBag.CompanyNotifications = companyNotifications;

			return View();
		}


		public async Task<IActionResult> AllowImage(ImageViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var picture = await _base.Images.FirstOrDefaultAsync(a => a.Id == viewModel.Id);
				picture.Allow = true;

				await SendNotificationAsync(Message, viewModel.UserId);

				await _base.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}


		public async Task<IActionResult> DenyImage(ImageViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var picture = await _base.Images.FirstOrDefaultAsync(a => a.Id == viewModel.Id);
				picture.Allow = false;

				//_base.Images.Remove(picture);

				await SendNotificationAsync(Message, viewModel.UserId);

				await _base.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}


		public async Task<IActionResult> AllowCompany(CompanyViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var company = await _base.Companies.FirstOrDefaultAsync(a => a.Id == viewModel.Id);
				company.Allow = true;

				await SendNotificationAsync(Message, viewModel.UserId);

				await _base.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}


		public async Task<IActionResult> DenyCompany(CompanyViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var company = await _base.Companies.FirstOrDefaultAsync(a => a.Id == viewModel.Id);

				company.Name = null;
				company.About = null;
				company.SiteUrl = null;
				company.LogoUrl = null;
				company.VideoUrl = null;
				company.Allow = false;
				company.IsCompleted = false;

				await SendNotificationAsync(Message, viewModel.UserId);

				await _base.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}


		public async Task<IActionResult> ImageDetailedInfo(string id)
		{
			var model = await _base.Images.Include(a => a.User).Include(a => a.ImageTags).FirstOrDefaultAsync(i => i.Id.ToString() == id);

			var viewModel = new ImageViewModel()
			{
				Id = model.Id,
				UserId = model.User.Id,
				Title = model.Title,
				ImageUrl = model.ImageUrl
			};

			ViewBag.Tags = await _base.ImageTags.Include(it => it.Image).Where(it => it.ImageId.ToString() == id).Select(it => it.Tag).Select(t => t.Name).ToListAsync();

			return View(viewModel);
		}


		public async Task<IActionResult> CompanyDetailedInfo(string id)
		{
			var model = await _base.Companies.Include(a => a.CompanyUser).FirstOrDefaultAsync(i => i.Id == id);

			var viewModel = new CompanyViewModel()
			{
				Id = model.Id,
				UserId = model.CompanyUser.Id,
				Name = model.Name,
				About = model.About,
				SiteUrl = model.SiteUrl,
				LogoUrl = model.LogoUrl,
				VideoUrl = model.VideoUrl
			};

			return View(viewModel);
		}


		private async Task<int> SendNotificationAsync(string message, string userId, string adminId = "1")
		{
			var notification = new Notification()
			{
				Message = message,
				UserId = userId,
				AdminId = adminId,
				SendTime = DateTime.Now
			};

			await _base.Notifications.AddAsync(notification);
			await _base.SaveChangesAsync();

			return 200;
		}


		public int AddMessage(string? message)
		{
			Message = message;

			return 200;
		}
	}
}
