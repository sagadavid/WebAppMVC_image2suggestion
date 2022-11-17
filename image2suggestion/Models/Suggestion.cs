using System.ComponentModel.DataAnnotations;

namespace image2suggestion.Models
{
    public class Suggestion
    {
        public int Id { get; set; }

        //[RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Title should begin with uppercase and should not contain special character")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Title should contain minimum 3 characters.")]
        [Required]
        public string Title { get; set; }

        [StringLength(180, MinimumLength = 3, ErrorMessage = "Title should contain minimum 3 characters.")]
        [Required]
        public string Description { get; set; }


    }
}
