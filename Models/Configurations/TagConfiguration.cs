using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoHome.Models.Entity;
using PhotoHome.Models.Configurations;

namespace UltraWebsite.Models.Configurations
{
	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public int Index { get; set; } = 1;

		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.HasData(new Tag { Id = Index++, Name = "upset" });
			builder.HasData(new Tag { Id = Index++, Name = "worried" });
			builder.HasData(new Tag { Id = Index++, Name = "africa" });
			builder.HasData(new Tag { Id = Index++, Name = "worry" });
			builder.HasData(new Tag { Id = Index++, Name = "diversity" });
			builder.HasData(new Tag { Id = Index++, Name = "homeless" });
			builder.HasData(new Tag { Id = Index++, Name = "homelessness" });
			builder.HasData(new Tag { Id = Index++, Name = "indoors" });
			builder.HasData(new Tag { Id = Index++, Name = "poverty" });
			builder.HasData(new Tag { Id = Index++, Name = "unemployment" });
			builder.HasData(new Tag { Id = Index++, Name = "workless" });
			builder.HasData(new Tag { Id = Index++, Name = "jobsearch" });
			builder.HasData(new Tag { Id = Index++, Name = "hunger" });
			builder.HasData(new Tag { Id = Index++, Name = "poor" });
			builder.HasData(new Tag { Id = Index++, Name = "sadness" });
			builder.HasData(new Tag { Id = Index++, Name = "moneyless" });
			builder.HasData(new Tag { Id = Index++, Name = "outdoors" });
			builder.HasData(new Tag { Id = Index++, Name = "street" });
			builder.HasData(new Tag { Id = Index++, Name = "unemployed" });
			builder.HasData(new Tag { Id = Index++, Name = "beggar" });
			builder.HasData(new Tag { Id = Index++, Name = "beggaring" });
			builder.HasData(new Tag { Id = Index++, Name = "help" });
			builder.HasData(new Tag { Id = Index++, Name = "misfortune" });
			builder.HasData(new Tag { Id = Index++, Name = "hungry" });
			builder.HasData(new Tag { Id = Index++, Name = "abandoned" });
			builder.HasData(new Tag { Id = Index++, Name = "alone" });
			builder.HasData(new Tag { Id = Index++, Name = "dirty" });
			builder.HasData(new Tag { Id = Index++, Name = "grunge" });
			builder.HasData(new Tag { Id = Index++, Name = "lonely" });
			builder.HasData(new Tag { Id = Index++, Name = "outside" });
			builder.HasData(new Tag { Id = Index++, Name = "urban" });
			builder.HasData(new Tag { Id = Index++, Name = "begging" });
			builder.HasData(new Tag { Id = Index++, Name = "indoors" });
			builder.HasData(new Tag { Id = Index++, Name = "lifestyles" });
			builder.HasData(new Tag { Id = Index++, Name = "socialissues" });
			builder.HasData(new Tag { Id = Index++, Name = "dirt" });
			builder.HasData(new Tag { Id = Index++, Name = "mud" });
			builder.HasData(new Tag { Id = Index++, Name = "tents" });
			builder.HasData(new Tag { Id = Index++, Name = "tent" });
			builder.HasData(new Tag { Id = Index++, Name = "unhappy" });
			builder.HasData(new Tag { Id = Index++, Name = "untidy" });
			builder.HasData(new Tag { Id = Index++, Name = "charity" });
			builder.HasData(new Tag { Id = Index++, Name = "donate" });
			builder.HasData(new Tag { Id = Index++, Name = "health" });
			builder.HasData(new Tag { Id = Index++, Name = "hope" });
			builder.HasData(new Tag { Id = Index++, Name = "hopeless" });
			builder.HasData(new Tag { Id = Index++, Name = "humanity" });
			builder.HasData(new Tag { Id = Index++, Name = "justice" });
			builder.HasData(new Tag { Id = Index++, Name = "humanrights" });
			builder.HasData(new Tag { Id = Index++, Name = "endpoverty" });
			builder.HasData(new Tag { Id = Index++, Name = "inequality" });
		}
	}
}
