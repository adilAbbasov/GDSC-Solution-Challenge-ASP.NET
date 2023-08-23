using GoogleSolution.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoHome.Models.Configurations;
using PhotoHome.Models.Entity;
using UltraWebsite.Models.Configurations;

namespace PhotoHome.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Picture> Images { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Company> Companies { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
		public DbSet<ImageLike> ImageLikes { get; set; }
		public DbSet<Notification> Notifications { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		
			modelBuilder.Entity<Picture>()
			   .HasOne(s => s.User)
			   .WithMany(g => g.CreatedImages)
			   .HasForeignKey(s => s.UserId);
			modelBuilder.Entity<ImageTag>()
				.HasKey(bc => new { bc.ImageId, bc.TagId });
			modelBuilder.Entity<ImageTag>()
				.HasOne(bc => bc.Image)
				.WithMany(b => b.ImageTags)
				.HasForeignKey(bc => bc.ImageId)
				.OnDelete(DeleteBehavior.NoAction);
			modelBuilder.Entity<ImageTag>()
				.HasOne(bc => bc.Tag)
				.WithMany(c => c.ImageTags)
				.HasForeignKey(bc => bc.TagId)
				.OnDelete(DeleteBehavior.NoAction);
			modelBuilder.Entity<ImageLike>()
			 .HasKey(bc => new { bc.ImageId, bc.UserId });
			modelBuilder.Entity<ImageLike>()
				.HasOne(bc => bc.Image)
				.WithMany(b => b.ImageLikes)
				.HasForeignKey(bc => bc.ImageId)
				.OnDelete(DeleteBehavior.NoAction);
			modelBuilder.Entity<ImageLike>()
				.HasOne(bc => bc.User)
				.WithMany(c => c.LikedImages)
				.HasForeignKey(bc => bc.UserId)
				.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new ImageConfiguration());
			modelBuilder.ApplyConfiguration(new TagConfiguration());
			modelBuilder.ApplyConfiguration(new ImageTagConfiguration());
			modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
	}
}
