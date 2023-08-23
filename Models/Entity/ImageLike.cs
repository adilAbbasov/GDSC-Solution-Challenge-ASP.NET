using GoogleSolution.Models.Entity;

namespace PhotoHome.Models.Entity
{
    public class ImageLike
    {
        public string UserId { get; set; }
        public int ImageId { get; set; }

        public Picture Image { get; set; }
        public User User { get; set; }
    }
}
