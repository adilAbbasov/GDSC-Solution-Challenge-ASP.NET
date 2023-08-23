using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Data;
using PhotoHome.Models.Entity;

namespace PhotoHome.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class TagController : Controller
	{
		private readonly AppDbContext _base;
		public TagController(AppDbContext context)
		{
			_base = context;
		}


		public async Task<IActionResult> Index()
		{
			return View(await _base.Tags.ToListAsync());
		}


		public IActionResult AddTag()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddTag(Tag model)
		{
			if (!ModelState.IsValid)
			{
				var tag = new Tag()
				{
					Name = model.Name
				};

				await _base.Tags.AddAsync(tag);
				await _base.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return View();
		}


		[HttpGet]
		public async Task<IActionResult> UpdateTag(int Id)
		{
			var tag = await _base.Tags.FirstOrDefaultAsync(a => a.Id == Id);

			return View(tag);
		}


		[HttpPost]
		public async Task<IActionResult> UpdateTag(Tag model)
		{
			if (model.Name != null)
			{
				var tag = await _base.Tags.FirstOrDefaultAsync(a => a.Id == model.Id);
				tag.Name = model.Name;

				await _base.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}


		public async Task<IActionResult> DeleteTag(int Id)
		{
			var tag = await _base.Tags.FirstOrDefaultAsync(a => a.Id == Id);

			_base.Tags.Remove(tag);
			await _base.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}