using GoogleSolution.Models.Entity;

namespace PhotoHome.Models.Entity
{
	public class Picture : Entity
	{
		public Picture() { }

		public string Title { get; set; }
		public string ImageUrl { get; set; }
		public int LikeCount { get; set; }
		public int DownloadCount { get; set; }
		public bool? Allow { get; set; }

		public virtual User User { get; set; }
		public string? UserId { get; set; }

		public virtual ICollection<ImageLike> ImageLikes { get; set; }
		public virtual ICollection<ImageTag> ImageTags { get; set; }
	}
}
