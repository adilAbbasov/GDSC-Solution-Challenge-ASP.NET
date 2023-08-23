using Microsoft.AspNetCore.Identity;
using PhotoHome.Models.Entity;

namespace GoogleSolution.Models.Entity
{
	public class User : IdentityUser
    {
        public User() { }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? About { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Picture> CreatedImages { get; set; }
        public virtual ICollection<ImageLike> LikedImages { get; set; }

        public bool IsUser { get; set; }
    }
}
