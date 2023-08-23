using Microsoft.EntityFrameworkCore;
using PhotoHome.Data;
using PhotoHome.Helpers;
using PhotoHome.Models.Entity;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace PhotoHome.Repository
{
	public class ImageRepository
	{
		private readonly AppDbContext _base;
		public ImageRepository(AppDbContext context)
		{
			_base = context;
		}

		private const int pageSize = 18;
		public async Task<List<Picture>> GetImage(int? pageNumber, string? searchPattern, string? searchType)
		{
			var model = new List<Picture>();
			var numberOfRecordToskip = pageNumber * pageSize;

			
			if (searchType == "tag")
			{
				model = await _base.ImageTags.Include(p => p.Image).Where(it => it.Tag.Name.ToLower().StartsWith(searchPattern.ToLower())).Select(it => it.Image).Where(a => a.Allow == true).OrderByDescending(a => a.LikeCount).Skip(Convert.ToInt32(numberOfRecordToskip)).Take(pageSize).ToListAsync();
			}
			else
			{
				model = await _base.Images.Where(a => a.Allow == true).OrderByDescending(a => a.LikeCount).Skip(Convert.ToInt32(numberOfRecordToskip)).Take(pageSize).ToListAsync();
			}

			return model;
		}
	}
}
