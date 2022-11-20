using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace image2suggestion.Models
{
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }

        [StringLength(70, MinimumLength = 3, ErrorMessage = "Title should contain minimum 3 characters.")]
        [Required]
        public string Title { get; set; }

        [StringLength(180, MinimumLength = 3, ErrorMessage = "Title should contain minimum 3 characters.")]
        [Required]
        public string Description { get; set; }

        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    }
}
