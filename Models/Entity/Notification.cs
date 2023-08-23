using GoogleSolution.Models.Entity;

namespace PhotoHome.Models.Entity
{
	public class Notification : Entity
	{
		public Notification() { }

		public string Message { get; set; }
		public string UserId { get; set; }
		public string? AdminId { get; set; }
		public DateTime SendTime { get; set; }
	}
}
