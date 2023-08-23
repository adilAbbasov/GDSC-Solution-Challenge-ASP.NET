namespace PhotoHome.Models.Entity
{
	public class Tag : Entity
	{
		public Tag() { }

		public string Name { get; set; }
		public string? ImageUrl { get; set; }
		public ICollection<ImageTag> ImageTags { get; set; }
	}
}
