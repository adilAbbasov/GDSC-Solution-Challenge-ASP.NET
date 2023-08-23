using Microsoft.EntityFrameworkCore;
using PhotoHome.Data;
using PhotoHome.Models.Entity;

namespace PhotoHome.Repository
{
	public class CompanyRepository
	{
		private readonly AppDbContext _base;
		public CompanyRepository(AppDbContext context)
		{
			_base = context;
		}

		private const int pageSize = 9;
		public async Task<List<Company>> GetCompany(int? pageNumber)
		{
			var numberOfRecordToskip = pageNumber * pageSize;

			var model = await _base.Companies.Skip(Convert.ToInt32(numberOfRecordToskip)).Take(pageSize).ToListAsync();

			return model;
		}
	}
}
