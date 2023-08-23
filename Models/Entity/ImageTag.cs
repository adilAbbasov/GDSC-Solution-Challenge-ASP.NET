namespace PhotoHome.Models.Entity
{
	public class ImageTag : Entity
	{
		public int TagId { get; set; }
		public int ImageId { get; set; }

		public Picture Image { get; set; }
		public Tag Tag { get; set; }
	}
}
