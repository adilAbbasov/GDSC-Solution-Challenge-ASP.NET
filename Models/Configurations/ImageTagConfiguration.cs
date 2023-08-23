using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoHome.Models.Entity;

namespace UltraWebsite.Models.Configurations
{
	public class ImageTagConfiguration : IEntityTypeConfiguration<ImageTag>
	{
		public int Index { get; set; } = 1;

		public void Configure(EntityTypeBuilder<ImageTag> builder)
		{
			Random random = new();
			List<int> numbers = new();

			for (int i = 1; i < 40; i++)
			{
				int randomNum = random.Next(1, 13);

				for (int j = 1; j < randomNum; j++)
				{
					int option = random.Next(1, 49);

					if (!numbers.Contains(option))
					{
						builder.HasData(new ImageTag { TagId = option, ImageId = i, Id = Index++ });
						numbers.Add(option);
					}
				}
			}
		}
	}
}
