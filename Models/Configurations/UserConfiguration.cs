using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Models.Entity;
using GoogleSolution.Models.Entity;

namespace PhotoHome.Models.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public int Index { get; set; } = 1;

		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(new User { Id = Index++.ToString(), UserName = "Hesen_Rzayev", FirstName = "Hesen", Email = "hsnrz2002@gmail.com", LastName = "Rzayev", ImageUrl = "~\\images\\user\\adilabbasov.png" ,IsUser=true});
			builder.HasData(new User { Id = Index++.ToString(), UserName = "Adil_Abbasov", FirstName = "Adil", Email = "ffff@gmail.com", LastName = "Abbasov", IsUser = true });
		}
	}
}
