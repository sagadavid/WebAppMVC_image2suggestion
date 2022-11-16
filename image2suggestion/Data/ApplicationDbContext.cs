using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using image2suggestion.Models;

namespace image2suggestion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<image2suggestion.Models.Photo> Photo { get; set; }
        public DbSet<image2suggestion.Models.Suggestion> Suggestion { get; set; }
    }
}