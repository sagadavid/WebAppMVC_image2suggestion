using image2suggestion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace image2suggestion.Data
{
    public class PhotoDbContext : IdentityDbContext
    {
        public PhotoDbContext(DbContextOptions<PhotoDbContext> options)
            : base(options)
        {
        }
        public DbSet<image2suggestion.Models.Photo> Photo { get; set; }
        public DbSet<image2suggestion.Models.Suggestion> Suggestion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Photo>()
                .HasOne<Suggestion>(s=>s.Suggestion)
                .WithMany(s=>s.Photos)
                .HasForeignKey(s => s.SuggestionID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
