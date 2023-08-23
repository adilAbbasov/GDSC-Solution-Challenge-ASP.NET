using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Data;
using PhotoHome.Models.Entity;

namespace PhotoHome.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ImageController : Controller
	{
        private readonly AppDbContext _base;
        public ImageController(AppDbContext context)
        {
            _base = context;
        }
    }
}