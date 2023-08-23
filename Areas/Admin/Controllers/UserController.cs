using GoogleSolution.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Data;
using PhotoHome.Models.Entity;

namespace PhotoHome.Areas.Admin.Controllers
{
	[Area("Admin")]


	public class UserController : Controller
	{
		private readonly AppDbContext _base;
		public UserController(AppDbContext context)
		{
			_base = context;
		}


		public async Task<IActionResult> Index()
		{
			return View(await _base.Users.ToListAsync());
		}


		public IActionResult AddUser()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddUser(User model)
		{
			if (!ModelState.IsValid)
			{
				var user = new User()
				{
					LastName = model.LastName,
					FirstName = model.FirstName,
					Email = model.Email,
					UserName = model.UserName
				};

				await _base.Users.AddAsync(user);
				await _base.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return View();
		}


		[HttpGet]
		public async Task<IActionResult> UpdateUser(string Id)
		{
			var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == Id);

			return View(user);
		}


		[HttpPost]
		public async Task<IActionResult> UpdateUser(User model)
		{
			if (model.FirstName != null)
			{
				var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == model.Id);

				user.LastName = model.LastName;
				user.FirstName = model.FirstName;
				user.Email = model.Email;
				user.UserName = model.UserName;

				await _base.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteUser(string Id)
		{
			var user = await _base.Users.FirstOrDefaultAsync(a => a.Id == Id);

			_base.Users.Remove(user);
			await _base.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}